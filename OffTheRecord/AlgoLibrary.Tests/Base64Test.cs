using FluentAssertions;
using NUnit.Framework;

namespace AlgoLibrary.Tests
{
    [TestFixture]
    public class Base64Test
    {
        [Test]
        public void EncodingTest()
        {
            const string input = "Example string";

            var base64 = new Base64();
            var bytesToString = new BytesToString();

            var data = bytesToString.Decode(input);

            var encodedResult = base64.Encode(data);
            var decodedBytes = base64.Decode(encodedResult);

            var decodedResult = bytesToString.Encode(decodedBytes);

            data.Should().BeEquivalentTo(decodedBytes);
            input.Should().Be(decodedResult);
        }
    }
}