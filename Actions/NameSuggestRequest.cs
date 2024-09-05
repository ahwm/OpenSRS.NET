using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Actions
{
    public class NameSuggestRequest : OpenSRSRequest
    {
        public NameSuggestRequest() : base("NAME_SUGGEST", "DOMAIN")
        {
            MaxWaitTime = TimeSpan.FromSeconds(5);
        }

#if NETCORE
        public string Query { get; set; } = "";

        /// <summary>
        /// The TLDs you want to check for domain name availability and suggestions.
        /// Lookups are available for all gTLDs and ccTLDs.
        /// [.com,.net,.org,.info,.biz,.us,.mobi]
        /// </summary>
        public string[] Tlds { get; set; } = [];
#else
        public string Query { get; set; }

        /// <summary>
        /// The TLDs you want to check for domain name availability and suggestions.
        /// Lookups are available for all gTLDs and ccTLDs.
        /// [.com,.net,.org,.info,.biz,.us,.mobi]
        /// </summary>
        public string[] Tlds { get; set; }
#endif

        public TimeSpan MaxWaitTime { get; set; }

        public bool? NoCacheTlds { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            var dic = new Dictionary<string, object>(4) {
                { "max_wait_time",  MaxWaitTime.TotalSeconds },
                { "searchstring",   Query },
                { "tlds",           Extensions.ToDtArray(Tlds) }
            };

            if (NoCacheTlds == true)
            {
                dic["no_cache_tlds"] = "1";
            }

            return dic;
        }
    }
}
