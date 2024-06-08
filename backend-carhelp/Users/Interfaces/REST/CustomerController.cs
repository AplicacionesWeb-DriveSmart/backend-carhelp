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
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCommandServcice _customerCommandService;
        private readonly ICustomerQueryService _customerQueryService;

        public CustomerController(ICustomerCommandServcice customerCommandService, ICustomerQueryService customerQueryService)
        {
            _customerCommandService = customerCommandService;
            _customerQueryService = customerQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerResource resource)
        {
            var createCustomerCommand = CreateCustomerCommandFromResourceAssembler.ToCommandFromResource(resource);
            var customer = await _customerCommandService.Handle(createCustomerCommand);
            if (customer is null) return BadRequest();
            var customerResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { customerId = customerResource.Id }, customerResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var getAllCustomerQuerys = new GetAllCustomersQuery();
            var customers = await _customerQueryService.Handle(getAllCustomerQuerys);
            var customerResources = customers.Select(CustomerResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(customerResources);
        }

        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var getCustomerByIdQuery = new GetCustomerByIdQuery(customerId);
            var customer = await _customerQueryService.Handle(getCustomerByIdQuery);
            if (customer == null) return NotFound();
            var customerResource = CustomerResourceFromEntityAssembler.ToResourceFromEntity(customer);
            return Ok(customerResource);
        }
        
        [HttpDelete("{Id:int}")]
        
         public async Task<IActionResult> DeleteUser(int Id)
    {
        var deleteCustomerResource = new DeleteCustomerResource(Id);
        var deleteCustomerCommand = DeleteCustomerCommandFromResourcesAssembler.ToCommandFromResource(deleteCustomerResource);
        await _customerCommandService.Handle(deleteCustomerCommand);
        return NoContent();
    }
    }
}
