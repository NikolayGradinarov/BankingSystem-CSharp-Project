using BankingSystem.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Customers.Interfaces
{
    public interface ICustomer
    {
        string Name { get; }
        string Address { get; }
        string PhoneNumber { get; }                      
    }
}
