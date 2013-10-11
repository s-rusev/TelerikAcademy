using System;
using System.Linq;

namespace AnimalHierarchy
{
    public abstract class Animal : ISound
    {
        #region private fields
        private ushort age;
        private string name;
        private Sex sex; 
        #endregion

        #region constructors
        public Animal(ushort age, string name, Sex sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }
        #endregion

        #region properties
        public ushort Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException("Invalid age");
                }
                this.age = value;
            }
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

        public Sex Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value != Sex.Male && value != Sex.Female)
                {
                    throw new ArgumentException("Invalid sex!"); 
                }
                this.sex = value;
            }
        }
        #endregion

        #region methods
        public abstract void ProduceSound();
        #endregion
    }
}
