using System.Collections.Generic;

namespace OpenSRS.NET.Actions
{
    public sealed class GetContractRequest : OpenSRSRequest
    {
        public GetContractRequest() : base("GET_CONTRACT", "DOMAIN")
        { }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "type", "exhibit_a" }
            };
        }
    }
}
