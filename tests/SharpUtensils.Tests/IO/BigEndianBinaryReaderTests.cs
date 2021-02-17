using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;
using SharpUtensils.IO;
using Xunit;

namespace SharpUtensils.Tests.IO
{
    public class BigEndianBinaryReaderTests

    {
        [Fact]
        public void ReadUInt32_Disposed_ThrowsObjectDisposedException()
        {
            using var ms = new MemoryStream();
            var reader = new BigEndianBinaryReader(ms);
            reader.Dispose();
            Assert.Throws<ObjectDisposedException>(() => reader.ReadUInt32());
        }

        [Fact]
        public void ReadUInt32_EOF_ThrowsEndOfStreamException()
        {
            using var ms = new MemoryStream();
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Throws<EndOfStreamException>(() => reader.ReadUInt32());
        }

        [Fact]
        public void ReadUInt32_EOF2_ThrowsEndOfStreamException()
        {
            using var ms = new MemoryStream(new byte[] { 0xff, 0xff });
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Throws<EndOfStreamException>(() => reader.ReadUInt32());
        }

        [Fact]
        public void Dispose_LeaveOpenTrue_DoesntThrow()
        {
            using var ms = new MemoryStream(new byte[] { 0xff });
            var reader = new BigEndianBinaryReader(ms, Encoding.UTF8, true);
            reader.Dispose();
            ms.ReadByte();
        }

        [Fact]
        public void Dispose_LeaveOpenFalse_ThrowsObjectDisposedException()
        {
            using var ms = new MemoryStream(new byte[] { 0xff });
            var reader = new BigEndianBinaryReader(ms, Encoding.UTF8);
            reader.Dispose();
            Assert.Throws<ObjectDisposedException>(() => ms.ReadByte());
        }

        [Fact]
        public void Dispose_DoubleDispose_DoesntThrow()
        {
            using var ms = new MemoryStream();
            var reader = new BigEndianBinaryReader(ms);
            reader.Dispose();
            reader.Dispose();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MinValue)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(128)]
        [InlineData(byte.MaxValue)]
        [InlineData(256)]
        [InlineData(short.MinValue)]
        [InlineData(short.MaxValue)]
        public void ReadInt16_Int16_Expected(short expected)
        {
            var buffer = new byte[2];
            BinaryPrimitives.WriteInt16BigEndian(buffer, expected);
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadInt16());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(128)]
        [InlineData(byte.MaxValue)]
        [InlineData(256)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        public void ReadUInt16_UInt16_Expected(ushort expected)
        {
            var buffer = new byte[2];
            BinaryPrimitives.WriteUInt16BigEndian(buffer, expected);
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadUInt16());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MinValue)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(128)]
        [InlineData(byte.MaxValue)]
        [InlineData(256)]
        [InlineData(short.MinValue)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void ReadInt32_Int32_Expected(int expected)
        {
            var buffer = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(buffer, expected);
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadInt32());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(128)]
        [InlineData(byte.MaxValue)]
        [InlineData(256)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        [InlineData(int.MaxValue)]
        [InlineData(uint.MaxValue)]
        public void ReadUInt32_UInt32_Expected(uint expected)
        {
            var buffer = new byte[4];
            BinaryPrimitives.WriteUInt32BigEndian(buffer, expected);
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadUInt32());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MinValue)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(128)]
        [InlineData(byte.MaxValue)]
        [InlineData(256)]
        [InlineData(short.MinValue)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(long.MinValue)]
        [InlineData(long.MaxValue)]
        public void ReadInt64_Int64_Expected(long expected)
        {
            var buffer = new byte[8];
            BinaryPrimitives.WriteInt64BigEndian(buffer, expected);
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadInt64());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(sbyte.MaxValue)]
        [InlineData(128)]
        [InlineData(byte.MaxValue)]
        [InlineData(256)]
        [InlineData(short.MaxValue)]
        [InlineData(ushort.MaxValue)]
        [InlineData(int.MaxValue)]
        [InlineData(uint.MaxValue)]
        [InlineData(ulong.MaxValue)]
        public void ReadUInt64_UInt64_Expected(ulong expected)
        {
            var buffer = new byte[8];
            BinaryPrimitives.WriteUInt64BigEndian(buffer, expected);
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadUInt64());
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(1f)]
        [InlineData(float.MinValue)]
        [InlineData(float.MaxValue)]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.Epsilon)]
        [InlineData(float.NaN)]
        public void ReadSingle_Single_Expected(float expected)
        {
            var buffer = new byte[4];
            BinaryPrimitives.WriteInt32BigEndian(buffer, BitConverter.SingleToInt32Bits(expected));
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadSingle());
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(1f)]
        [InlineData(double.MinValue)]
        [InlineData(double.MaxValue)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.Epsilon)]
        [InlineData(double.NaN)]
        public void ReadDouble_Double_Expected(double expected)
        {
            var buffer = new byte[8];
            BinaryPrimitives.WriteInt64BigEndian(buffer, BitConverter.DoubleToInt64Bits(expected));
            using var ms = new MemoryStream(buffer);
            using var reader = new BigEndianBinaryReader(ms);
            Assert.Equal(expected, reader.ReadDouble());
        }
    }
}
