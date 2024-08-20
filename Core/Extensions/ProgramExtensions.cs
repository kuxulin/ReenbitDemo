using AutoMapper;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Core.Services;
using Core.Services.Interfaces;

namespace Core.Extensions;

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

    public static void AddMappers(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile<MappingProfile>();
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
