using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoLibrary.Tests
{
    [TestClass]
    public class AlgoLibraryTests
    {
        [TestMethod]
        public void ComputeHashTest()
        {
            var shake256 = new Shake256();
            var output = shake256.ComputeHash("B");

            output.Should().NotBeEmpty();

            // matches the outcome of:
            // [root@mikhail apps]# printf "B" | ./openssl dgst -shake256
            // (stdin) = 9b4033bf5151724308b4b1fc90f1534688ea1a17c911aa3a897d5b6a05db5c25
            // and
            // https://emn178.github.io/online-tools/shake_256.html using 'B' as input with 'SHAKE256' and Output bits: 256.

            output.Should().Be("9b4033bf5151724308b4b1fc90f1534688ea1a17c911aa3a897d5b6a05db5c25".ToUpperInvariant());
        }
    }
}
