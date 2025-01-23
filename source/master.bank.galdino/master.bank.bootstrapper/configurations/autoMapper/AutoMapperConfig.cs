using master.bank.utils.autoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace master.bank.bootstrapper.configurations.autoMapper;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        if(services == null) throw new ArgumentNullException(nameof(services));
        services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfile));
    }
}