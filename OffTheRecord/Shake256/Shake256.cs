using System;
using System.Linq;
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

        public string Hash()
        {
            int bits = 256; // v.Bits;
            int partialBits = bits % 8;
            int outLen = 256 / 8; //expected.Length;

            byte[] output = new byte[outLen];

            //byte[] m = new byte[] {1, 1, 0, 0, 1}; //= bin = 19 dec = 13 hex
            //byte[] m = new byte[] { 0, 1, 0, 0, 0, 0, 1, 0 }; //= bin = 66 dec = 42 hex = B
            byte[] m = new byte[] {Convert.ToByte('B')};

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
