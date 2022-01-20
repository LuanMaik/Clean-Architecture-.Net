using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;
using CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;
using CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

[ApiController]
[Route("/customer")]
public class CustomerController : ControllerBase
{
    private readonly IBusService _busService;

    public CustomerController(IBusService busService)
    {
        _busService = busService;
    }

    /// <summary>
    /// Create new Customer
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If contains invalid data</response>
    /// <response code="500">If internal error</response>
    [HttpPost]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        try
        {
            var result = await _busService.SendCommand(command);
            return result.IsSuccess 
                ? Ok(result.Data())
                : BadRequest(new ErrorResponse("Invalid params", result.Errors));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,new ErrorResponse("Server error"));
        }
    }

    /// <summary>
    /// Get Customer by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If contains invalid data</response>
    /// <response code="500">If internal error</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        try
        {
            CommandResult<Customer> result = await _busService.SendCommand(new GetCustomerByIdQuery(id));
            return result.IsSuccess 
                ? Ok(result.Data())
                : BadRequest(new ErrorResponse("Invalid params", result.Errors));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,new ErrorResponse("Server error"));
        }
    }

    /// <summary>
    /// Get Customer by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If contains invalid data</response>
    /// <response code="500">If internal error</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> InactivateCustomer(int id)
    {
        try
        {
            CommandResult<Customer> result = await _busService.SendCommand(new InactivateCustomerCommand(id));
            return result.IsSuccess 
                ? Ok(result.Data())
                : BadRequest(new ErrorResponse("Invalid params", result.Errors));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,new ErrorResponse("Server error"));
        }
    }
}