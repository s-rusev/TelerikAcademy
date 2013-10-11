using System;

namespace AnimalHierarchy
{
    public class Tomcat : Cat
    {
        public Tomcat(ushort age, string name) : base(age, name, Sex.Male)
        {
            base.Sex = Sex.Male;
        }
    }
}
