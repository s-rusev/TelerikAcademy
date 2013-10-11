using System;
namespace _02.Bank
{
    class LoanAccount : Account, IDeposit
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void AddDeposit(decimal deposit)
        {
            if (deposit < 0)
            {
                throw new ArgumentException("Cannot add negative ammount");
            }
            else
            {
                this.Balance += deposit;
            }
        }

        public override decimal InterestAmountForPeriod(uint months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    return base.InterestAmountForPeriod(months - 3);
                }
            }
            else if (this.Customer is CompanyCustomer)
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return base.InterestAmountForPeriod(months - 2);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}