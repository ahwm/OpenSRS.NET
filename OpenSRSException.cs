using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET
{
    public class OpenSRSException : Exception
    {
        public OpenSRSException(string message)
            : base(message) { }


        public string ResponseCode { get; set; } = "";
    }
}
