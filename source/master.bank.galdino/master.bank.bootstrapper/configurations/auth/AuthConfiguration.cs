using System.Reflection.Metadata;
using System.Text;
using master.bank.bootstrapper.configurations.security;
using master.bank.infraestructure.crosscutting.infraestructure.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace master.bank.bootstrapper.configurations.auth;

public static class AuthConfiguration
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        var signConfiguration = new SignConfigurationToken();
        services.AddSingleton(signConfiguration);

        var tokenConfigure = new TokenConfig();

        new ConfigureFromConfigurationOptions<TokenConfig>(
                configuration.GetSection(nameof(TokenConfig)))
            .Configure(tokenConfigure);

        services.AddSingleton(tokenConfigure);

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(bearrerOptions =>
            {
                var paramsValidation = bearrerOptions.TokenValidationParameters;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ValidateActor = true;
                paramsValidation.ValidateAudience = true;
                paramsValidation.ValidAudience = tokenConfigure.Audience;
                paramsValidation.ValidIssuer = tokenConfigure.Issuer;
                paramsValidation.ClockSkew = TimeSpan.Zero;

                paramsValidation.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigure.SigningKey));
            });

        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build());

            auth.AddPolicy("MasterBankService", policy =>
            {
                //TODO colocar um ID cliente se tiver
                // policy.RequireAssertion(context =>
                //     context.User.HasClaim(c => c.Type == Constant.ID));
            });
        });
        services.AddMemoryCache();
    }
}