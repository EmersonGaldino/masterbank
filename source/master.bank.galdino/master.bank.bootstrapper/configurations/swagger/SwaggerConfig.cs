using Microsoft.AspNetCore.Builder;

namespace master.bank.bootstrapper.configurations.swagger;

public static class SwaggerConfig
{
    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Master Bank Galdino");
            c.RoutePrefix = string.Empty;
        });
    }
}