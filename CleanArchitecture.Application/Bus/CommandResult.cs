namespace CleanArchitecture.Application.Bus;

public class CommandResult<T> {
    private CommandResult(T data) {
        _data = data;
        IsSuccess = true;
    }
    private CommandResult() {
        _data = default(T);
        IsSuccess = true;
    }

    public bool IsSuccess { get; private set; }
    public IList<string> Errors { get; private set; } = new List<string>();
    private readonly T? _data;

    public T? Data() {
        return _data;
    }

    internal void AddError(string error) {
        this.Errors.Add(error);
        this.IsSuccess = false;
    }

    internal void AddErrors(IList<string> errors) 
    {
        foreach (var error in errors)
            this.Errors.Add(error);
        
        this.IsSuccess = false;
    }

    static internal CommandResult<T> Fail(T entity, string error) 
    {
        var result = new CommandResult<T>(entity);
        result.AddError(error);
        return result;
    }

    static internal CommandResult<T> Fail(IList<string> errors) 
    {
        var result = new CommandResult<T>();
        result.AddErrors(errors);
        return result;
    }

    static internal CommandResult<T> Success(T entity) => new CommandResult<T>(entity);

        
}