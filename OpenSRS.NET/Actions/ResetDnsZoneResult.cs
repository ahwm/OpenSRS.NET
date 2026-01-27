using OpenSRS.NET.Models;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OpenSRS.NET.Actions
{
    public sealed class ResetDnsZoneResult
    {
        public DnsRecordSet RecordSet { get; set; } = new DnsRecordSet();

        [DataMember(Name = "nameservers_ok")]
        public bool NameserversOK { get; set; }

        public static ResetDnsZoneResult Parse(string text)
        {
            var result = new ResetDnsZoneResult();

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
            if (recordsArray != null)
            {
                foreach (var record in recordsArray.Descendants())
                {
                    switch (record.Attribute("key")?.Value)
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
            }

            var nameserversOkEl = doc.XPathSelectElement(@"//item[@key=""nameservers_ok""]");
            if (nameserversOkEl != null)
            {
                result.NameserversOK = int.Parse(nameserversOkEl.Value) == 1;
            }

            return result;
        }
    }
}
