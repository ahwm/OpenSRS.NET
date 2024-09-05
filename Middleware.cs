#if NETCORE
using Microsoft.Extensions.DependencyInjection;
#endif

namespace OpenSRS.NET
{
#if NETCORE
    public static class MiddlewareExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection UseOpenSRS(this IServiceCollection services)
        {
            services.AddHttpClient("OpenSRS");
            return services.AddTransient<OpenSRSClient>();
        }
    }
    #endif
}