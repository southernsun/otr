using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoLibrary.Tests
{
    [TestClass]
    public class Base64Test
    {
        [TestMethod]
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