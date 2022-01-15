namespace CleanArchitecture.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("Register not found.") 
    {
    }
    
    public NotFoundException(string message) : base(message)
    {
    }
}