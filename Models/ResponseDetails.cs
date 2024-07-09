using System.Xml.Linq;

namespace OpenSRS.NET.Models
{
    public sealed class ResponseDetails
    {
        public string Protocol { get; set; } = "";

        public string Object { get; set; } = "";

        public string ResponseText { get; set; } = "";

        public string Action { get; set; } = "";

        public string ResponseCode { get; set; } = "";

        public bool IsSuccess { get; set; }

        public static ResponseDetails FromEl(XElement el)
        {
            var dic = ResponseHelper.ReadAssocAsDic(el);

            return new ResponseDetails
            {
                Protocol = dic["protocol"],
                Object = dic["object"],
                Action = dic["action"],
                ResponseCode = dic["response_code"],
                ResponseText = dic["response_text"],
                IsSuccess = dic["is_success"] == "1"
            };
        }
    }
}
