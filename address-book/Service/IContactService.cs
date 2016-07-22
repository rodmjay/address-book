using System.Collections.Generic;
using AddressBook.Models;

namespace AddressBook.Service
{
    public class MockContactService : IContactService
    {
        public IEnumerable<ContactModel> GetContacts()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateContact(int id, ContactModel value)
        {
            throw new System.NotImplementedException();
        }

        public void CreateContact(ContactModel model)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new System.NotImplementedException();
        }
    }
    public interface IContactService
    {
        IEnumerable<ContactModel> GetContacts();
        void UpdateContact(int id, ContactModel value);
        void CreateContact(ContactModel model);

        void DeleteContact(int id);
    }
}