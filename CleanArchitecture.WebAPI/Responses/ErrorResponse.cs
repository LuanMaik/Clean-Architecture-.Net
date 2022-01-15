using System.ComponentModel;

namespace CleanArchitecture.WebAPI.Responses;

public record ErrorResponse: IApiResponse
{
    [DefaultValue(false)]
    public bool Success { get; private set; } = false;
    
    
    
    [DefaultValue("Eg: Error description")]
    public string Message { get; private set; }
    
    
    
    [DefaultValue(new string[2]{"Eg: First error description", "Eg: Second error description"})]
    public IEnumerable<string> Errors { get; private set; }
    
    

    public ErrorResponse(string message, IEnumerable<string> errors)
    {
        Message = message;
        Errors = errors;
    }

    public ErrorResponse(string message)
    {
        Message = message;
        Errors = new string[0];
    }

    public bool IsSuccess()
    {
        return Success;
    }

    public string GetMessage()
    {
        return Message;
    }
};