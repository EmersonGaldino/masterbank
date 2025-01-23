using Microsoft.AspNetCore.Builder;

namespace master.bank.bootstrapper.configurations.exceptions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}