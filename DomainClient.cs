using OpenSRS.NET.Actions;
using System.Threading.Tasks;

namespace OpenSRS.NET
{
    public partial class OpenSRSClient
    {
        public async Task<RegisterResult> RegisterAsync(RegisterRequest request) => RegisterResult.Parse(await SendAsync(request).ConfigureAwait(false));
    }
}
