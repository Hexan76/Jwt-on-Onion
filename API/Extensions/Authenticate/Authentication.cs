using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

public static class Authentication
{
    public static IServiceCollection AddOurAuthentication
    (this IServiceCollection services, TokenOptions tokenOptions, SigningConfigurations signingConfigurations)
    {

        services.AddAuthorization(option =>
        option.AddPolicy("Test",
        policy => policy.RequireClaim("Perm1", "True"))
                );


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(jwt =>
        {
            jwt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {

                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                IssuerSigningKey = signingConfigurations.SecurityKey,
                ClockSkew = TimeSpan.Zero
            };
        }
        );
        return services;
    }
}