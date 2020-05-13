using System;

namespace OffTheRecord.CoreLibrary.DataTypes
{
    public struct OtrShort : IComparable, IComparable<OtrShort>
    {
        private ushort _value;

        public static implicit operator OtrShort(ushort value)
        {
            return new OtrShort { _value = value };
        }

        public static implicit operator ushort(OtrShort value)
        {
            return value._value;
        }

        public int CompareTo(object? value)
        {
            if (value == null)
            {
                return 1;
            }

            if (value is ushort i)
            {
                if (_value < i) return -1;
                if (_value > i) return 1;
                return 0;
            }

            throw new ArgumentException("not a OtrShort");
        }

        public int CompareTo(OtrShort value)
        {
            if (_value < value) return -1;
            if (_value > value) return 1;
            return 0;
        }
    }
}
