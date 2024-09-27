using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Seq;
using Microsoft.Extensions.DependencyInjection;

namespace EdenTravels.Api.Configurations
{
    public static class SerilogConfig
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((context, services, configuration) =>
            {
                configuration
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);

                var seqServerUrl = context.Configuration["Serilog:WriteTo:1:Args:ServerUrl"];
                if (!string.IsNullOrEmpty(seqServerUrl))
                {
                    configuration.WriteTo.Seq(seqServerUrl);
                }
            });
        }
    }
}
