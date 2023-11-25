namespace Cookbook.Domain.Models.Communication.Responses;
public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int ErrorCode { get; set; }
    public dynamic Data { get; set; }

    public ApiResponse()
    {
        Success = false;
        Message = string.Empty;
        ErrorCode = 0;
        Data = new object();
    }
}