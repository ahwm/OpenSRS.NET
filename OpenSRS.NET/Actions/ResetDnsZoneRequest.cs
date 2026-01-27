using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class ResetDnsZoneRequest : OpenSRSRequest
    {
        public ResetDnsZoneRequest() : base("RESET_DNS_ZONE", "DOMAIN") { }

        public string Domain { get; set; }

        public string DnsTemplate { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain", Domain },
                { "dns_template", DnsTemplate }
            };
        }
    }
}
