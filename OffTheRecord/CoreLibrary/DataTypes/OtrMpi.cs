using System;

/* NOT FINISHED */

namespace OffTheRecord.CoreLibrary.DataTypes
{
    public struct OtrMpi
    {
        private uint _length;
        private byte[] _value;

        public static implicit operator OtrMpi(byte[] value)
        {
            if (value.Length > UInt32.MaxValue)
            {
                // do something;
                // NOTE: byte array max length is int instead of uint? YES it is...
                // need to come up with something else;
            }

            return new OtrMpi
            {
                _length = (uint) value.Length,
                _value = value
            };
        }

        public static implicit operator byte[](OtrMpi value)
        {
            return value._value;
        }
    }
}
