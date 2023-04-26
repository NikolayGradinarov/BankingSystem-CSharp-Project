using BankingSystem.Models.Accounts.Interfaces;
using BankingSystem.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Banks.Interfaces
{
    public interface IBank
    {
        string Name { get; }       
       
    }
}
