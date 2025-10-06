using Microsoft.Extensions.DependencyInjection;

namespace OpenSRS.NET.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenSRS(Environment.GetEnvironmentVariable("OPENSRS_TEST_KEY"), Environment.GetEnvironmentVariable("OPENSRS_TEST_USER"), true);
            services.AddTransient<IDomainService, OpenSRSDomainService>();
        }
    }
}
