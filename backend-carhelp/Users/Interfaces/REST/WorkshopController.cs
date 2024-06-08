using System.Net.Mime;
using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Iam.Domain.Services;
using backend_carhelp.Iam.Interfaces.REST.Resources;
using backend_carhelp.Iam.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace backend_carhelp.Iam.Interfaces.REST
{
    [ApiController]
    [Route("apiv1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopCommandService _workshopCommandService;
        private readonly IWorkshopQueryService _workshopQueryService;

        public WorkshopController(IWorkshopCommandService workshopCommandService,
            IWorkshopQueryService workshopQueryService)
        {
            _workshopCommandService = workshopCommandService;
            _workshopQueryService = workshopQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkshop(CreateWorkshopResource resource)
        {
            var createWorkshopCommand = CreateWorkshopCommandFromResouceAssembler.ToCommandFromResource(resource);
            var workshop = await _workshopCommandService.Handle(createWorkshopCommand);
            if (workshop is null) return BadRequest();
            var workshopResource = WorkshopResourceFromEntityAssembler.ToResourceFromEntity(workshop);
            return CreatedAtAction(nameof(GetWorkshopById), new { workshopId = workshopResource.Id }, workshopResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkshops()
        {
            var getAllWorkshopQuery = new GetAllWorkshopQuery();
            var workshops = await _workshopQueryService.Handle(getAllWorkshopQuery);
            var workshopResources = workshops.Select(WorkshopResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(workshopResources);
        }

        [HttpGet("{workshopId:int}")]
        public async Task<IActionResult> GetWorkshopById(int workshopId)
        {
            var getWorkshopByIdQuery = new GetWorkshopByIdQuery(workshopId);
            var workshop = await _workshopQueryService.Handle(getWorkshopByIdQuery);
            if (workshop == null) return NotFound();
            var workshopResource = WorkshopResourceFromEntityAssembler.ToResourceFromEntity(workshop);
            return Ok(workshopResource);
        }

        [HttpDelete("{Id:int}")]

        public async Task<IActionResult> DeleteWorkshop(int Id)
        {
            var deleteWorkshopResource = new DeleteWorkshopResource(Id);
            var deleteWorkshopCommand = DeleteWorkshopCommandFromResouceAssembler.ToCommandFromResource(deleteWorkshopResource);
            await _workshopCommandService.Handle(deleteWorkshopCommand);
            return NoContent();
        }
    }
}