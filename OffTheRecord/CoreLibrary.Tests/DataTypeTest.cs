using FluentAssertions;
using NUnit.Framework;
using OffTheRecord.CoreLibrary.DataTypes;

namespace CoreLibrary.Tests
{
    [TestFixture]
    public class DataTypeTest
    {
        [Test]
        public void DataTypeOtrIntShouldWorkAsAnInt()
        {
            OtrInt int1 = 4;
            int1.Should().Be(4);
        }

        [Test]
        public void DataTypeOtrIntShouldSupportMaxValueOfUnassignedInt()
        {
            OtrInt int2 = uint.MaxValue;
            int2.Should().Be(uint.MaxValue);
        }

        [Test]
        public void DataTypeOtrIntShouldMatchOnComparison()
        {
            OtrInt int3 = 2;
            OtrInt int4 = 2;

            int3.Should().Be(int4);
        }

        [Test]
        public void DataTypeOtrByteShouldWorkAsAnByte()
        {
            OtrByte byte1 = 4;
            byte1.Should().Be(4);
        }

        [Test]
        public void DataTypeOtrByteShouldSupportMaxValueOfByte()
        {
            OtrByte byte2 = byte.MaxValue;
            byte2.Should().Be(byte.MaxValue);
        }

        [Test]
        public void DataTypeOtrByteShouldMatchOnComparison()
        {
            OtrByte byte3 = 2;
            OtrByte byte4 = 2;

            byte3.Should().Be(byte4);
        }

        [Test]
        public void DataTypeOtrShortShouldWorkAsAnShort()
        {
            OtrShort short1 = 4;
            short1.Should().Be(4);
        }

        [Test]
        public void DataTypeOtrShortShouldSupportMaxValueOfUnassignedShort()
        {
            OtrShort short2 = ushort.MaxValue;
            short2.Should().Be(ushort.MaxValue);
        }

        [Test]
        public void DataTypeOtrshortShouldMatchOnComparison()
        {
            OtrShort short3 = 2;
            OtrShort short4 = 2;

            short3.Should().Be(short4);
        }

        [Test]
        public void DataTypeNonceInitializesToZero()
        {
            var compare = new byte[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            OtrNonce nonce;
            nonce.Value.Should().BeEquivalentTo(compare);
        }

        [Test]
        public void DataTypeMpi()
        {
            // TODO: testing needs to be extended. 
            var mpi = new OtrMpi();
            mpi.Should().NotBeNull();
        }
    }
}
