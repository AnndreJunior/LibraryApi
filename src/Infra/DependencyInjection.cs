using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class DependencyInjection
{
    public static void AddInfra(this IServiceCollection service, IConfiguration configuration)
    {
        ApplyConfiguration(configuration);
    }

    private static void ApplyConfiguration(IConfiguration configuration)
    {
    }
}
