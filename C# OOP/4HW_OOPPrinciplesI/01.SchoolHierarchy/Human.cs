using System;
using System.Linq;


namespace _01.SchoolHierarchy
{
    public abstract class Human
    {
        #region private fields
        private readonly string name;
        #endregion

        #region constructors
        public Human(string name)
        {
            this.name = name;
        }
        #endregion

        #region properties
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        #endregion
    }
}
