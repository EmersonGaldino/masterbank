using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace master.bank.bootstrapper.configurations.dependencyInjection;

public static class DependencyInjectionsExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}