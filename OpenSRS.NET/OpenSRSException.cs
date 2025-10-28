using System;

namespace OpenSRS.NET
{
    public class OpenSRSException : Exception
    {
        public OpenSRSException(string message) : base(message) { }

        public string ResponseCode { get; set; } = "";
    }
}
