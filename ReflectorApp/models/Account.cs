using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectorApp.models
{
    internal class Account
    {
        static double MIN_BALANCE = 500; 
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }

        public double AccountBalance { get; set; }

        public Account(int accountNumber, string name)
        {
            AccountNumber = accountNumber;
            AccountName = name;
            AccountBalance = MIN_BALANCE;
        }


        public Account(int accountNumber, string name, double accountBalance) : this(accountNumber, name)
        {
            //AccountNumber = accountNumber;
            // AccountName = name;
            if (accountBalance < MIN_BALANCE)
                AccountBalance = MIN_BALANCE;
            else
                AccountBalance = accountBalance;
        }

        public bool Deposit(double Amount)
        {
            AccountBalance += Amount;
            return true;
        }

        public bool Withdraw(double WithdrawalAmount)
        {
            if ((AccountBalance - WithdrawalAmount) < MIN_BALANCE)
                return false;
            AccountBalance -= WithdrawalAmount;
            return true;
        }


        public static Account AccountWithMaxBalance(Account[] accounts)
        {
            Account accountWithMaxBalance = null; //account[0]
            double maxBalance = MIN_BALANCE;

            foreach (Account account in accounts)
            {

                if (account.AccountBalance > maxBalance)
                {
                    maxBalance = account.AccountBalance;
                    accountWithMaxBalance = account;
                }
            }



            return accountWithMaxBalance;
        }
    }
}
