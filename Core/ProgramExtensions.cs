using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Services;
using Core.Services.Interfaces;

namespace Core;

public static class ProgramExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IChatsService, ChatsService>();
    }

    public static void AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IChatsRepository, ChatsRepository>();
    }
}
