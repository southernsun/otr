namespace AlgoLibrary
{
    interface IHashFunction
    {
        public byte[] ComputeHash(byte[] input);
        public string ComputeHash(string input);
    }
}
