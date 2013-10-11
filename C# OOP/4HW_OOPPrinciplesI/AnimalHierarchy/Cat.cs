using System;

namespace AnimalHierarchy
{
    public abstract class Cat : Animal
    {

        public Cat(ushort age, string name, Sex sex) : base(age, name, sex)
        {
        }

        public override void ProduceSound() 
        {
            Console.WriteLine("{0} says: Meow!" , this.Name);
        }
    }
}
