
using master.bank.bootstrapper.filters;
using master.bank.domain.core.repository.Interface.route;
using master.bank.domain.core.service.Interface.route;
using master.bank.domain.core.service.route;
using master.bank.infraestructure.crosscutting.infraestructure.baseConfig;
using master.bank.infraestructure.persistence.configuration.uow;
using master.bank.infraestructure.persistence.repository.route;
using master.bank.utils.shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace master.bank.bootstrapper.configurations.dependencyInjection;

public static class DependencyInjectionsExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        #region .::Include injection configurations estructure
        var infraConfig = new InfrastructureBaseConfig();
        new ConfigureFromConfigurationOptions<InfrastructureBaseConfig>(
                configuration.GetSection("Infrastructure"))
            .Configure(infraConfig);
        services.AddSingleton(infraConfig);
        #endregion
        
        #region .:: Configuration filter performace
    
        services.AddTransient<PerformaceFilters>();
        services.AddMvc(options => options.Filters.AddService<PerformaceFilters>())
            .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true)
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        #endregion

        services.AddScoped<IConnectionPostgres, UnitOfWorkPostgres>(x
            => new UnitOfWorkPostgres(configuration.GetSection("Configurations").GetSection("Connection-string").Value));
        
        #region .::AppService
        // services.AddScoped<IRouteAppService, RouteAppService>();
        
        #endregion
        
        #region .::Service

        services.AddScoped<IRouteService, RouteService>();
        #endregion
        
        #region .::Repository
        services.AddScoped<IRouteRepository, RouteRepository>();
        
        #endregion
        
        
        return services;

    }
    private static void RegistrarInterfaces(IServiceCollection services, Type typeBase, string containsInNamespace,
        string sulfix)
    {
        var types = typeBase
            .Assembly
            .GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                           type.Namespace.Contains(containsInNamespace) &&
                           type.Name.EndsWith(sulfix) &&
                           !type.IsGenericType &&
                           type.IsClass &&
                           type.GetInterfaces().Any());

        foreach (var type in types)
        {
            var interfaceType = type
                .GetInterfaces()?
                .FirstOrDefault(t => t.Name == $"I{type.Name}");
            if (interfaceType == null) continue;
            services.AddScoped(interfaceType, type);
        }
    }
}