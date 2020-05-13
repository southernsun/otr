using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace OffTheRecord.CoreLibrary.Classes
{
    public class EndianUtilities
    {
        public bool IsLittleEndian()
        {
            return BitConverter.IsLittleEndian;
        }

        public byte[] ToLittleEndian(byte[] input)
        {
            if (IsLittleEndian())
            {
                return input;
            }

            return Switch(input);
        }

        public byte[] ToBigEndian(byte[] input)
        {
            if (IsLittleEndian())
            {
                return Switch(input);
            }

            return input;
        }

        private byte[] Switch(byte[] input)
        {
            var inputLength = input.Length;

            var output = new byte[inputLength];
            Array.Copy(input, output, inputLength);
            Array.Reverse(output);

            return output;
        }
    }
}
