using System;

namespace _4.Person
{
    class Person
    {
        private string name;
        private byte? age;

        public Person(string name, byte? age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public byte? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            if (age != null)
            {
                return string.Format("Name: {0} is {1} years old", name, age);
            }
            else
            {
                return string.Format("Name: {0} is with unknown age." , name);
            }
        }


    }
}
