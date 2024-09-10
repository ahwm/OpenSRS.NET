using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using OpenSRS.NET.Actions;

namespace OpenSRS.NET
{
    public partial class OpenSRSClient
    {
        private static readonly Uri ProductionEndpoint = new Uri("https://rr-n1-tor.opensrs.net:55443");
        private static readonly Uri TestingEndpoint = new Uri("https://horizon.opensrs.net:55443");
#if !NETCORE
        private readonly string Key;
#else
        private string Key = "";
#endif
        private readonly HttpClient httpClient;

#if !NETCORE
        public OpenSRSClient(string key, string userName, bool test = false)
        {
            Key = key;
            httpClient = new HttpClient
            {
                BaseAddress = test ? TestingEndpoint : ProductionEndpoint
            };
            httpClient.DefaultRequestHeaders.Add("X-Username", userName);
            httpClient.DefaultRequestHeaders.Add("Keep-Alive", "false");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        }
#else
        public OpenSRSClient(HttpClient _httpClient)
        {
            httpClient = _httpClient;
            httpClient.DefaultRequestHeaders.Add("Keep-Alive", "false");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        }

        public void Configure(string key)
        {
            Key = key;
        }
#endif

        private async Task<string> SendAsync(OpenSRSRequest request)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>");
            sb.AppendLine(@"<!DOCTYPE OPS_envelope SYSTEM ""ops.dtd"">");
            sb.Append(request.ToXml().ToString());

            var msg = sb.ToString();
            
            var content = new StringContent(msg, Encoding.UTF8, "text/xml");
            content.Headers.Add("X-Signature", ComputeSignature(msg));

            using (var resp = await httpClient.PostAsync("/", content).ConfigureAwait(false))
            {
                return await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        private string ComputeSignature(string message)
        {
            // md5_hex(md5_hex($xml, $private_key),$private_key)
            return Extensions.CalculateMD5Hash(Extensions.CalculateMD5Hash(message + Key) + Key);
        }
    }
}