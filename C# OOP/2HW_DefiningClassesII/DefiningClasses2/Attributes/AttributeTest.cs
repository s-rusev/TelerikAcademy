using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Attributes
{
    [Version("2.11")]
    class AttributeTest
    {
        static void Main()
        {
            var type = typeof(AttributeTest);
            foreach (var attribute in type.GetCustomAttributes(false))
            {
                if (attribute is VersionAttribute)
                {
                    Console.WriteLine("Class - {0}" , typeof(AttributeTest).Name);
                    Console.WriteLine("Version - {0}" , (attribute as VersionAttribute).Version);
                }
            }
        }
    }
}


