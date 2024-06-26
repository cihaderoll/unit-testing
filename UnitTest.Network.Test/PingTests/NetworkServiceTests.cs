using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Network.DNS.Abstract;
using UnitTest.Network.Ping;

namespace UnitTest.Network.Test.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        private readonly IDNSService _dnsService;
        private readonly Mock<IDNSService> _dnsServiceMoq;

        public NetworkServiceTests()
        {
            //_dnsService = A.Fake<IDNSService>();
            _dnsServiceMoq = new Mock<IDNSService>();
            _dnsService = _dnsServiceMoq.Object;

            _networkService = new NetworkService(_dnsService);
        }

        [Fact]
        public void NetworkService_IDNSService_ShouldReturnString()
        {
            //Arrange
            //A.CallTo(() => _dnsService.GetDNS()).Returns("www.youtube.com");

            _dnsServiceMoq.Setup(o => o.GetDNS()).Returns("www.youtube.com");

            //Act
            var result = _networkService.GetDNS();

            //Assert
            result.Should().Be("www.youtube.com");
        }

        [Fact]
        public void NetworkService_Ping_ReturnsString()
        {
            //Arrange

            //Act
            var result = _networkService.Ping();
            //Assert
            result.Should().Be("Ping");
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 32, 37)]
        public void NetworkService_GetAge_ReturnsInt(int a, int b, int expected)
        {
            //Arrange

            //Act
            var result = _networkService.GetAge(a, b);
            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsDateTime()
        {
            //Arrange

            //Act
            var result = _networkService.LastPingDate();


            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_ShouldThrowExceptionIfHasZero()
        {
            var exception = Record.Exception(() => _networkService.Peek());

            exception.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public void NetworkService_ShouldContainHttps()
        {
            _networkService.AddNecessaryTypes();

            _networkService.NetworkTypes.Should().Contain("https");
        }

        [Fact]
        public void NetworkService_SholudReturnPingOptions()
        {
            //Arrange
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 100
            };

            //Act
            var result = _networkService.GetPingOptions();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void NetworkService_ShouldReturnPingOptionsAsNull()
        {
            //Arrange


            //Act
            var result = _networkService.GetPingOptions(true);

            //Assert
            result.Should().BeNull();
            //result.Should().BeOfType<PingOptions>();
        }

        [Fact]
        public void NetworkService_GetPingOptionList_ShouldReturnPingOptionList()
        {
            //Arrange
            var expected = new PingOptions
            {
                DontFragment = true,
                Ttl = 100
            };

            //Act
            var result = _networkService.GetPingOptionList();

            //Assert
            result.Should().ContainEquivalentOf(expected);
            result.Should().BeOfType<List<PingOptions>>();
        }
    }
}
