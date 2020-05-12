using System;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;

namespace AlgoLibrary
{
    public class Shake256 : ShakeDigest, IHashFunction
    {
        public Shake256()
            : base(256)
        {
        }

        internal int MyDoFinal(byte[] output, int outOff, int outLen, byte partialByte, int partialBits)
        {
            return DoFinal(output, outOff, outLen, partialByte, partialBits);
        }

        public byte[] ComputeHash(byte[] input)
        {
            var bits = 256;
            var partialBits = bits % 8;
            var outLen = bits / 8; // character is 8 bytes;

            var output = new byte[outLen];
            var m = input;

            if (partialBits == 0)
            {
                this.BlockUpdate(m, 0, m.Length);
                this.DoFinal(output, 0, outLen);
            }
            else
            {
                this.BlockUpdate(m, 0, m.Length - 1);
                this.MyDoFinal(output, 0, outLen, m[^1], partialBits);
            }

            return output;
        }

        public string ComputeHash(string input)
        {
            var output = ComputeHash(Encoding.ASCII.GetBytes(input));
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
