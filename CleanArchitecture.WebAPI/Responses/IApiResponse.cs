namespace CleanArchitecture.WebAPI.Responses;

public interface IApiResponse
{
    public bool IsSuccess();
    public string GetMessage();
}