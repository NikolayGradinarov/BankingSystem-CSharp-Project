using BankingSystem.Models.Accounts.Interfaces;
using BankingSystem.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Accounts
{
    public class Account : IAccount  
    {
        //Creating the maximum and minimum allowed sum you can own in the bank

        private const decimal MaximumBalance = 100000;
        private const decimal MinimumBalance = 10;

        private decimal balance;

        public Account()
        {
            //The starting balance for every person is random number between max and min

            Random random = new Random();
            balance = random.Next(10, 100001);
        }

        public decimal Balance => balance;

        public void Deposit(decimal amount)
        {
            //Checking if balance exceeds the maximum when depositing

            if ((balance + amount) > MaximumBalance)
            {
                throw new ArgumentException(ExceptionMessages.BalanceMoreThanMaximum);
            }
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            //Checking if balance drops below the minimum when withdrawing 

            if ((balance - amount) < MinimumBalance)
            {
                throw new ArgumentException(ExceptionMessages.BalanceBelowMinimum);
            }
            balance -= amount;
        }       
    }
}
