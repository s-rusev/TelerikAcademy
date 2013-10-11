using System;

namespace _02.Bank
{
    class BankTest
    {
        static void Main()
        {
            IndividualCustomer anIndividualCustomer = new IndividualCustomer("Ivan Ivanov");
            CompanyCustomer aCompanyCustomer = new CompanyCustomer("Telerik");
            //Deposite account for individual and company
            DepositAccount individualDepositAccount = new DepositAccount(anIndividualCustomer, 1000m, 0.02m);
            DepositAccount companyDepositeAccount = new DepositAccount(aCompanyCustomer, 1000m, 0.02m);
            Console.WriteLine(individualDepositAccount.ToString());
            Console.WriteLine(companyDepositeAccount.ToString());
            Console.WriteLine(new string('*', 60));
            //withdraw all money
            individualDepositAccount.DrawMoney(1000);
            // individualDepositAccount.DrawMoney(100000000); // will brake if uncommented 9
            Console.WriteLine("Individual deposite account balance: " + individualDepositAccount.Balance);
            individualDepositAccount.AddDeposit(1000);
            Console.WriteLine("Individual deposite account balance: " + individualDepositAccount.Balance);
            Console.WriteLine("Individual interest for an year: " + individualDepositAccount.InterestAmountForPeriod(12));
            individualDepositAccount.AddDeposit(1000);
            Console.WriteLine("Individual deposite account balance: " + individualDepositAccount.Balance);
            //now balance is more than 1000 and will have some interest
            Console.WriteLine("Individual interest for an year: " + individualDepositAccount.InterestAmountForPeriod(12));
            Console.WriteLine("Comapny deposite account balance: " + companyDepositeAccount.Balance);
            //no interest
            Console.WriteLine("Company interest for an year: " + companyDepositeAccount.InterestAmountForPeriod(12));
            companyDepositeAccount.AddDeposit(10000);
            Console.WriteLine("Comapny deposite account balance: " + companyDepositeAccount.Balance);
            //now balance is more than 1000 and will have some interest
            Console.WriteLine("Company interest for an year: " + companyDepositeAccount.InterestAmountForPeriod(12));
            Console.WriteLine(new string('*', 60));

            //Loan account for individual and company
            LoanAccount individualLoanAccount = new LoanAccount(anIndividualCustomer, 5000m, 0.02m);
            Console.WriteLine("Individual loan account balance: " + individualLoanAccount.Balance);
            Console.WriteLine("Individual interest for an year: " + individualLoanAccount.InterestAmountForPeriod(12));
            LoanAccount companyLoanAccount = new LoanAccount(aCompanyCustomer, 5000m, 0.02m);
            Console.WriteLine("Company loan account balance: " + companyLoanAccount.Balance);
            Console.WriteLine("Company interest for an year: " + companyLoanAccount.InterestAmountForPeriod(12));
            Console.WriteLine(new string('*', 60));

            //Mortage account for individual and company
            MortageAccount individualMortageAccount = new MortageAccount(anIndividualCustomer, 200000m, 0.02m);
            Console.WriteLine("Individual mortage account balance: " + individualMortageAccount.Balance);
            Console.WriteLine("Individual interest for an year: " + individualLoanAccount.InterestAmountForPeriod(12));
            MortageAccount companyMortageAccount = new MortageAccount(aCompanyCustomer, 300000m, 0.02m);
            Console.WriteLine("Company mortage account balance: " + companyMortageAccount.Balance);
            Console.WriteLine("Company interest for an year: " + companyLoanAccount.InterestAmountForPeriod(12));
            Console.WriteLine(new string('*', 60));

        }
    }
}
