using System.Text;

namespace AlgoLibrary
{
    public class BytesToString : IEncodingFunction
    {
        public string Encode(byte[] input)
        {
            return Encoding.ASCII.GetString(input);
        }

        public byte[] Decode(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }
    }
}
