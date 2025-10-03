using OpenSRS.NET.Models;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenSRS.NET.Actions
{
    public sealed class RegisterResult
    {
        public long Id { get; set; }

        [DataMember(Name = "admin_email")]
        public string AdminEmail { get; set; } = "";

        [DataMember(Name = "async_reason")]
        public string AsyncReason { get; set; } = "";
        /// <summary>
        /// The registration text returned by the registry.
        /// </summary>
        [DataMember(Name = "registration_text")]
        public string RegistrationText { get; set; } = "";

        /// <summary>
        /// The registration code returned by the registry.
        /// </summary>
        [DataMember(Name = "registration_code")]
        public int RegistrationCode { get; set; }

        [DataMember(Name = "queue_request_id")]
        public string QueueRequestId { get; set; } = "";

        [DataMember(Name = "transfer_id")]
        public string TransferId { get; set; } = "";

        [DataMember(Name = "whois_privacy_state")]
        public string WhoisPrivacyState { get; set; } = "";

        public string Error { get; set; } = "";

        public static RegisterResult Parse(string text)
        {
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

            var attributes = ResponseHelper.GetAttributesAsDictionary(doc);

            return new RegisterResult
            {
                Id = long.Parse(attributes.GetValueOrDefault("id"), CultureInfo.InvariantCulture), // the order id
                AdminEmail = attributes.GetValueOrDefault("admin_email"),
                AsyncReason = attributes.GetValueOrDefault("async_reason"),
                RegistrationCode = attributes.TryGetValue("registration_code", out var registrationCode) ? int.Parse(registrationCode, CultureInfo.InvariantCulture) : 0,
                RegistrationText = attributes.GetValueOrDefault("registration_text"),
                WhoisPrivacyState = attributes.GetValueOrDefault("whois_privacy_state"),
                Error = attributes.GetValueOrDefault("error")
            };
        }
    }
}
