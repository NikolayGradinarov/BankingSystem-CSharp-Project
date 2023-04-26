using BankingSystem.Core.Interfaces;
using BankingSystem.IO;
using BankingSystem.IO.Interfaces;
using BankingSystem.Models.Accounts;
using BankingSystem.Models.Banks;
using BankingSystem.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
        }

        public void Run()
        {
            //The main idea and function of the banking system

            ChooseBank();

            string bankName = reader.ReadLine();
            Bank bank = null;

            switch (bankName.ToUpper())
            {
                //Checking the name given name of the bank and creating it
                //Practicing polymorphism

                case "OBB":
                    LoadingBank();
                    bank = new OBB(bankName);
                    CreatingBank(bankName);
                    break;
                case "DSK":
                    LoadingBank();
                    bank = new DSK(bankName);
                    CreatingBank(bankName);
                    break;
                case "UNICREDIT":
                    LoadingBank();
                    bank = new Unicredit(bankName);
                    CreatingBank(bankName);
                    break;
                default:
                    writer.WriteLine("Invalid Bank Name");
                    writer.WriteLine("Try again later");
                    return;                                     
            }

            writer.WriteLine("Choose option:\n");
            writer.WriteLine("1. Account");
            writer.WriteLine("2. Exit");


            while (true)
            {
                string[] input = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);              

                //Chosing from the given options

                if (input[0] == "Exit" || input[0] == "2")
                {
                    Environment.Exit(0);
                }
                if (input[0] == "Account" || input[0] == "1")
                {
                    Console.Clear();
                    writer.WriteLine("Username:");
                    int invalidEntryCount = 3;

                    Account account = null;
                    Customer customer = null;

                    for (int i = 0; i < 3; i++)
                    {
                        string accountName = reader.ReadLine();
                        bool isValid = false;

                        switch (accountName)
                        {
                            //Creating account and customer

                            case "nikolay":
                                account = new Account();
                                customer = new Customer("Nikolay", "Sofia, Bulgaria", "+359 885633980");
                                isValid = true;
                                break;

                            case "ivan":
                                account = new Account();
                                customer = new Customer("Ivan", "Sofia, Bulgaria", "+359 895001580");
                                isValid = true;
                                break;

                            case "petar":
                                account = new Account();
                                customer = new Customer("Petar", "Karlovo, Bulgaria", "+359 897773561");
                                isValid = true;
                                break;
                            default:
                                //Checking for attempts count

                                invalidEntryCount--;
                                if (invalidEntryCount == 0)
                                {
                                    Environment.Exit(0);
                                }
                                writer.WriteLine("Invalid attempt!");
                                writer.WriteLine($"{invalidEntryCount} attempts left");
                                writer.WriteLine("Please try again");
                                break;
                        }

                        if (isValid)
                        {
                            Console.Clear();
                            writer.WriteLine($"Welcome back {accountName}{Environment.NewLine}Choose option:\n");
                            break;
                        }
                    }
                    BankOptionsToChoose();

                    string chosenOption;
                    Random random = new Random();
                    decimal randomSavings = random.Next(10, 100001);

                    //Chosing from the given options

                    while ((chosenOption = reader.ReadLine()) != "6")
                    {
                        if (chosenOption == "Exit")
                        {
                            ExitMethod();
                        }

                        if (chosenOption == "Account Information" || chosenOption == "1")
                        {
                            //Shows the account information of the customer

                            Console.Clear();
                            AccountInformation(customer);
                            ExitAndBackOption();
                        }

                        if (chosenOption == "Check Savings" || chosenOption == "2")
                        {
                            //Shows the savings of the customer

                            Console.Clear();
                            decimal savings = randomSavings;
                            writer.WriteLine($"{customer.Name} has {savings:f2} lv. savings in his account.\n");
                            ExitAndBackOption();
                        }

                        if (chosenOption == "Balance" || chosenOption == "3")
                        {
                            //Shows the balance of the customer

                            Console.Clear();
                            writer.WriteLine($"Balance: {account.Balance:f2} lv.\n");
                            ExitAndBackOption();
                        }

                        if (chosenOption == "Deposit" || chosenOption == "4")
                        {
                            //The depositing system

                            Console.Clear();
                            writer.WriteLine("Enter the sum to deposit:");
                            decimal depositSum = decimal.Parse(reader.ReadLine());

                            writer.WriteLine("Confirm your deposit:");
                            decimal secondTimeSum = decimal.Parse(reader.ReadLine());

                            if (depositSum != secondTimeSum)
                            {
                                //If the first sum and the second are not the same, the deposit is invalid

                                writer.WriteLine($"Incorect sum{Environment.NewLine}Try again later!\n");
                                Thread.Sleep(2500);
                                Console.Clear();
                                ExitAndBackOption();
                            }
                            else
                            {
                                Console.Clear();
                                writer.WriteLine("Please wait...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                account.Deposit(depositSum);
                                writer.WriteLine("Sum added successfully\n");
                                ExitAndBackOption();
                            }
                        }

                        if (chosenOption == "Withdraw" || chosenOption == "5")
                        {
                            //The withdrawing system

                            Console.Clear();
                            writer.WriteLine("Enter the sum to withdraw:");
                            decimal withdraw = decimal.Parse(reader.ReadLine());

                            writer.WriteLine("Confirm your withdraw:");
                            decimal secondTimeWithdrawSum = decimal.Parse(reader.ReadLine());

                            if (withdraw != secondTimeWithdrawSum)
                            {
                                //If the first sum and the second are not the same, the withdraw is invalid

                                writer.WriteLine($"Incorect sum{Environment.NewLine}Try again later!\n");
                                Thread.Sleep(2500);
                                Console.Clear();
                                ExitAndBackOption();
                            }
                            else
                            {
                                Console.Clear();
                                writer.WriteLine("Please wait...");
                                Thread.Sleep(2000);
                                Console.Clear();
                                account.Withdraw(withdraw);
                                writer.WriteLine("Sum withdrawed successfully\n");
                                ExitAndBackOption();
                            }
                        }
                    }
                    ExitMethod();
                }
            }
        }

        private void ExitMethod()
        {
            Console.Clear();
            writer.WriteLine("Thank You for using our Banking System!");
            writer.WriteLine("Have a great day!");
            Environment.Exit(0);
        }

        private void CreatingBank(string bankName)
        {
            string titleCase = bankName.Substring(0, 1) + bankName.Substring(1).ToLower();
            writer.WriteLine($"Welcome to {titleCase}");
            Thread.Sleep(2500);
            Console.Clear();          
        }
        
        private void ExitAndBackOption()
        {
            writer.WriteLine("1. Back");
            writer.WriteLine("2. Exit");

            string option = reader.ReadLine();
            if (option == "1" || option == "Back")
            {
                Console.Clear();
                BankOptionsToChoose();
            }
            else if (option == "2" || option == "Exit")
            {
                Environment.Exit(0);
            }
        }

        private void AccountInformation(Customer customer)
        {
            Console.Clear();
            writer.WriteLine($"Name: {customer.Name}");
            writer.WriteLine($"Address: {customer.Address}");
            writer.WriteLine($"Phone: {customer.PhoneNumber}\n");          
        }

        private void BankOptionsToChoose()
        {
            writer.WriteLine("1. Account Information.");
            writer.WriteLine("2. Check Savings.");
            writer.WriteLine("3. Balance.");
            writer.WriteLine("4. Deposit.");
            writer.WriteLine("5. Withdraw.");
            writer.WriteLine("6. Exit.");
        }

        private void LoadingBank()
        {
            Console.Clear();
            writer.WriteLine("Please wait...");
            Thread.Sleep(3500);
            ProgressBar();
        }

        private void ChooseBank()
        {
            writer.WriteLine("Hello! Choose your Bank.\n");
            writer.WriteLine("----------");
            writer.WriteLine("   OBB");
            writer.WriteLine("----------");
            writer.WriteLine("   DSK");
            writer.WriteLine("----------");
            writer.WriteLine("Unicredit");
            writer.WriteLine("----------");
        }

        private void ProgressBar()
        {
            Console.Title = "Console Progress Bar";
            Console.CursorVisible = false;
            Console.SetCursorPosition(1, 1);

            for (int i = 0; i <= 50; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    string pb = "\u2551";
                    Console.Write(pb);
                }

                writer.Write(i + " / 50");
                Console.SetCursorPosition(1, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(50);
            }
            Console.Clear();
        }
    }
}
