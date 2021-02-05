using Xunit;

namespace SharpUtensils.Tests
{
    public class UrlBuilderTests
    {
        [Fact]
        public void EmptyTest()
        {
            var b = new UrlBuilder();
            Assert.Equal(string.Empty, b.ToString());
        }

        [Fact]
        public void QueryStringTest()
        {
            var b = new UrlBuilder().AddParameter("test", "another");
            Assert.Equal("?test=another", b.ToString());
        }

        [Fact]
        public void QueryIntTest()
        {
            var b = new UrlBuilder().AddParameter("test", 1);
            Assert.Equal("?test=1", b.ToString());
        }

        [Fact]
        public void UrlTest()
        {
            var b = new UrlBuilder("test");
            Assert.Equal("test", b.ToString());
        }

        [Fact]
        public void UrlQueryStringTest()
        {
            var b = new UrlBuilder("base").AddParameter("test", "another");
            Assert.Equal("base?test=another", b.ToString());
        }

        [Fact]
        public void UrlAppendStringTest()
        {
            var b = new UrlBuilder()
                .AddParameter("test", "another")
                .AppendPath("base")
                .AppendPath("path");
            Assert.Equal("basepath?test=another", b.ToString());
        }
    }
}
