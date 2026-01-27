using OpenSRS.NET.Actions;
using System.Threading.Tasks;

namespace OpenSRS.NET
{
    public partial class OpenSRSClient
    {
        public async Task<RegisterResult> RegisterAsync(RegisterRequest request) => RegisterResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<LookupResult> LookupAsync(LookupRequest request) => LookupResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<NameSuggestResult> NameSuggestAsync(NameSuggestRequest request) => NameSuggestResult.Parse(await SendAsync(request).ConfigureAwait(false));

        public async Task<GetPriceResult> GetPriceAsync(GetPriceRequest request) => GetPriceResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<GetOrderInfoResult> GetOrderInfoAsync(GetOrderInfoRequest request) => GetOrderInfoResult.Parse(await SendAsync(request).ConfigureAwait(false));

        public async Task<CreateDnsZoneResult> CreateDnsZoneAsync(CreateDnsZoneRequest request) => CreateDnsZoneResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<GetDnsZoneResult> GetDnsZoneAsync(GetDnsZoneRequest request) => GetDnsZoneResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<SetDnsZoneResult> SetDnsZoneAsync(SetDnsZoneRequest request) => SetDnsZoneResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<ResetDnsZoneResult> ResetDnsZoneAsync(ResetDnsZoneRequest request) => ResetDnsZoneResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<ForceDnsNameserversResult> ForceDnsNameserversAsync(ForceDnsNameserversRequest request) => ForceDnsNameserversResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task DeleteDnsZoneAsync(DeleteDnsZoneRequest request) => await SendAsync(request).ConfigureAwait(false);
    }
}
