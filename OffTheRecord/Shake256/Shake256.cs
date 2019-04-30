using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using Org.BouncyCastle.Crypto.Digests;

namespace Shake256
{
    public class Shake256 : ShakeDigest
    {
        public Shake256()
            : base(256)
        {
        }

        internal int MyDoFinal(byte[] output, int outOff, int outLen, byte partialByte, int partialBits)
        {
            return DoFinal(output, outOff, outLen, partialByte, partialBits);
        }

        public string Hash(string input)
        {
            int bits = 256;
            int partialBits = bits % 8;
            int outLen = bits / 8; // character is 8 bytes;

            byte[] output = new byte[outLen];

            byte[] m = Encoding.ASCII.GetBytes(input);

            if (partialBits == 0)
            {
                this.BlockUpdate(m, 0, m.Length);
                this.DoFinal(output, 0, outLen);
            }
            else
            {
                this.BlockUpdate(m, 0, m.Length - 1);
                this.MyDoFinal(output, 0, outLen, m[m.Length - 1], partialBits);
            }

            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
