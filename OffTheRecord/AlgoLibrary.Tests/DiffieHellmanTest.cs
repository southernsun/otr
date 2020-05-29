using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using Org.BouncyCastle.Utilities.Encoders;

namespace AlgoLibrary.Tests
{
    [TestFixture]
    public class DiffieHellmanTest
    {
        [Test]
        public void EncryptAndDecryptDiffieHellman()
        {
            //var chaCha20 = new ChaCha20();

            //const string secret = "say hello to my little friend!";

            ///* fixed key and iv */
            //var key = Hex.Decode("80000000000000000000000000000000");
            //var iv = Hex.Decode("0000000000000000");

            //var input = Encoding.ASCII.GetBytes(secret);

            //var encode = chaCha20.Encode(input, key, iv);
            //var decode = chaCha20.Decode(encode, key, iv);

            //input.Should().BeEquivalentTo(decode);

            //var decryptedString = Encoding.ASCII.GetString(decode);
            //decryptedString.Should().Be(secret);
        }
    }
}
