using Microsoft.Extensions.DependencyInjection;

public static class CustomBusinessLogic
{
    public static void AddCustomBusinessLogic(this IServiceCollection services)
    {
        //services.AddTransient<IMyService, MyService>();
        //services.AddTransient<IUser, RepUser>();
        //services.AddTransient<ISerRepUser, SerUser>();
    }

}

