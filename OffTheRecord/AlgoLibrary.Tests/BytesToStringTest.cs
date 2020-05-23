using FluentAssertions;
using NUnit.Framework;

namespace AlgoLibrary.Tests
{
    [TestFixture]
    public class BytesToStringTest
    {
        [Test]
        public void EncodingTest()
        {
            const string input = "Example string";

            var bytesToString = new BytesToString();

            var @bytes = bytesToString.Decode(input);
            var decoded = bytesToString.Encode(@bytes);

            input.Should().Be(decoded);
        }
    }
}
