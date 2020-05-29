namespace AlgoLibrary
{
    interface IEncryptionFunction
    {
        public byte[] Encode(byte[] input, byte[] key, byte[] iv);
        public byte[] Decode(byte[] input, byte[] key, byte[] iv);
    }
}
