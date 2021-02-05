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

        [Fact]
        public void AddParameter_Param_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("test", "another", "one")
                .AddParameter("test2", 2);
            Assert.Equal("?test=another,one&test2=2", b.ToString());
        }

        [Fact]
        public void AddParameter_ParamLast_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("test", "another", "one");
            Assert.Equal("?test=another,one", b.ToString());
        }

        [Fact]
        public void AddParameter_Decimal_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("decimal", decimal.One);
            Assert.Equal("?decimal=1", b.ToString());
        }

        [Fact]
        public void AddParameter_Double_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("double", 3.333);
            Assert.Equal("?double=3.333", b.ToString());
        }

        [Fact]
        public void AddParameter_Float_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("float", 3.333f);
            Assert.Equal("?float=3.333", b.ToString());
        }

        [Fact]
        public void AddParameter_Long_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("long", 333366642069L);
            Assert.Equal("?long=333366642069", b.ToString());
        }

        [Fact]
        public void AddParameter_Short_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("short", (short)3333);
            Assert.Equal("?short=3333", b.ToString());
        }


        [Fact]
        public void AddParameter_Byte_Success()
        {
            var b = new UrlBuilder()
                .AddParameter("byte", (byte)33);
            Assert.Equal("?byte=33", b.ToString());
        }

        [Fact]
        public void AppendPathSegment_ParamLast_Success()
        {
            var b = new UrlBuilder()
                .AppendPath("test")
                .AppendPathSegment("endpoint");
            Assert.Equal("test/endpoint", b.ToString());
        }
    }
}
