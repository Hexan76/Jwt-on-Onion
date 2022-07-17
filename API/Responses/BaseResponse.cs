public class BaseResponse
{
    public BaseResponse(bool success, string? message)
    {
        Message = message;
        Success = success;
    }

    public string? Message { get; set; }
    public bool Success { get; set; }

}
