using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shake256.Tests
{
    [TestClass]
    public class Shake256Test
    {
        [TestMethod]
        public void TestShake256Hash()
        {
            var a = new Shake256();
            var output = a.Hash("B");

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
