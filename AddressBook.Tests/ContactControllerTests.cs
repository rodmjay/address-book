using System.Net.Http;
using System.Web.Http;
using AddressBook.Controllers;
using AddressBook.Models;
using AddressBook.Service;
using Moq;
using NUnit.Framework;

namespace AddressBook.Tests
{
    [TestFixture]
    public class ContactControllerTests
    {
        protected Mock<IContactService> ContactService;
        [SetUp]
        public void Reset()
        {
            ContactService = new Mock<IContactService>();
        }

        protected ContactController GetController()
        {
            var controller = new ContactController(ContactService.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            return controller;
        }

        [TestFixture]
        public class TheGetMethod : ContactControllerTests
        {
            [Test]
            public void ShouldCallContactsMethodAndReturnSuccess()
            {
                var ctrl = GetController();
                ctrl.Get();
                ContactService.Verify(x=>x.GetContacts(), Times.Once);
            }
        }

        [TestFixture]
        public class TheCreateMethod : ContactControllerTests
        {
            [Test]
            public void ShouldCallCreateAndReturnSuccess()
            {
                var ctrl = GetController();
                ctrl.Create(new ContactModel());
                ContactService.Verify(x => x.CreateContact(It.IsAny<ContactModel>()), 
                    Times.Once);
            }
        }

        [TestFixture]
        public class TheUpdateMethod : ContactControllerTests
        {
            [Test]
            public void ShouldCallUpdateAndReturnSuccess()
            {
                var ctrl = GetController();
                ctrl.Update(0,new ContactModel());
                ContactService.Verify(x => x.UpdateContact(
                    It.IsAny<int>(), It.IsAny<ContactModel>()),
                    Times.Once);
            }
        }

        [TestFixture]
        public class TheDeleteMethod : ContactControllerTests
        {
            [Test]
            public void ShouldCallDeleteAndReturnSuccess()
            {
                var ctrl = GetController();
                ctrl.Delete(0);
                ContactService.Verify(x => x.DeleteContact(
                    It.IsAny<int>()),
                    Times.Once);
            }
        }
    }
}
