using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SubstringExtension
{

    public class SubstringTest
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0123456789");
            Console.WriteLine(SubstringExtension.Substring(sb, 2, 4));
        }
    }
}
