using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Models;
using AddressBook.Service;
using Moq;
using NUnit.Framework;

namespace AddressBook.Tests
{
    [TestFixture]
    public class SessionContactServiceTests
    {
        protected MockHttpSession SessionStateBase;

        [SetUp]
        public void SetupTest()
        {
            SessionStateBase = new MockHttpSession();
        }

        protected SessionContactService GetService()
        {
            return new SessionContactService(SessionStateBase);
        }

        [TestFixture]
        public class TheGetContactsMethod : SessionContactServiceTests
        {
            [Test]
            public void ReturnsCorrectNumberOfContacts()
            {
                List<ContactModel> contacts = new List<ContactModel>
                {
                    new ContactModel()
                };

                SessionStateBase.Add("Contacts", contacts);

                var service = GetService();

                Assert.AreEqual(1, service.GetContacts().Count());
            } 
        }

        [TestFixture]
        public class TheUpdateContactMethod : SessionContactServiceTests
        {
            
        }

        [TestFixture]
        public class TheCreateContactMethod : SessionContactServiceTests
        {
            
        }
    }
}
