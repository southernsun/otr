namespace AlgoLibrary
{
    interface IEncodingFunction
    {
        public string Encode(byte[] input);
        public byte[] Decode(string input);
    }
}
