using System.Net;

namespace Portfolio.Application.DataContracts;
public class ApiResponse
{
    public HttpStatusCode StatusCode { get; }
    public string Message { get; }
    public object? Result { get; }

    public ApiResponse(string message, object? result, HttpStatusCode statusCode)
    {
        this.StatusCode = statusCode;
        this.Message = message;
        this.Result = result;
    }
}
