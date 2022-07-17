public class TokenResponse : BaseResponse
{
    public TokenResponse(bool success, string message, string? accessToken = null, string? refreshToken = null, DateTime? expiration = null)
    : base(success, message)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        Expiration = expiration;
    }

    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? Expiration { get; set; }

}