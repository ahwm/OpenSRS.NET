using OpenSRS.NET.Models;
using System;
using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class GetPriceRequest : OpenSRSRequest
    {
        public GetPriceRequest(string domain, int period = 1) : base("GET_PRICE", "DOMAIN")
        {
            this.Domain = domain ?? throw new ArgumentNullException(nameof(domain));
            this.Period = period;
            this.RegistrationType = RegistrationType.New;
        }

        public string Domain { get; set; }

        public int Period { get; set; }

        /// <summary>
        /// reg_type (NEW, Renewal)
        /// </summary>
        public RegistrationType RegistrationType { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "domain", Domain },
                { "period", Period },
                { "reg_type", RegistrationType.ToString().ToLower() }
            };
        }
    }
}
