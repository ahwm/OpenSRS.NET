using OpenSRS.NET.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET
{
    public partial class OpenSRSClient
    {
        public async Task<GetBalanceResult> GetBalanceAsync(GetBalanceRequest request) => GetBalanceResult.Parse(await SendAsync(request).ConfigureAwait(false));
    }
}
