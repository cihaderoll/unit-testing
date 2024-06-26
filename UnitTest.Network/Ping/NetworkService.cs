using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Network.DNS.Abstract;

namespace UnitTest.Network.Ping
{
    public class NetworkService
    {
        private readonly IDNSService _dnsService;
        public List<string> NetworkTypes { get; set; }

        public NetworkService(IDNSService dnsService)
        {
            NetworkTypes = new List<string>();
            _dnsService = dnsService;
        }

        public void AddNecessaryTypes() => NetworkTypes = new List<string> { "http", "https", "tcp", "udp" };

        public void AddNetworkType(string type) => NetworkTypes.Add(type);

        public string GetDNS() => _dnsService.GetDNS();

        public string Peek()
        {
            if (NetworkTypes.Count == 0)
                throw new InvalidOperationException();

            var data = NetworkTypes.Last();

            NetworkTypes.RemoveAt(NetworkTypes.Count - 1);

            return data;
        }

        public string Ping()
        {
            return "Ping";
        }

        public int GetAge(int birthYear, int currentYear)
        {
            return currentYear + birthYear;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions? GetPingOptions(bool isNull = false)
        {
            if (isNull)
                return default;

            return new PingOptions
            {
                DontFragment = true,
                Ttl = 100
            };
        }

        public IEnumerable<PingOptions> GetPingOptionList()
        {
            return new List<PingOptions>
            {
                new PingOptions
                {
                    DontFragment = true,
                    Ttl = 100
                },

                new PingOptions
                {
                    DontFragment = true,
                    Ttl = 200
                },

                new PingOptions
                {
                    DontFragment = false,
                    Ttl = 300
                },
            };
        }

    }
}
