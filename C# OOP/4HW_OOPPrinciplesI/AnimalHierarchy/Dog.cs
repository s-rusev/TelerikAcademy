using System;

namespace AnimalHierarchy
{
    public class Dog : Animal
    {
        public Dog(ushort age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} says: Woof!", this.Name);
        }
    }
}
