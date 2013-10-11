using System;

namespace AnimalHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(ushort age, string name) : base(age, name, Sex.Female)
        {
            base.Sex = Sex.Female;
        }
    }
}
