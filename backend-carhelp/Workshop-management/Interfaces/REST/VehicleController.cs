using System.Net.Mime;
using backend_carhelp.Iam.Interfaces.REST.Resources;
using backend_carhelp.Iam.Interfaces.REST.Transform;
using backend_carhelp.Workshop_management.Domain.Model.Commands;
using backend_carhelp.Workshop_management.Domain.Model.Queries;
using backend_carhelp.Workshop_management.Domain.Services;
using backend_carhelp.Workshop_management.Interfaces.REST.Resources;
using backend_carhelp.Workshop_management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend_carhelp.Workshop_management.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class VehicleController(IVehicleQueryService vehicleQueryService, IVehicleCommandService vehicleCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVehicle(CreateVehicleResource resource)
    {
        var createVehicleCommand = CreateVehicleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var vehicle = await vehicleCommandService.Handle(createVehicleCommand);
        if (vehicle is null) return BadRequest();
        var vehicleResource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle);
        return CreatedAtAction(nameof(GetVehicleById), new {vehicleId = vehicleResource.Id}, vehicleResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var getAllVehiclesQuery = new GetAllVehiclesQuery();
        var vehicles = await vehicleQueryService.Handle(getAllVehiclesQuery);
        var vehicleResources = vehicles.Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vehicleResources);
    }

    [HttpGet("{vehicleId:int}")]
    public async Task<IActionResult> GetVehicleById(int vehicleId)
    {
        var getVehicleByIdQuery = new GetVehicleByIdQuery(vehicleId);
        var vehicle = await vehicleQueryService.Handle(getVehicleByIdQuery);
        if (vehicle == null) return NotFound();
        var vehicleResource = VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle);
        return Ok(vehicleResource);
    }
    
    [HttpDelete("{vehicleId:int}")]
    public async Task<IActionResult> DeleteVehicle(int vehicleId)
    {
        var deleteVehicleResource = new DeleteVehicleCommand(vehicleId);
        await vehicleCommandService.Handle(deleteVehicleResource);
        return NoContent();
    }
}