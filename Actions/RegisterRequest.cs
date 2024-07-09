using OpenSRS.NET.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OpenSRS.NET.Actions
{
    public sealed class RegisterRequest : OpenSRSRequest
    {
        public RegisterRequest()
            : base("SW_REGISTER", "DOMAIN")
        {
            Period = 1;
            RegistrationType = RegistrationType.New;
            ProcessImmediately = true;
            LockDomain = true;
        }

        public bool ProcessImmediately { get; set; }

        public string Domain { get; set; } = "";

        /// <summary>
        /// The period, in years
        /// </summary>
        [Range(1, 10)]
        public int Period { get; set; }

        [DataMember(Name = "reg_type")]
        public RegistrationType RegistrationType { get; set; }

        public bool AutoRenew { get; set; }

        public bool LockDomain { get; set; }

        public string UserName { get; set; } = "";

        // A-Z, a-z, 0-9, ! @\$^,.~|=-+_{}#"
        [MinLength(10), MaxLength(20)]
        public string Password { get; set; } = "";

        public string DnsTemplate { get; set; } = "";

        public ContactSet Contacts { get; set; } = new ContactSet();

        [DataMember(Name = "custom_nameservers")]
        public bool CustomNameservers { get; set; }

        [DataMember(Name = "f_whois_privacy")]
        public bool WhoisPrivacy { get; set; }

        [DataMember(Name = "custom_tech_contact")]
        public bool CustomTechContact { get; set; }

        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        // f_lock_domain

        // affiliate_id
        // comments

        public override Dictionary<string, object> GetParameters()
        {
            var data = new Dictionary<string, object> {
                { "auto_renew",          AutoRenew ? "1" : "0" },
                { "contact_set",         Contacts.ToAssocEl() },
                { "custom_nameservers",  CustomNameservers ? "1" : "0" },
                { "custom_tech_contact", CustomTechContact ? "1" : "0" },
                { "f_lock_domain",       LockDomain ? "1" : "0" },
                { "domain",              Domain },
                { "handle",              ProcessImmediately ? "process" : "save" },
                { "period",              Period },
                { "reg_username",        UserName },
                { "reg_password",        Password },
                { "reg_type",            RegistrationType.ToString().ToLower() },
                { "f_whois_privacy",     WhoisPrivacy ? "1" : "0" }
            };

            foreach (var property in Properties)
                data.Add(property.Key, property.Value);

            if (DnsTemplate != null) data["dns_template"] = DnsTemplate;

            return data;
        }
    }
}
