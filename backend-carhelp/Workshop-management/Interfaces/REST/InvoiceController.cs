using System.Net.Mime;
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
public class InvoiceController(IInvoiceQueryService invoiceQueryService, IInvoiceCommandService invoiceCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateInvoice(CreateInvoiceResource resource)
    {
        var createInvoiceCommand = CreateInvoiceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var invoice = await invoiceCommandService.Handle(createInvoiceCommand);
        if (invoice is null) return BadRequest();
        var invoiceResource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return CreatedAtAction(nameof(GetInvoiceById), new {invoiceId = invoiceResource.Id}, invoiceResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var getAllInvoicesQuery = new GetAllInvoicesQuery();
        var invoices = await invoiceQueryService.Handle(getAllInvoicesQuery);
        var invoiceResources = invoices.Select(InvoiceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(invoiceResources);
    }

    [HttpGet("{invoiceId:int}")]
    public async Task<IActionResult> GetInvoiceById(int invoiceId)
    {
        var getInvoiceByIdQuery = new GetInvoiceByIdQuery(invoiceId);
        var invoice = await invoiceQueryService.Handle(getInvoiceByIdQuery);
        if (invoice == null) return NotFound();
        var invoiceResource = InvoiceResourceFromEntityAssembler.ToResourceFromEntity(invoice);
        return Ok(invoiceResource);
    }
    
    [HttpDelete("{invoiceId:int}")]
    public async Task<IActionResult> DeleteInvoice(int invoiceId)
    {
        var deleteInvoiceResource = new DeleteInvoiceCommand(invoiceId);
        await invoiceCommandService.Handle(deleteInvoiceResource);
        return NoContent();
    }
    
}