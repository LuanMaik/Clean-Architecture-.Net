using CleanArchitecture.WebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers.Abstract;

public abstract class ApiController: ControllerBase
{
    protected SuccessResponse<T> SuccessResponse<T>(T data)
    {
        base.StatusCode(StatusCodes.Status200OK);
        return new SuccessResponse<T>(data);
    }
    
    protected SuccessResponse<T> SuccessResponse<T>(string message, T data)
    {
        base.StatusCode(StatusCodes.Status200OK);
        return new SuccessResponse<T>(message, data);
    }
    
    protected ErrorResponse ValidationErrorResponse(string message, IEnumerable<string> errors)
    {
        base.StatusCode(StatusCodes.Status400BadRequest);
        return new ErrorResponse(message, errors);
    }
    
    protected ErrorResponse ValidationErrorResponse(IEnumerable<string> errors)
    {
        base.StatusCode(StatusCodes.Status400BadRequest);
        return new ErrorResponse("Invalid data", errors);
    }
    
    protected ErrorResponse ErrorResponse()
    {
        base.StatusCode(StatusCodes.Status500InternalServerError);
        return new ErrorResponse("Internal Error", new string[0]);
    }
    
    protected ErrorResponse ErrorResponse(string message, IEnumerable<string> errors)
    {
        base.StatusCode(StatusCodes.Status500InternalServerError);
        return new ErrorResponse(message, errors);
    }
    
    protected ErrorResponse ErrorResponse(string message)
    {
        base.StatusCode(StatusCodes.Status500InternalServerError);
        return new ErrorResponse(message);
    }
    
    protected ErrorResponse ErrorResponse(IEnumerable<string> errors)
    {
        base.StatusCode(StatusCodes.Status500InternalServerError);
        return new ErrorResponse("Internal Error", errors);
    }
}