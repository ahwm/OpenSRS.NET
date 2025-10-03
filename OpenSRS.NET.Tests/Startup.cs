using Microsoft.Extensions.DependencyInjection;

namespace OpenSRS.NET.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenSRS("aa1575e340e1aea0a77d46cebb23671beb83050c917d3dd0fb3f29143399d3168ca526fb4f3f8f8d7eee7acaa1ecd5b20742d9243d28260e", "thescripters", true);
            services.AddTransient<IDomainService, OpenSRSDomainService>();
        }
    }
}
