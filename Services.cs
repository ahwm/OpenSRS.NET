#if NETCORE
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
#endif

namespace OpenSRS.NET
{
#if NETCORE
    public static class ServicesExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key"></param>
        /// <param name="username"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public static IServiceCollection AddOpenSRS(this IServiceCollection services, string key, string username, bool test = false)
        {
            // https://stackoverflow.com/a/79111722/1892993
            services.AddOptions<OpenSRSClientOptions>()
                .Configure(options => options.Key = key);
            services.AddHttpClient<OpenSRSClient>(client =>
            {
                client.BaseAddress = test ? new Uri("https://horizon.opensrs.net:55443") : new Uri("https://rr-n1-tor.opensrs.net:55443");
                client.DefaultRequestHeaders.Add("X-Username", username);
            });

            return services;
        }
    }
    #endif
}