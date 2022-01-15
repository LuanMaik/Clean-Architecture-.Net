using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Bus.Interfaces;
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
            Customer result = await _busService.SendCommand(command);
            return SuccessResponse(result);
        }
        catch (ValidationException ex)
        {
            return ValidationErrorResponse(ex.GetErrorsMessages());
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
            Customer result = await _busService.SendCommand(new GetCustomerByIdQuery(id));
            return SuccessResponse(result);
        }
        catch (ValidationException ex)
        {
            return ValidationErrorResponse(ex.GetErrorsMessages());
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
            bool result = await _busService.SendCommand(new InactivateCustomerCommand(id));
            return SuccessResponse(result);
        }
        catch (ValidationException ex)
        {
            return ValidationErrorResponse(ex.GetErrorsMessages());
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
}