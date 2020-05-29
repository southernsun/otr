using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;

namespace AlgoLibrary
{
    /*
     * This implementation might not yet completely match the OTR specifications, but at least the basic are there.
     *
     * https://tools.ietf.org/html/rfc7539#page-15
     */
    public class ChaCha20 : IEncryptionFunction
    {
        private const int Rounds = 20;

        public byte[] Encode(byte[] input, byte[] key, byte[] iv)
        {
            return DoChaCha20(input, key, iv, true);
        }

        public byte[] Decode(byte[] input, byte[] key, byte[] iv)
        {
            return DoChaCha20(input, key, iv, false);
        }

        private static byte[] DoChaCha20(byte[] input, byte[] key, byte[] iv, bool encrypt)
        {
            if (key.Length != 16)
            {
                throw new Exception();
            }

            if (iv.Length != 8)
            {
                throw new Exception();
            }

            var buf = new byte[input.Length];

            var salsa = new ChaChaEngine(Rounds);
            ICipherParameters parameters = new ParametersWithIV(new KeyParameter(key), iv);
            salsa.Init(encrypt, parameters);
            salsa.ProcessBytes(input, 0, input.Length, buf, 0);
            return buf;
        }
    }
}
