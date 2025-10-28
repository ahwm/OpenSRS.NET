using OpenSRS.NET.Models;
using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class CreateDnsZoneRequest : OpenSRSRequest
    {
        public CreateDnsZoneRequest() : base("CREATE_DNS_ZONE", "DOMAIN") { }

        public string Domain { get; set; }

        public string DnsTemplate { get; set; }

        public DnsRecordSet Records { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain",         Domain },
                { "dns_template",   DnsTemplate },
                { "records",        Records?.ToDtAssoc() }
            };
        }
    }
}
