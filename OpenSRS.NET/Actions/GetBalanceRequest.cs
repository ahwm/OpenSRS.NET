namespace OpenSRS.NET.Actions
{
    public sealed class GetBalanceRequest : OpenSRSRequest
    {
        public GetBalanceRequest() : base("GET_BALANCE", "BALANCE") { }
    }
}
