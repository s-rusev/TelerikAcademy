using System;

namespace AnimalHierarchy
{
    public class Frog : Animal
    {
        public Frog(ushort age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} says: Ribiit!", this.Name);
        }
    }
}
