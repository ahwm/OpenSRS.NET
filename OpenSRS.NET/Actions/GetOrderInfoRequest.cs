using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Actions
{
    public sealed class GetOrderInfoRequest : OpenSRSRequest
    {
        public GetOrderInfoRequest() : base("get_order_info", "DOMAIN")
        { }

        public long Id { get; set; }

        public override Dictionary<string, object> GetParameters()
        {
            return new Dictionary<string, object> {
                { "order_id", Id }
            };
        }
    }
}
