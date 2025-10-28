using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class LookupRequest : OpenSRSRequest
    {
        public LookupRequest(string domain) : base("LOOKUP", "DOMAIN")
        {
            Domain = domain;
        }

        public string Domain { get; set; }

        public bool NoCache { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain", Domain },
                { "no_cache", NoCache ? "1" : null }
            };
        }
    }
}
