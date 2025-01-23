using master.bank.bootstrapper.configurations.cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace master.bank.bootstrapper.configurations.security;

public static partial class ProtectionControllers
{
    public static IServiceCollection AddProtectedControllers(this IServiceCollection services)
    {
        services.AddControllers(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    
                .RequireAuthenticatedUser()
                .Build();

            config.Filters.Add(new AuthorizeFilter(policy));
            config.Filters.Add(typeof(ValidateModelStateAttribute));
        });

        return services;
    }
}