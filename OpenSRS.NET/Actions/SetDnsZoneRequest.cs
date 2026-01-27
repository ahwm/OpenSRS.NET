using OpenSRS.NET.Models;
using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class SetDnsZoneRequest : OpenSRSRequest
    {
        public SetDnsZoneRequest() : base("SET_DNS_ZONE", "DOMAIN") { }

        public string Domain { get; set; }

        public DnsRecordSet Records { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain", Domain },
                { "records", Records?.ToDtAssoc() }
            };
        }
    }
}
