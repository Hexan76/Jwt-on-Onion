using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;

public class TokenHandler : ITokenHandler
{
    private readonly ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();

    private readonly TokenOptions _tokenOptions;
    private readonly SigningConfigurations _signingConfigurations;

    public TokenHandler(IOptions<TokenOptions> tokenOptionsSnapshot, SigningConfigurations signingConfigurations)
    {
        // _passwordHaser = passwordHaser;
        _tokenOptions = tokenOptionsSnapshot.Value;
        _signingConfigurations = signingConfigurations;
    }
    public AccessToken CreateAccessToken(User user)
    {
        var refreshToken = BuildRefreshToken();
        var accessToken = BuildAccessToken(user, refreshToken);
        _refreshTokens.Add(refreshToken);

        return accessToken;

    }
    private AccessToken BuildAccessToken(User user, RefreshToken refreshToken)
    {
        var accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);

        var securityToken = new JwtSecurityToken
        (
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            claims: GetClaims(user),
            notBefore: DateTime.UtcNow,
            expires: accessTokenExpiration,
            signingCredentials: _signingConfigurations.SigningCredentials
        );

        var handler = new JwtSecurityTokenHandler();
        var accessToken = handler.WriteToken(securityToken);

        return new AccessToken(accessToken, accessTokenExpiration.Ticks, refreshToken);
    }
    private RefreshToken BuildRefreshToken()
    {
        var reftoken = new RefreshToken
        (
            token: Guid.NewGuid().ToString(),
            expiration: _tokenOptions.RefreshTokenExpiration
        )
        ;
        return reftoken;
    }
    public RefreshToken? TakeRefreshToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return null;

        var refreshToken = _refreshTokens.SingleOrDefault(t => t.Token == token);
        if (refreshToken != null)
            _refreshTokens.Remove(refreshToken);

        return refreshToken;
    }

    public void RevokeRefreshToken(string token)
    {
        TakeRefreshToken(token);
    }

    private IEnumerable<Claim> GetClaims(User user)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            };

        // foreach (Role userRole in user.Roles)
        // {
        //     claims.Add(new Claim(ClaimTypes.Role, userRole.RoleName));
        // }

        return claims;
    }

}