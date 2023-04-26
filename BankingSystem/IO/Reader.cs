using BankingSystem.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.IO
{
    public class Reader : IReader
    {
        //Creating reder class, in case we change the input/output later

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
