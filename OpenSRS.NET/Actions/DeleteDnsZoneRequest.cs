using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class DeleteDnsZoneRequest : OpenSRSRequest
    {
        public DeleteDnsZoneRequest() : base("DELETE_DNS_ZONE", "DOMAIN") { }

        public string Domain { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain", Domain }
            };
        }
    }
}
