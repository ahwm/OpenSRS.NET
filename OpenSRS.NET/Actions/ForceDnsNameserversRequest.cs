using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class ForceDnsNameserversRequest : OpenSRSRequest
    {
        public ForceDnsNameserversRequest() : base("FORCE_DNS_NAMESERVERS", "DOMAIN") { }

        public string Domain { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain", Domain }
            };
        }
    }
}
