namespace BankingSystem.Tests
{
    using BankingSystem.Models.Customers;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Reflection.Metadata;
    using System.Xml.Linq;

    [TestFixture]
    public class CustomerTest
    {
        private const string NAME = "Nikolay";
        private const string ADDRESS = "Sofia";
        private const string PHONENUMBER = "+35988858585";

        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer(NAME, ADDRESS, PHONENUMBER);
        }

        [TearDown]
        public void TearDown()
        {
            customer = null;
        }

        [Test]
        public void TestCustomerProperty()
        {
            Assert.AreEqual(NAME, customer.Name);
            Assert.AreEqual(ADDRESS, customer.Address);
            Assert.AreEqual(PHONENUMBER, customer.PhoneNumber);
        }

        [Test]
        public void NameSetWithInvalidNameThrowsArgumentException()
        {
            // Arrange
            string invalidName = null;
            Customer customer = new Customer(NAME, ADDRESS, PHONENUMBER);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => customer.Name = invalidName);
        }

        [Test]
        public void Address_SetWithInvalidAddress_ThrowsArgumentException()
        {
            // Arrange
            string invalidAddress = null;
            Customer customer = new Customer(NAME, ADDRESS, PHONENUMBER);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => customer.Address = invalidAddress);
        }

        [Test]
        public void PhoneNumber_SetWithInvalidNumber_ThrowsArgumentException()
        {
            // Arrange
            string invalidNumber = null;
            Customer customer = new Customer(NAME, ADDRESS, PHONENUMBER);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => customer.PhoneNumber = invalidNumber);
        }
    }
}
