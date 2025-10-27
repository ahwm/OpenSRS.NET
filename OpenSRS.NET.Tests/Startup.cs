using Microsoft.Extensions.DependencyInjection;

namespace OpenSRS.NET.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOpenSRS(Environment.GetEnvironmentVariable("OPENSRS_TEST_KEY")!.Trim(), Environment.GetEnvironmentVariable("OPENSRS_TEST_USER")!.Trim(), true);
            services.AddTransient<IDomainService, OpenSRSDomainService>();
        }
    }
}
