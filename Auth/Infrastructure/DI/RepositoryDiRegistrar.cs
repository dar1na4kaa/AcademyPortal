using Application.Interfaces;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class RepositoryDiRegistrar
{
    public static IServiceCollection AddRepository(this IServiceCollection service) =>
        service
            .AddScoped<IUserRepository, UserRepository>();
}