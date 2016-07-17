using System.Collections.Generic;
using AddressBook.Models;

namespace AddressBook.Service
{
    public interface IContactService
    {
        IEnumerable<ContactModel> GetContacts();
        ContactModel UpdateContact(int id, UpdateContactModel value);
        ContactModel CreateContact(CreateContactModel model);
    }
}