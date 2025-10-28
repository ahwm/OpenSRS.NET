using OpenSRS.NET.Actions;
using System.Threading.Tasks;

namespace OpenSRS.NET
{
    public partial class OpenSRSClient
    {
        public async Task<GetBalanceResult> GetBalanceAsync(GetBalanceRequest request) => GetBalanceResult.Parse(await SendAsync(request).ConfigureAwait(false));

        public async Task<GetContractResult> GetContractAsync(GetContractRequest request) => GetContractResult.Parse(await SendAsync(request).ConfigureAwait(false));
    }
}
