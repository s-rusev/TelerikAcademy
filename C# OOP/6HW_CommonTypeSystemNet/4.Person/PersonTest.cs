using System;

namespace _4.Person
{
    class PersonTest
    {
        static void Main()
        {
            Person ivan = new Person("Ivan", 20);
            Console.WriteLine(ivan.ToString());
            Person dragan = new Person("Dragan", null);
            Console.WriteLine(dragan.ToString());
        }
    }
}