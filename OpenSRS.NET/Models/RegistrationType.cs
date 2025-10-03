using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Models
{
    public enum RegistrationType : byte
    {
        New = 1,
        Renewal = 2,
        Transfer = 3,
        Landrush = 4,
        Sunrise = 5
    }
}
