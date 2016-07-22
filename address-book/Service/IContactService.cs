using System.Collections.Generic;
using AddressBook.Models;

namespace AddressBook.Service
{
    public interface IContactService
    {
        IList<ContactModel> GetContacts();
        void UpdateContact(int id, ContactModel value);
        void CreateContact(ContactModel model);
        void DeleteContact(int id);
    }
}