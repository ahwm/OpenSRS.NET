using OpenSRS.NET.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenSRS.NET.Actions
{
    public sealed class CreateDnsZoneResult
    {
        public DnsRecordSet RecordSet { get; set; } = new DnsRecordSet();

        [DataMember(Name = "nameservers_ok")]
        public bool NameserversOK { get; set; }

        public static CreateDnsZoneResult Parse(string text)
        {
            var result = new CreateDnsZoneResult();

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

            XElement recordsArray = doc.XPathSelectElement(@"//item[@key=""records""]/dt_assoc");
            foreach (var record in recordsArray.Descendants())
            {
                switch (record.Attribute("key").Value)
                {
                    case "A":
                        var AItems = ResponseHelper.ReadArray(record.Descendants("dt_array").First());
                        foreach (var AItem in AItems)
                        {
                            result.RecordSet.A.Add(new ARecord { Address = System.Net.IPAddress.Parse(AItem["ip_address"]), Subdomain = AItem["subdomain"] });
                        }
                        break;
                    case "AAAA":
                        var AAAAItems = ResponseHelper.ReadArray(record.Descendants("dt_array").First());
                        foreach (var AItem in AAAAItems)
                        {
                            result.RecordSet.AAAA.Add(new AAAARecord { Address = System.Net.IPAddress.Parse(AItem["ip_address"]), Subdomain = AItem["subdomain"] });
                        }
                        break;
                    case "CNAME":
                        var CNItems = ResponseHelper.ReadArray(record.Descendants("dt_array").First());
                        foreach (var CNItem in CNItems)
                        {
                            result.RecordSet.CNAME.Add(new CNAMERecord { HostName = CNItem["hostname"], Subdomain = CNItem["subdomain"] });
                        }
                        break;
                    case "MX":
                        var MXItems = ResponseHelper.ReadArray(record.Descendants("dt_array").First());
                        foreach (var MXItem in MXItems)
                        {
                            result.RecordSet.MX.Add(new MXRecord { Priority = int.Parse(MXItem["priority"]), HostName = MXItem["hostname"], Subdomain = MXItem["subdomain"] });
                        }
                        break;
                    case "TXT":
                        var TXTItems = ResponseHelper.ReadArray(record.Descendants("dt_array").First());
                        foreach (var TXTItem in TXTItems)
                        {
                            result.RecordSet.TXT.Add(new TXTRecord { Text = TXTItem["text"], Subdomain = TXTItem["subdomain"] });
                        }
                        break;
                    case "SRV":
                        var SRVItems = ResponseHelper.ReadArray(record.Descendants("dt_array").First());
                        foreach (var SRVItem in SRVItems)
                        {
                            result.RecordSet.SRV.Add(new SRVRecord { HostName = SRVItem["hostname"], Priority = int.Parse(SRVItem["priority"]), Port = int.Parse(SRVItem["port"]), Weight = int.Parse(SRVItem["weight"]), Subdomain = SRVItem["subdomain"] });
                        }
                        break;
                    default:
                        break;
                }
            }
            result.NameserversOK = int.Parse(doc.XPathSelectElement(@"//item[@key""nameservers_ok""]").Value) == 1;

            return result;
        }
    }
}
/*
 <?xml version='1.0' encoding="UTF-8" standalone="no"?>
<!DOCTYPE OPS_envelope SYSTEM "ops.dtd">
<OPS_envelope>
    <header>
        <version>0.9</version>
    </header>
    <body>
        <data_block>
            <dt_assoc>
                <item key="protocol">XCP</item>
                <item key="action">REPLY</item>
                <item key="object">DOMAIN</item>
                <item key="is_success">1</item>
                <item key="response_text">Command Successful</item>
                <item key="response_code">200</item>
                <item key="attributes">
                    <dt_assoc>
                        <item key="records">
                            <dt_assoc>
                                <item key="A">
                                    <dt_array>
                                        <item key="0">
                                            <dt_assoc>
                                                <item key="subdomain"></item>
                                                <item key="ip_address">17.16.156.5</item>
                                            </dt_assoc>
                                        </item>
                                    </dt_array>
                                </item>
                                <item key="MX">
                                    <dt_array>
                                        <item key="0">
                                            <dt_assoc>
                                                <item key="priority">10</item>
                                                <item key="subdomain">www</item>
                                                <item key="hostname">example.org</item>
                                            </dt_assoc>
                                        </item>
                                        <item key="1">
                                            <dt_assoc>
                                                <item key="priority">1</item>
                                                <item key="subdomain"></item>
                                                <item key="hostname">mx.cust.aug18dnstest1.com.hostedemail.com</item>
                                            </dt_assoc>
                                        </item>
                                    </dt_array>
                                </item>
                                <item key="SRV">
                                    <dt_array>
                                        <item key="0">
                                            <dt_assoc>
                                                <item key="priority">1</item>
                                                <item key="weight">3</item>
                                                <item key="subdomain">w3</item>
                                                <item key="hostname">yummynames.com</item>
                                                <item key="port">81</item>
                                            </dt_assoc>
                                        </item>
                                    </dt_array>
                                </item>
                            </dt_assoc>
                        </item>
                        <item key="nameservers_ok">0</item>
                    </dt_assoc>
                </item>
            </dt_assoc>
        </data_block>
    </body>
</OPS_envelope>
 */