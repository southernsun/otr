namespace OffTheRecord.CoreLibrary.DataTypes
{
    public readonly struct OtrNonce
    {
        public byte[] Value
        {
            get
            {
                return new byte[12] { 
                    0,0,0,0,
                    0,0,0,0,
                    0,0,0,0
                };
            }
        }
    }
}
