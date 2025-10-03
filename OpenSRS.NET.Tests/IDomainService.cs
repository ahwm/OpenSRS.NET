using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSRS.NET.Tests
{
    public interface IDomainService
    {
        public Task<(bool status, List<string> suggestions)> CheckAvailable(string domain);

        public Task Register(string domain);
    }
}
