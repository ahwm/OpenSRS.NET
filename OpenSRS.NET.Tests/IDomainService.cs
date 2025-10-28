using OpenSRS.NET.Actions;

namespace OpenSRS.NET.Tests
{
    public interface IDomainService
    {
        public Task<(bool status, List<string> suggestions)> CheckAvailable(string domain);

        public Task Register(string domain);

        public Task<GetBalanceResult> GetBalance();

        public Task<string> GetContract();
    }
}
