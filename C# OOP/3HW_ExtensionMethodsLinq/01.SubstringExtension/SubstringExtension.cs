using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SubstringExtension
{
    public static class SubstringExtension
    {
        public static string Substring(this StringBuilder sb, int startIndex, int length)
        {
            return sb.ToString(startIndex, length);
        }
    }
}
