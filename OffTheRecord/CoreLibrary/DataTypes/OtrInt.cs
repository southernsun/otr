using System;

namespace OffTheRecord.CoreLibrary.DataTypes
{
    public struct OtrInt : IComparable, IComparable<OtrInt>
    {
        private uint _value;

        public static implicit operator OtrInt(uint value)
        {
            return new OtrInt { _value = value };
        }

        public static implicit operator uint(OtrInt otrInt)
        {
            return otrInt._value;
        }

        public int CompareTo(object? value)
        {
            if (value == null)
            {
                return 1;
            }

            if (value is uint i)
            {
                if (_value < i) return -1;
                if (_value > i) return 1;
                return 0;
            }

            throw new ArgumentException("not a OtrInt");
        }

        public int CompareTo(OtrInt value)
        {
            if (_value < value) return -1;
            if (_value > value) return 1;
            return 0;
        }
    }
}