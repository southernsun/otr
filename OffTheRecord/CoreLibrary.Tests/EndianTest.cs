using System;
using FluentAssertions;
using NUnit.Framework;
using OffTheRecord.CoreLibrary.Classes;

namespace CoreLibrary.Tests
{
    [TestFixture]
    public class EndianTest
    {
        [Test]
        public void IsLittleEndianTest()
        {
            const int value = 254;

            var valueAsBytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
            {
                BitConverter.ToString(valueAsBytes).Should().Be("FE-00-00-00");
            }
            else
            {
                BitConverter.ToString(valueAsBytes).Should().Be("00-00-00-FE");
            }
        }

        [Test]
        public void ToLittleEndianTest()
        {
            const int value = 254;
            var valueAsBytes = BitConverter.GetBytes(value);

            var endianUtilities = new EndianUtilities();
            var result = endianUtilities.ToLittleEndian(valueAsBytes);

            BitConverter.ToString(result).Should().Be("FE-00-00-00");
        }

        [Test]
        public void ToBigEndianTest()
        {
            const int value = 254;
            var valueAsBytes = BitConverter.GetBytes(value);

            var endianUtilities = new EndianUtilities();
            var result = endianUtilities.ToBigEndian(valueAsBytes);

            BitConverter.ToString(result).Should().Be("00-00-00-FE");
        }
    }
}
