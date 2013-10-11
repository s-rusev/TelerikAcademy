using System;

namespace _02.Bank
{
    public class DepositAccount : Account, IDeposit, IDraw
    {
        #region constructors
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }
        #endregion

        #region methods
        public void AddDeposit(decimal ammount)
        {
            if (ammount < 0)
            {
                throw new ArgumentException("Cannot add negative ammount");
            }
            else
            {
                this.Balance += ammount;
            }
        }

        public void DrawMoney(decimal ammount)
        {
            if (ammount < 0)
            {
                throw new ArgumentException("Cannot withdraw negative ammount!");
            }
            else
            {
                this.Balance -= ammount;
            }
        }

        public override decimal InterestAmountForPeriod(uint months)
        {
            if (this.Balance >= 0 && this.Balance <= 1000)
            {
                return 0;
            }
            else
            {
                return base.InterestAmountForPeriod(months);
            }
        }
        #endregion
    }
}