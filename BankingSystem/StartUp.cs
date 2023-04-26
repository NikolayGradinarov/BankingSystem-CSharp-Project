using BankingSystem.Core;
using BankingSystem.Core.Interfaces;
using BankingSystem.Models.Accounts;
using BankingSystem.Models.Banks;

namespace BankingSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();           
            engine.Run();
        }
    }
}