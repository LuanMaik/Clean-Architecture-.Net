using CleanArchitecture.Application.Bus;
using CleanArchitecture.Application.Bus.Commands;
using CleanArchitecture.Application.UseCases.Customers.Commands.CreateCustomer;
using CleanArchitecture.Application.UseCases.Customers.Commands.InactivateCustomer;
using CleanArchitecture.Application.UseCases.Customers.Queries.GetCustomerById;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebAPI.Controllers.Abstract;
using CleanArchitecture.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

[ApiController]
[Route("/customer")]
public class CustomerController : ApiController
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
    /// <response code="400">If the item is null or contains invalid data</response>
    /// <response code="500">If internal error</response>
    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<Customer>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
    public async Task<IApiResponse> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        try
        {
            var result = await _busService.SendCommand(command);
            return result.IsSuccess 
                ? SuccessResponse(result.Data()) 
                : ValidationErrorResponse(result.Errors);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }

    /// <summary>
    /// Get Customer by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If the item is null or contains invalid data</response>
    /// <response code="500">If internal error</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(SuccessResponse<Customer>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
    public async Task<IApiResponse> GetCustomerById(int id)
    {
        try
        {
            CommandResult<Customer> result = await _busService.SendCommand(new GetCustomerByIdQuery(id));
            
            return result.IsSuccess 
                ? SuccessResponse(result.Data()) 
                : ValidationErrorResponse(result.Errors);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }

    /// <summary>
    /// Get Customer by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If the item is null or contains invalid data</response>
    /// <response code="500">If internal error</response>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(typeof(SuccessResponse<Customer>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
    public async Task<IApiResponse> InactivateCustomer(int id)
    {
        try
        {
            CommandResult<Customer> result = await _busService.SendCommand(new InactivateCustomerCommand(id));
            return result.IsSuccess 
                ? SuccessResponse(result.Data()) 
                : ValidationErrorResponse(result.Errors);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
}