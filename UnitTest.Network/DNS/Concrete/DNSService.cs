using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Network.DNS.Abstract;

namespace UnitTest.Network.DNS.Concrete
{
    public class DNSService : IDNSService
    {
        public string GetDNS()
        {
            return "www.google.com";
        }
    }
}
