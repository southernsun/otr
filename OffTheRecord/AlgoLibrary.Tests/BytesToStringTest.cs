using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoLibrary.Tests
{
    [TestClass]
    public class BytesToStringTest
    {
        [TestMethod]
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
