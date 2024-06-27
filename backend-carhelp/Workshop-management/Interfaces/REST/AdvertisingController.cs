using System.Net.Mime;
using backend_carhelp.Workshop_management.Domain.Model.Queries;
using backend_carhelp.Workshop_management.Domain.Repositories;
using backend_carhelp.Workshop_management.Domain.Services;
using backend_carhelp.Workshop_management.Interfaces.REST.Resources;
using backend_carhelp.Workshop_management.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend_carhelp.Workshop_management.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AdvertisingController(IAdvertisingCommandService advertisingCommandService, IAdvertisingQueryService advertisingQueryService): ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllAdvertasing()
    {
        var getAllAdvertasingQuery = new GetAllAdvertisingQuery();
        var advertasings = await advertisingQueryService.Handle(getAllAdvertasingQuery);
        var advertasingResource = advertasings.Select(AdvertisingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(advertasingResource);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAdvertasingById(int id)
    {
        var getAdvertasingByIdQuery = new GetAdvertisingByIdQuery(id);
        var advertasing = await advertisingQueryService.Handle(getAdvertasingByIdQuery);
        if(advertasing == null) {
            return NotFound();
        }
        var advertasingResource = AdvertisingResourceFromEntityAssembler.ToResourceFromEntity(advertasing);
        return Ok(advertasingResource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdvertasing(CreateAdvertisingResource resource)
    {
        var createAdvertasingCommand = CreateAdvertisingCommandFromResourceAssembler.ToCommandFromResource(resource);
        var advertasing = await advertisingCommandService.Handle(createAdvertasingCommand);
        if (advertasing == null)
        {
            return BadRequest();
        }
        var advertasingResource = AdvertisingResourceFromEntityAssembler.ToResourceFromEntity(advertasing);
        return CreatedAtAction(nameof(GetAdvertasingById), new { id = advertasingResource.Id }, advertasingResource);
    }
}