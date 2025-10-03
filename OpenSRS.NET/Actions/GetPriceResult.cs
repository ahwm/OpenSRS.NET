using OpenSRS.NET.Models;
using System.Globalization;

namespace OpenSRS.NET.Actions
{
    public sealed class GetPriceResult
    {
        public GetPriceResult(decimal price)
        {
            Price = price;
        }

        public decimal Price { get; }

        public static GetPriceResult Parse(string text)
        {
            var attributes = ResponseHelper.ParseAttributes(text);

            return new GetPriceResult(
                price: decimal.Parse(attributes["price"], CultureInfo.InvariantCulture)
            );
        }
    }
}
