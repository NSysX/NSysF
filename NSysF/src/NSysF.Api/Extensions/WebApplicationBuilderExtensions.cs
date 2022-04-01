using Serilog;
using Serilog.Events;

namespace NSysF.Api.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AgregaSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
