using System;
using System.Text;

namespace GSMInfo
{
    //contains (size and number of colors)
    class Display
    {
        private uint size;
        private uint numberOfColors;

        public uint Size 
        {
            get { return this.size; }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Invalid size!");
                }
                this.size = value;
            }
        }
        public uint NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid number of colors!");
                }
                this.numberOfColors = value;
            }
        }

        public Display(uint size = 10, uint numberOfColors = 16) 
        {
            this.NumberOfColors = numberOfColors;
            this.Size = size;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Size- " + this.size).Append("; ").Append("Number of colors " + this.numberOfColors);
            return sb.ToString();
        }
    }

}
