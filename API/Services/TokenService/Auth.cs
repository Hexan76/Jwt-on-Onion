using Service.InterfaceService;

public interface IAuth
{
    Task<TokenResponse> GenerateTokenAsync(User User);
    Task<TokenResponse> RefreshTokenAsync(User user, string refreshtoken);
    Task RevokeRefreshTokenAsync(string refreshtoken);
}
public class Auth : IAuth
{
    private readonly ITokenHandler _tokenhandler;
    private readonly IPasswordHasher _hashPass;
    private readonly ISerRepUser _user;

    public Auth(ITokenHandler tokenhandler, IPasswordHasher hashPass, ISerRepUser user)
    {
        _tokenhandler = tokenhandler;
        _hashPass = hashPass;
        _user = user;
    }

    public async Task<TokenResponse> GenerateTokenAsync(User user)
    {
        if (user == null) return new TokenResponse(false, ("invalid input"));
        var result = _user.GetUserbyUserNameAsync(user.UserName).Result;
        if (!result.Success | !_hashPass.PasswordMatches(user.Password, result?.User?.Password)) return new TokenResponse(false, "user or password is wrong!");
        var token = _tokenhandler.CreateAccessToken(result.User);
        var tokenResponse = new TokenResponse
        (
            true,
            "created token",
            token.Token,
            token.RefreshToken.Token,
            new DateTime(token.Expiration)
        );
        return await Task.FromResult<TokenResponse>(tokenResponse);
    }

    public async Task<TokenResponse> RefreshTokenAsync(User user, string refreshtoken)
    {
        var token = _tokenhandler.TakeRefreshToken(refreshtoken);

        if (token == null)
        {
            return await Task.FromResult<TokenResponse>(new TokenResponse(false, "Token is Invalid !"));
        }

        if (token.IsExpired())
        {
            return await Task.FromResult<TokenResponse>(new TokenResponse(false, "Token is Expired !"));
        }

        if (user == null)
        {
            return await Task.FromResult<TokenResponse>(new TokenResponse(false, "Token is not exist."));
        }

        var accessToken = _tokenhandler.CreateAccessToken(user);
        return await Task.FromResult<TokenResponse>(new TokenResponse(true, "Token is Succesfully Created."));

    }

    public async Task RevokeRefreshTokenAsync(string refreshtoken)
    {
        await Task.Run(() => _tokenhandler.RevokeRefreshToken(refreshtoken));
    }
}