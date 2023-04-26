namespace BankingSystem.Tests
{
    using BankingSystem.Models.Accounts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AccountTest
    {
        private Account account;

        [SetUp]
        public void Setup()
        {
            account = new Account();
        }

        [TearDown]
        public void TearDown()
        {
            account = null;
        }

        [Test]
        public void TestBalanceWithinRange()
        {
            //Assert that the account balance is greater than or equal to 10 lv.
            Assert.GreaterOrEqual(account.Balance, 10);
            
            //Assert that the account balance is less that or equal to 100000 lv.
            Assert.LessOrEqual(account.Balance, 100000);
        }

        [Test]
        public void TestDepositWithValidAmount()
        {
            decimal initialBalance = account.Balance;
            decimal depositAmount = 500;

            account.Deposit(depositAmount);
            
            //Assert that the new balance is equal to the initial balance plus the deposit amount
            Assert.AreEqual(initialBalance + depositAmount, account.Balance);
        }

        [Test]
        public void TestDepositInvalidAmount()
        {
            decimal depositAmount = 100000 - account.Balance + 1;

            //Assert that an ArgumenException is thrown when attempting to deposit an amount that would exceed the maximum balance
            Assert.Throws<ArgumentException>(() => account.Deposit(depositAmount));
        }

        [Test]
        public void TestWithdrawWithValidAmount()
        {
            decimal initialBalance = account.Balance;
            decimal withdrawalAmount = 100;

            account.Withdraw(withdrawalAmount);

            //Assert that the new balance is equal to the initial balance minus the withdrawal amount
            Assert.AreEqual(initialBalance - withdrawalAmount, account.Balance);
        }

        [Test]
        public void TestWithdrawWithInvalidAmount()
        {
            decimal withdrawalAmount = account.Balance - 10 + 1;

            //Assert that an ArgumentException is thrown when attempting to withdraw an amount that would cause the balance to drop below the minimum balance
            Assert.Throws<ArgumentException>(() => account.Withdraw(withdrawalAmount));
        }
    }
}