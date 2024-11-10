using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Actions
{
    public sealed class GetBalanceRequest : OpenSRSRequest
    {
        public GetBalanceRequest() : base("GET_BALANCE", "BALANCE") { }
    }
}
