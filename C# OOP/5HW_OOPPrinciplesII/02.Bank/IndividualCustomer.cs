using System;

namespace _02.Bank
{
    public class IndividualCustomer : Customer
    {
        public IndividualCustomer(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} is individual customer", base.Name);
        }
    }
}