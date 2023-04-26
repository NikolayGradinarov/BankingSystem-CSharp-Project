using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Utilities.Messages
{
    public class ExceptionMessages
    {
        //Storing the Exception Messages

        public const string BalanceBelowZero = "Balance cannot drop below zero";

        public const string BalanceMoreThanMaximum = "Balance cannot exceed the maximum sum";

        public const string BalanceBelowMinimum = "Balance cannot drop below minimum sum";

        public const string NameNullOrWhiteSpace = "Name cannot be null or whitespace";
    }
}
