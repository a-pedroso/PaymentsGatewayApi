﻿namespace PaymentsGatewayApi.WebApi.Extensions;

using PaymentsGatewayApi.Application;
using PaymentsGatewayApi.Application.Common.Interfaces.Services;
using PaymentsGatewayApi.Infrastructure.Persistence;
using PaymentsGatewayApi.Infrastructure.Persistence.Context;
using PaymentsGatewayApi.Infrastructure.Shared;
using PaymentsGatewayApi.WebApi.Extensions.StartupExtensions;
using PaymentsGatewayApi.WebApi.Helpers;
using PaymentsGatewayApi.WebApi.Services;
using Hellang.Middleware.ProblemDetails.Mvc;
using Prometheus.DotNetRuntime;
using Serilog;

public static class ProgramExtensions
{
    public static void SetupSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .WriteTo.Debug()
                .ReadFrom.Configuration(ctx.Configuration));
    }

    public static void SetupMetrics()
    {
        Log.Information("Enabling prometheus-net.DotNetStats...");
        DotNetRuntimeStatsBuilder.Customize()
                                 .WithContentionStats()
                                 .WithGcStats()
                                 .WithJitStats()
                                 .WithThreadPoolStats()
                                 .WithExceptionStats()
                                 .WithErrorHandler(ex => Log.Error(ex, "DotNetRuntime Error"))
                                 .StartCollecting();
    }

    public static void SetupServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplication()
                        .AddInfrastructurePersistence(builder.Configuration)
                        .AddInfrastructureShared(builder.Configuration);

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddControllers()
                        .AddProblemDetailsConventions();

        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddScoped<ICurrentClientService, CurrentClientService>();

        builder.Services.AddProblemDetailsExtension()
                        .AddMetricsExtension()
                        .AddOpenTelemetryExtension(builder.Configuration, builder.Environment)
                        .AddAuthenticationExtension(builder.Configuration)
                        .AddDataProtectionKeysExtension(builder.Configuration)
                        .AddForwardHeadersExtension(builder.Configuration)
                        .AddHealthChecksExtension(builder.Configuration)
                        .AddSwaggerExtension(builder.Configuration);
    }

    public static void SetupRequestPipeline(this WebApplication app)
    {
        app.UseProblemDetailsExtension();

        app.UseForwardHeadersExtension(app.Configuration);

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseMetricsExtension();

        app.UseSwaggerExtension(app.Configuration);

        app.UseHealthChecksExtension();

        app.MapControllers().RequireAuthorization();
    }

    public static async Task RunMigrationsAsync(this WebApplication app)
    {
        if (app.Environment.IsDevelopment() &&
            app.Configuration.GetValue<bool>("RunEFCoreMigrations"))
        {
            Log.Information($"running migrations {DateTime.UtcNow}");

            using var serviceScope = app.Services.CreateScope();

            var services = serviceScope.ServiceProvider;
            using var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            await DbMigrationHelper<ApplicationDbContext>.EnsureDatabaseMigratedAsync(scope);
        }
    }
}