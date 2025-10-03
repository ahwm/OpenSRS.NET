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

            try
            {
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
            catch
            {
                ResponseDetails details = new ResponseDetails();
                if (dic.ContainsKey("protocol"))
                    details.Protocol = dic["protocol"];
                if (dic.ContainsKey("object"))
                    details.Object = dic["object"];
                if (dic.ContainsKey("action"))
                    details.Action = dic["action"];
                if (dic.ContainsKey("response_code"))
                    details.ResponseCode = dic["response_code"];
                if (dic.ContainsKey("response_text"))
                    details.ResponseText = dic["response_text"];
                if (dic.ContainsKey("is_success"))
                    details.IsSuccess = dic["is_success"] == "1";

                return details;
            }
        }
    }
}
