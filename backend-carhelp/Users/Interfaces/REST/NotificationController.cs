using System.Net.Mime;
using backend_carhelp.Iam.Domain.Model.Commands;
using backend_carhelp.Iam.Domain.Model.Queries;
using backend_carhelp.Iam.Domain.Services;
using backend_carhelp.Iam.Interfaces.REST.Resources;
using backend_carhelp.Iam.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend_carhelp.Iam.Interfaces.REST;

[ApiController]
[Route("apiv1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NotificationController : ControllerBase
{
    private readonly INotificationCommandService _notificationCommandService;
    private readonly INotificationQueryService _notificationQueryService;

    public NotificationController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService)
    {
        _notificationCommandService = notificationCommandService;
        _notificationQueryService = notificationQueryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationResource resource)
    {
        var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var notification = await _notificationCommandService.Handle(createNotificationCommand);
        if (notification is null) return BadRequest();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return CreatedAtAction(nameof(GetNotificationById), new {notificationId = notificationResource.Id}, notificationResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        var getAllNotificationsQuery = new GetAllNotificationsQuery();
        var notifications = await _notificationQueryService.Handle(getAllNotificationsQuery);
        var notificationResources = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(notificationResources);
    }
    
    [HttpGet("{notificationId:int}")]
    public async Task<IActionResult> GetNotificationById(int notificationId)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        var notification = await _notificationQueryService.Handle(getNotificationByIdQuery);
        if (notification == null) return NotFound();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return Ok(notificationResource);
    }

    [HttpDelete("{Id:int}")]
    public async Task<IActionResult> DeleteNotification(int Id)
    {
        var deleteNotificationResource = new DeleteNotificationResource(Id);
        var deleteNotificationCommand = DeleteNotificationCommandFromResourceAssembler.ToCommandFromResource(deleteNotificationResource);
        await _notificationCommandService.Handle(deleteNotificationCommand);
        return NoContent();

    }
}