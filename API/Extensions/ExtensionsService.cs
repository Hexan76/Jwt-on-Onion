using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static void AddExtensionsService(this IServiceCollection services)
    {
        services.AddSingleton<ITokenHandler, TokenHandler>();

        services.AddTransient<IAuth, Auth>();
        services.AddSingleton<IAuthorizationPolicyProvider, PolicyAuthProvider>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }
}
