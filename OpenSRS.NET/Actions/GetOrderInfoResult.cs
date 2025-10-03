using OpenSRS.NET.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Actions
{
    public sealed class GetOrderInfoResult
    {
        public string AffiliateId { get; set; }

        public string ApplicationId { get; set; }

        public string ApplicationStatus { get; set; }

        public string Comments { get; set; }

        public string CompletedDate { get; set; }

        public decimal Cost { get; set; }

        public string Doamin { get; set; }

        public string EncodingType { get; set; }

        public int ExpiryYear { get; set; }

        public bool AutoRenew { get; set; }

        public bool LockDomain { get; set; }

        public static GetOrderInfoResult Parse(string text)
        {
            var attributes = ResponseHelper.ParseAttributes(text);

            return new GetOrderInfoResult();
        }
    }
}
