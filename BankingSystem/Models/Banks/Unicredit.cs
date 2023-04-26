using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models.Banks
{
    public class Unicredit : Bank
    {
        //Practising Inheritance
        public Unicredit(string name) 
            : base(name)
        {
        }
    }
}
