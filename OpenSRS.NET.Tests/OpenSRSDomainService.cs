using OpenSRS.NET.Actions;
using OpenSRS.NET.Models;

namespace OpenSRS.NET.Tests
{
    public sealed class OpenSRSDomainService(OpenSRSClient openSRS) : IDomainService
    {
        public async Task<(bool status, List<string> suggestions)> CheckAvailable(string domain)
        {
            bool status = true;
            List<string> suggestions = [];

            var result = await openSRS.LookupAsync(new LookupRequest(domain));
            status = result.Status == DomainStatus.Available;

            var suggestResponse = await openSRS.NameSuggestAsync(new NameSuggestRequest { Query = domain, Tlds = [".com",".net",".us",".org",".info"] });
            suggestions = [.. suggestResponse.Suggestions.Where(x => x.Status == "available").Select(x => x.Domain)];

            return (status, suggestions);
        }

        public async Task Register(string domain)
        {
            var result = await openSRS.RegisterAsync(new RegisterRequest { Domain = domain, Period = 1 });
            if (result != null)
            {

            }
        }

        public async Task<GetBalanceResult> GetBalance()
        {
            var result = await openSRS.GetBalanceAsync(new GetBalanceRequest());
            return result;
        }

        public async Task<string> GetContract()
        {
            var result = await openSRS.GetContractAsync(new GetContractRequest());
            return result.Contract;
        }
    }
}
