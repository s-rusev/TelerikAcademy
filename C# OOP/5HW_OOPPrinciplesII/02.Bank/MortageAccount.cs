using System;

namespace _02.Bank
{
    class MortageAccount : Account, IDeposit
    {
        #region constructors
        public MortageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }
        #endregion
        #region methods
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
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return base.InterestAmountForPeriod(months - 6);
                }
            }
            else
            {
                if (months >= 12)
                {
                    return (this.Balance * (this.InterestRate / 2.0m)) * (months) + base.InterestAmountForPeriod(months - 12);
                }
                else
                {
                    return (this.Balance * (this.InterestRate / 2.0m)) * (months);
                }
            }
        }
        #endregion
    }
}