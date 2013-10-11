using System;

namespace _02.Bank
{
    public abstract class Account
    {
        #region private fields
        private Customer customer;
        private decimal balance;
        private decimal interestRate;
        #endregion

        #region constructors
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        #endregion

        #region properties
        public override string ToString()
        {
            return string.Format("customer: {0}, balance: {1}, interestRate: {2}", customer, balance, interestRate);
        }

        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (this.balance < 0)
                {
                    throw new ArgumentException("Balance cannot be negative!");
                }
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The interestRate must be positive number!");
                }
                this.interestRate = value;
            }
        }
        #endregion

        #region methods
        public virtual decimal InterestAmountForPeriod(uint months)
        {
            return (this.Balance * this.InterestRate) * months;
        }
        #endregion
    }
}
