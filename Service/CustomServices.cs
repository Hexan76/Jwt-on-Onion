using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repository;
using Service.InterfaceService;
using Service.Services;

public static class CustomServices
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        //services.AddTransient<IMyService, MyService>();
        services.AddTransient<IUser, RepUser>();
        services.AddTransient<ISerRepUser, SerUser>();
        services.AddTransient<ICRUD, CRUD>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

    }
}
