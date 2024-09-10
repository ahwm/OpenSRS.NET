using OpenSRS.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Actions
{
    public class LookupResult
    {
        public DomainStatus Status { get; set; }

        public bool HasClaim { get; set; }

#if NETCORE
        public string? Reason { get; set; }
#else
        public string Reason { get; set; }
#endif

        public static LookupResult Parse(string text)
        {
            var attributes = ResponseHelper.ParseAttributes(text);

            try
            {
                return new LookupResult
                {
                    Status = (DomainStatus)Enum.Parse(typeof(DomainStatus), attributes["status"], ignoreCase: true),
                    HasClaim = attributes.TryGetValue("has_claim", out var claim) && claim == "1",
                    Reason = attributes.TryGetValue("reason", out var reason) ? reason : null
                };
            }
            catch (Exception ex)
            {
                if (attributes["is_success"] != "1")
                {
                    throw new OpenSRSException(attributes["response_text"])
                    {
                        ResponseCode = attributes["response_code"]
                    };
                }
                throw new Exception("Unknown error", ex);
            }
        }
    }
}
