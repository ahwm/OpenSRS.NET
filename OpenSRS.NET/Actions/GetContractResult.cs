using OpenSRS.NET.Models;

namespace OpenSRS.NET.Actions
{
    public sealed class GetContractResult
    {
        public string Contract { get; set; }

        public static GetContractResult Parse(string responseText)
        {
            var attributes = ResponseHelper.ParseAttributes(responseText);

            return new GetContractResult
            {
                Contract = attributes["contract"]
            };
        }
    }
}
