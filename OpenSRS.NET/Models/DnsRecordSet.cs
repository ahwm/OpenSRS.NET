using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpenSRS.NET.Models
{
    public sealed class DnsRecordSet
    {
        private readonly List<ARecord> a = new List<ARecord>();
        private readonly List<AAAARecord> aaaa = new List<AAAARecord>();
        private readonly List<CNAMERecord> cname = new List<CNAMERecord>();
        private readonly List<MXRecord> mx = new List<MXRecord>();
        private readonly List<SRVRecord> srv = new List<SRVRecord>();
        private readonly List<TXTRecord> txt = new List<TXTRecord>();

        public IList<ARecord> A => a;

        public IList<AAAARecord> AAAA => aaaa;

        public IList<CNAMERecord> CNAME => cname;

        public IList<MXRecord> MX => mx;

        public IList<SRVRecord> SRV => srv;

        public IList<TXTRecord> TXT => txt;

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                A = a.Count > 0 ? Extensions.ToDtArray(a) : null,
                AAAA = aaaa.Count > 0 ? Extensions.ToDtArray(aaaa) : null,
                CNAME = cname.Count > 0 ? Extensions.ToDtArray(cname) : null,
                MX = mx.Count > 0 ? Extensions.ToDtArray(mx) : null,
                SVR = srv.Count > 0 ? Extensions.ToDtArray(srv) : null,
                TXT = txt.Count > 0 ? Extensions.ToDtArray(txt) : null,
            });

            /*
			<item key="A">
				<dt_array> 
					<item key="0">
						<dt_assoc>
							<item key="9.36.11.25"></item>
							<item key="subdomain">wwwip_address</item>
						</dt_assoc>
					</item>
				</dt_array>
			</item>
			*/
        }
    }

    public sealed class ARecord : IDtEl
    {
        public IPAddress Address { get; set; }
        public string Subdomain { get; set; }

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                ip_address = this.Address.ToString(),
                subdomain = this.Subdomain
            });
        }
    }

    public sealed class AAAARecord : IDtEl
    {
        public IPAddress Address { get; set; }
        public string Subdomain { get; set; }

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                ipv6_address = this.Address.ToString(),
                subdomain = this.Subdomain
            });
        }
    }

    public sealed class CNAMERecord : IDtEl
    {
        /// <summary>
        /// The FQDN of the domain that you want to access.
        /// </summary>
        public string HostName { get; set; }

        public string Subdomain { get; set; }

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                hostname = this.HostName,
                subdomain = this.Subdomain,
            });
        }
    }

    public sealed class MXRecord : IDtEl
    {
        public int Priority { get; set; }

        public string HostName { get; set; }

        public string Subdomain { get; set; }

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                priority = this.Priority,
                hostname = this.HostName,
                subdomain = this.Subdomain
            });
        }
    }

    public sealed class SRVRecord : IDtEl
    {
        public int Priority { get; set; }

        public int Weight { get; set; }

        public string Subdomain { get; set; }

        /// <summary>
        /// The FQDN of the domain that you want to access.
        /// </summary>
        public string HostName { get; set; }

        public int Port { get; set; }

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                priority = this.Priority,
                weight = this.Weight,
                subdomain = this.Subdomain,
                hostname = this.HostName,
                port = this.Port
            });
        }

        /*
		priority:		The priority of the target host, lower value means more preferred.
		weight:			A relative weight for records with the same priority.
		subdomain:		The third level of the domain name, such as www or ftp.
		hostname:		The FQDN of the domain that you want to access.
		port:			The TCP or UDP port on which the service is to be found.
		*/
    }

    public sealed class TXTRecord : IDtEl
    {
        public string Text { get; set; }
        public string Subdomain { get; set; }

        public XElement ToDtAssoc()
        {
            return Extensions.ToDtAssoc(new
            {
                text = this.Text,
                subdomain = this.Subdomain
            });
        }
    }
}
