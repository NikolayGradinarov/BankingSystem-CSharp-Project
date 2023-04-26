using BankingSystem.Models.Accounts;
using BankingSystem.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Customers
{
    public class Customer 
    {
        private string name;
        private string address;
        private string phoneNumber;

        public Customer(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public string Name
        {
            //Checking if the given name is valid

            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public string Address
        {
            //Checking if the given address is valid

            get => address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                address = value;
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                //Checking if the given number is valid

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                phoneNumber = value;
            }
        }               
    }
}
