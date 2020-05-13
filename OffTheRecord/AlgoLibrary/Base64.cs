using System;

namespace AlgoLibrary
{
    public class Base64 : IEncodingFunction
    {
        public string Encode(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        public byte[] Decode(string input)
        {
            return System.Convert.FromBase64String(input);
        }
    }
}
