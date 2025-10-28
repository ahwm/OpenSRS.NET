using OpenSRS.NET.Models;
using System.Globalization;

namespace OpenSRS.NET.Actions
{
    public sealed class GetBalanceResult
    {
        public decimal Balance { get; set; }

        public decimal HoldBalance { get; set; }

        public static GetBalanceResult Parse(string responseText)
        {
            var attributes = ResponseHelper.ParseAttributes(responseText);

            return new GetBalanceResult
            {
                Balance = decimal.Parse(attributes["balance"], CultureInfo.InvariantCulture),
                HoldBalance = decimal.Parse(attributes["hold_balance"], CultureInfo.InvariantCulture)
            };
        }
    }
}
