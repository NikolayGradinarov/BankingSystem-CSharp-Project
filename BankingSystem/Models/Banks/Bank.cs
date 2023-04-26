using BankingSystem.Models.Accounts.Interfaces;
using BankingSystem.Models.Banks.Interfaces;
using BankingSystem.Models.Customers;
using BankingSystem.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Banks
{
    public abstract class Bank : IBank
    {
        //Practising encapsulation and abstraction

        private string name;           

        protected Bank(string name)
        {
            this.name = name; 
        }

        public string Name
        {
            //Checking if the given name is valid

            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }

    }
}
