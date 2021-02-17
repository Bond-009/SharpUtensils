using System.Net;
using SharpUtensils.Net;
using Xunit;

namespace SharpUtensils.Tests.Net
{
    public class IPAddressExtensionsTests

    {
        [Theory]
        [InlineData("224.0.0.0")]
        [InlineData("224.0.0.1")]
        [InlineData("224.0.0.2")]
        [InlineData("224.0.0.4")]
        [InlineData("224.0.0.5")]
        [InlineData("224.0.0.10")]
        [InlineData("224.0.0.21")]
        [InlineData("224.0.0.102")]
        [InlineData("224.0.0.251")]
        [InlineData("224.0.1.1")]
        [InlineData("224.0.1.22")]
        [InlineData("224.0.1.129")]
        [InlineData("239.255.255.250")]
        [InlineData("239.255.255.253")]
        [InlineData("ff02::1")]
        [InlineData("ff02::2")]
        [InlineData("ff02::5")]
        [InlineData("ff02::a")]
        [InlineData("ff02::16")]
        [InlineData("ff02::1:2")]
        [InlineData("ff05::1:3")]
        [InlineData("ff02::6b")]
        public void IsMulticast_Multicast_True(string ip)
        {
            Assert.True(IPAddress.Parse(ip).IsMultiCast());
        }

        [Theory]
        [InlineData("192.0.2.128")]
        [InlineData("::1")]
        [InlineData("2001:db8::ff00:42:8329")]
        [InlineData("::ffff:192.0.2.128")]
        [InlineData("64:ff9b::192.0.2.128")]
        public void IsMulticast_NotMulticast_False(string ip)
        {
            Assert.False(IPAddress.Parse(ip).IsMultiCast());
        }

        [Theory]
        [InlineData("192.0.2.128")]
        [InlineData("224.0.0.0")]
        [InlineData("239.255.255.253")]
        public void IsIPv4_IPv4_True(string ip)
        {
            Assert.True(IPAddress.Parse(ip).IsIPv4());
        }

        [Theory]
        [InlineData("::1")]
        [InlineData("2001:db8::ff00:42:8329")]
        [InlineData("::ffff:192.0.2.128")]
        [InlineData("64:ff9b::192.0.2.128")]
        public void IsIPv4_IPv6_False(string ip)
        {
            Assert.False(IPAddress.Parse(ip).IsIPv4());
        }

        [Theory]
        [InlineData("::1")]
        [InlineData("2001:db8::ff00:42:8329")]
        [InlineData("::ffff:192.0.2.128")]
        [InlineData("64:ff9b::192.0.2.128")]
        public void IsIPv6_IPv6_True(string ip)
        {
            Assert.True(IPAddress.Parse(ip).IsIPv6());
        }

        [Theory]
        [InlineData("192.0.2.128")]
        [InlineData("224.0.0.0")]
        [InlineData("239.255.255.253")]
        public void IsIPv6_IPv4_False(string ip)
        {
            Assert.False(IPAddress.Parse(ip).IsIPv6());
        }
    }
}
