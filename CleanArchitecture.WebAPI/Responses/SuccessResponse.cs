using System.ComponentModel;

namespace CleanArchitecture.WebAPI.Responses;

public class SuccessResponse<T>: IApiResponse
{
    public bool Success { get; private set; } = true;
    
    
    
    [DefaultValue("Eg: Success operation")]
    public string Message { get; private set; } = "Success operation";
    
    

    public T Data { get; set; }
    

    public SuccessResponse(string message, T data)
    {
        Message = message;
        Data = data;
    }

    public SuccessResponse(T data)
    {
        Data = data;
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