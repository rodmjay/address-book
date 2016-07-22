using System.Collections.Generic;
using System.Linq;
using AddressBook.Models;
using AddressBook.Service;
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
            [SetUp]
            public void SetupMethod()
            {
                SessionStateBase["Contacts"] = new List<ContactModel>
                {
                    new ContactModel()
                    {
                        Name = "test",
                        PhoneNumber = "123-123-1234"
                    }
                };
            }

            [Test]
            public void ReturnsCorrectNumberOfContacts()
            {
                var service = GetService();

                Assert.AreEqual(1, service.GetContacts().Count());
            }

            [Test]
            public void ReturnsStoredValue()
            {
                var service = GetService();

                Assert.AreEqual("test", service.GetContacts()[0].Name);
                Assert.AreEqual("123-123-1234", service.GetContacts()[0].PhoneNumber);
            }
        }

        [TestFixture]
        public class TheUpdateContactMethod : SessionContactServiceTests
        {
            [SetUp]
            public void SetupMethod()
            {
                SessionStateBase["Contacts"] = new List<ContactModel>()
                {
                    new ContactModel()
                    {
                        Name = "test"
                    }
                };
            }

            [Test]
            public void ShouldUpdateName()
            {
                var service = GetService();

                service.UpdateContact(0,new ContactModel()
                {
                    Name = "test1"
                });

                Assert.AreEqual("test1", service.GetContacts()[0].Name);
            }

            [Test]
            public void ShouldUpdatePhone()
            {
                var service = GetService();

                service.UpdateContact(0, new ContactModel()
                {
                    PhoneNumber = "test1"
                });

                Assert.AreEqual("test1", service.GetContacts()[0].PhoneNumber);
            }
        }

        [TestFixture]
        public class TheCreateContactMethod : SessionContactServiceTests
        {
            [SetUp]
            public void SetupMethod()
            {
                SessionStateBase["Contacts"] = new List<ContactModel>();
            }

            [Test]
            public void ShouldCreateContact()
            {
                var service = GetService();
                
                service.CreateContact(new ContactModel());

                Assert.AreEqual(1,service.GetContacts().Count);
            }
        }
    }
}
