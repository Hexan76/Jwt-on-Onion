public class BaseResponse
{
    public BaseResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
    public bool Success { get; set; }
    public string Message { get; set; }

}