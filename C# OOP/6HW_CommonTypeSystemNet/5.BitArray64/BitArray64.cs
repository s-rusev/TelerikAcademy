using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _5.BitArray64
{
    class BitArray64 : IEnumerable<int>
    {
        private readonly ulong number;
        private readonly int[] bits;

        public BitArray64(ulong number = 0)
        {
            this.number = number;
            this.bits = new int[64];
            this.bits = ConvertToBinary(number);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.number + "->");
            foreach (var item in this.bits)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.bits.Length; i++)
            {
                yield return this.bits[i];
            }
        }

        private int[] ConvertToBinary(ulong value)
        {
            int[] binaryRepresentation = new int[64];
            int index = 63; // index for rightmost element

            //start from right to left
            while (value != 0)
            {
                binaryRepresentation[index] = (int)value % 2;
                value /= 2;
                index--;
            }

            //fill what is left with zeros
            do
            {
                binaryRepresentation[index] = 0;
                index--;
            }
            while (index != 0);

            return binaryRepresentation;
        }

        public bool Equals(BitArray64 secondBitArray)
        {
            return (this.number == secondBitArray.number);
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < 64)
                {
                    return this.bits[index]; 
                }
                else
                {
                    throw new System.IndexOutOfRangeException("Index out of range! Must be between 0 and 63 (included)");
                }
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BitArray64);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.number.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !BitArray64.Equals(first, second);
        }
    }
}