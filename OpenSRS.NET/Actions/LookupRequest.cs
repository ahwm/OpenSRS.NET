using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Actions
{
    public sealed class LookupRequest : OpenSRSRequest
    {
        public LookupRequest(string domain)
            : base("LOOKUP", "DOMAIN")
        {
            Domain = domain;
        }

        public string Domain { get; set; }

        public bool NoCache { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return new Dictionary<string, object> {
                { "domain", Domain },
                { "no_cache", NoCache ? "1" : null }
            };
#pragma warning restore CS8604 // Possible null reference argument.
        }
    }
}
