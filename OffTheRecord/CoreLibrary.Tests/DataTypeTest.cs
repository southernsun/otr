using FluentAssertions;
using NUnit.Framework;
using OffTheRecord.CoreLibrary.DataTypes;

namespace CoreLibrary.Tests
{
    [TestFixture]
    public class DataTypeTest
    {
        [Test]
        public void DataTypeOtrIntTests()
        {
            OtrInt int1 = 4;
            int1.Should().Be(4);

            OtrInt int2 = uint.MaxValue;
            int2.Should().Be(uint.MaxValue);
        }

        [Test]
        public void DataTypeOtrByteTests()
        {
            OtrByte byte1 = 4;
            byte1.Should().Be(4);

            OtrByte byte2 = byte.MaxValue;
            byte2.Should().Be(byte.MaxValue);
        }

        [Test]
        public void DataTypeOtrShortTests()
        {
            OtrShort short1 = 4;
            short1.Should().Be(4);

            OtrShort short2 = ushort.MaxValue;
            short2.Should().Be(ushort.MaxValue);
        }
    }
}
