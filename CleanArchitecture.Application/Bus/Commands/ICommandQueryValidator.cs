namespace CleanArchitecture.Application.Bus.Commands;

public interface ICommandQueryValidator<T>
{
    public bool IsValid(T commandQuery);
    public string[] GetErrorsMessages();
}