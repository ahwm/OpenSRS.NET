#if NETCORE
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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