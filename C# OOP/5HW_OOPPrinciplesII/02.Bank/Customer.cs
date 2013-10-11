using System;

namespace _02.Bank
{
    public abstract class Customer
    {
        #region private fields
        private string name;
        #endregion

        #region constructors
        public Customer(string name)
        {
            this.Name = name;
        }
        #endregion

        #region properties

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
        #endregion


    }
}