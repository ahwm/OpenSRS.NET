#if NETCORE
using Microsoft.Extensions.DependencyInjection;
using System;
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
        /// <param name="key"></param>
        /// <param name="username"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public static IServiceCollection UseOpenSRS(this IServiceCollection services, string key, string username, bool test = false)
        {
            services.AddHttpClient("OpenSRS", client =>
            {
                client.BaseAddress = test ? new Uri("https://horizon.opensrs.net:55443") : new Uri("https://rr-n1-tor.opensrs.net:55443");
                client.DefaultRequestHeaders.Add("X-Username", username);
            });
            return services.AddTransient<OpenSRSClient>();
        }
    }
    #endif
}