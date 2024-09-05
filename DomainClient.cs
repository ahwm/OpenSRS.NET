using OpenSRS.NET.Actions;
using System.Threading.Tasks;

namespace OpenSRS.NET
{
    public partial class OpenSRSClient
    {
        public async Task<RegisterResult> RegisterAsync(RegisterRequest request) => RegisterResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<LookupResult> LookupAsync(LookupRequest request) => LookupResult.Parse(await SendAsync(request).ConfigureAwait(false));
        public async Task<NameSuggestResult> NameSuggestAsync(NameSuggestRequest request) => NameSuggestResult.Parse(await SendAsync(request).ConfigureAwait(false));
    }
}
