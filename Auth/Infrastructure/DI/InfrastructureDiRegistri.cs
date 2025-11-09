using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class InfrastructureDiRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration) =>
        service
            .AddDatabase(configuration)
            .AddRepository();
    
    private static IServiceCollection AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        service.AddDbContext<UserContext>(options => options.UseNpgsql(connectionString));
        return service;
    }
}