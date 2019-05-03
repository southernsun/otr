using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;

namespace Ed448.Tests
{
    [TestClass]
    public class Ed448Test
    {
        [TestMethod]
        public void TestEd448Encryption()
        {
            PerformTest();
        }

        private static readonly SecureRandom Random = new SecureRandom();


        public void PerformTest()
        {
            for (int i = 0; i < 10; ++i)
            {
                byte[] context = RandomContext(Random.NextInt() & 255);
                DoTestConsistency(context);
            }
        }

        private ISigner CreateSigner(Org.BouncyCastle.Math.EC.Rfc8032.Ed448.Algorithm algorithm, byte[] context)
        {
            switch (algorithm)
            {
                case Org.BouncyCastle.Math.EC.Rfc8032.Ed448.Algorithm.Ed448:
                    return new Ed448Signer(context);
                default:
                    throw new ArgumentException("algorithm");
            }
        }

        private byte[] RandomContext(int length)
        {
            byte[] context = new byte[length];
            Random.NextBytes(context);
            return context;
        }

        private void DoTestConsistency(byte[] context)
        {
            var algorithm = Org.BouncyCastle.Math.EC.Rfc8032.Ed448.Algorithm.Ed448;

            var kpg = new Ed448KeyPairGenerator();
            kpg.Init(new Ed448KeyGenerationParameters(Random));

            var kp = kpg.GenerateKeyPair();
            var privateKey = (Ed448PrivateKeyParameters)kp.Private;
            var publicKey = (Ed448PublicKeyParameters)kp.Public;

            var msg = new byte[Random.NextInt() & 255];
            Random.NextBytes(msg);

            var signer = CreateSigner(algorithm, context);
            signer.Init(true, privateKey);
            signer.BlockUpdate(msg, 0, msg.Length);
            var signature = signer.GenerateSignature();

            /* my stuff */
            privateKey.Encode(new byte[] {0, 1, 1, 0}, 0);
            var result = privateKey.GetEncoded();
            

            //* continue rest

            var verifier = CreateSigner(algorithm, context);
            verifier.Init(false, publicKey);
            verifier.BlockUpdate(msg, 0, msg.Length);
            var shouldVerify = verifier.VerifySignature(signature);

            if (!shouldVerify)
            {
                shouldVerify.Should().BeTrue("Ed448(" + algorithm + ") signature failed to verify");
            }

            signature[Random.Next() % signature.Length] ^= (byte)(1 << (Random.NextInt() & 7));

            verifier.Init(false, publicKey);
            verifier.BlockUpdate(msg, 0, msg.Length);
            bool shouldNotVerify = verifier.VerifySignature(signature);

            if (shouldNotVerify)
            {
                shouldNotVerify.Should().BeTrue("Ed448(" + algorithm + ") bad signature incorrectly verified");
            }
        }

    }
}
