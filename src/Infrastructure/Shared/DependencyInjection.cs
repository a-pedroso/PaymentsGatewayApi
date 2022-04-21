namespace PaymentsGatewayApi.Infrastructure.Shared;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using PaymentsGatewayApi.Infrastructure.Shared.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureShared(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddScoped<ICkoBankSimulator, CkoBankSimulator>();

        return services;
    }
}