using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.InterfaceService;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IAuth _auth;
    private readonly ISerRepUser _user;
    private readonly IMapper _mapping;

    public AuthenticationController(IAuth auth, ISerRepUser user, IPasswordHasher hashPash, IMapper mapping)
    {
        _auth = auth;
        _user = user;
        _mapping = mapping;
    }

    [HttpPost]
    public async Task<TokenResponse> Login(LoginDTO user)
    {
        User oUser = _mapping.Map<LoginDTO, User>(user);
        if (oUser == null) return new TokenResponse(false, "invalid input");
        var token = await _auth.GenerateTokenAsync(oUser);
        return await Task.FromResult<TokenResponse>((token));
    }
    [HttpPost]
    public async Task<TokenResponse> GetToken(User user)
    {
        var tokenResponse = await _auth.GenerateTokenAsync(user);
        return await Task.FromResult<TokenResponse>(tokenResponse);
    }

    [HttpPost]
    public async Task<TokenResponse> RefreshToken(User user, string token)
    {
        var tokenResponse = await _auth.RefreshTokenAsync(user, token);
        return await Task.FromResult<TokenResponse>(tokenResponse);
    }

    [HttpGet]
    public async Task RevokeToken(string token)
    {
        await _auth.RevokeRefreshTokenAsync(token);
    }
}