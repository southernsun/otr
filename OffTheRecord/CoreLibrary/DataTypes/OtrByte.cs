using System;

namespace OffTheRecord.CoreLibrary.DataTypes
{
    public struct OtrByte : IComparable, IComparable<OtrByte>
    {
        private byte _value;

        public static implicit operator OtrByte(byte value)
        {
            return new OtrByte { _value = value };
        }

        public static implicit operator byte(OtrByte value)
        {
            return value._value;
        }

        public int CompareTo(object? value)
        {
            if (value == null)
            {
                return 1;
            }

            if (value is byte i)
            {
                if (_value < i) return -1;
                if (_value > i) return 1;
                return 0;
            }

            throw new ArgumentException("not a OtrByte");
        }

        public int CompareTo(OtrByte value)
        {
            if (_value < value) return -1;
            if (_value > value) return 1;
            return 0;
        }
    }
}
