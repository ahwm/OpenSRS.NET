using OpenSRS.NET.Models;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenSRS.NET.Actions
{
    public sealed class ForceDnsNameserversResult
    {
        public static ForceDnsNameserversResult Parse(string text)
        {
            var result = new ForceDnsNameserversResult();

            var doc = XDocument.Parse(text);

            var itemEl = doc.XPathSelectElement(@"/OPS_envelope/body/data_block/dt_assoc");

            var response = ResponseDetails.FromEl(itemEl);
            if (!response.IsSuccess)
            {
                throw new OpenSRSException(response.ResponseText)
                {
                    ResponseCode = response.ResponseCode
                };
            }

            return result;
        }
    }
}
