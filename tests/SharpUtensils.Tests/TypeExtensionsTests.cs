using System.Collections.Generic;
using Xunit;

namespace SharpUtensils.Tests
{
    public class TypeExtensionsTests
    {
        private class SomeGeneric<T>
        {
        }

        private class ExampleImpl : SomeGeneric<byte>
        {
        }

        [Fact]
        public void IsSubclassOfRawGeneric_SubClass_True()
        {
            Assert.True(typeof(ExampleImpl).IsSubclassOfRawGeneric(typeof(SomeGeneric<>)));
        }

        [Fact]
        public void IsSubclassOfRawGeneric_NonSubClass_False()
        {
            Assert.False(typeof(IList<byte>).IsSubclassOfRawGeneric(typeof(SomeGeneric<>)));
        }
    }
}
