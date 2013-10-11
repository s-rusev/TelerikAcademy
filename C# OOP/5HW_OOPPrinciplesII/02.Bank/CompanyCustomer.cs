using System;

namespace _02.Bank
{
    class CompanyCustomer : Customer
    {
        public CompanyCustomer(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} is company customer", base.Name);
        }
    }
}
