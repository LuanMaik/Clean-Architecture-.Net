namespace CleanArchitecture.Application.Interfaces.CommandQuery;

public interface ICommandQueryValidator<T>
{
    public bool IsValid(T commandQuery);
    public string[] GetErrorsMessages();
}