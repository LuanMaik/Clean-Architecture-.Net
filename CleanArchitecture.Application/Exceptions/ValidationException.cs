namespace CleanArchitecture.Application.Exceptions;

public class ValidationException : Exception
{
    private IList<string> Errors { get; }
    
    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = Array.Empty<string>();
    }

    public ValidationException(IList<string> failures)
        : this()
    {
        Errors = failures;
    }


    public IList<string> GetErrorsMessages()
    {
        return Errors;
    }
}