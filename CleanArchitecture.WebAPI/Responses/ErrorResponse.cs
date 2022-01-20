namespace CleanArchitecture.WebAPI.Responses;

public record ErrorResponse
{
    public string Message { get; private set; }
    public IList<string> Errors { get; private set; } = Array.Empty<string>();

    public ErrorResponse(string message)
    {
        Message = message;
    }
    public ErrorResponse(string message, IList<string> errors)
    {
        Message = message;
        Errors = errors;
    }
};