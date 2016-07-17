using System.Collections.Generic;
using System.Linq;
using AddressBook.Models;

namespace AddressBook.Service
{
    public class InProcContactService : IContactService
    {
        readonly IList<ContactModel> _contacts = new List<ContactModel>();

        public InProcContactService()
        {
            _contacts.Add(new ContactModel()
            {
                Key = 1,
                Name = "Rod Johnson",
                PhoneNumber = "385-352-6026"
            });
            _contacts.Add(new ContactModel()
            {
                Key = 2,
                Name = "Rod Smith",
                PhoneNumber = "385-352-6026"
            });
        }

        public IEnumerable<ContactModel> GetContacts()
        {
            return _contacts;
        }

        public ContactModel UpdateContact(int id, UpdateContactModel value)
        {
            var contact = _contacts.First(x => x.Key == id);

            contact.Name = value.Name;
            contact.PhoneNumber = value.PhoneNumber;

            return contact;
        }

        public ContactModel CreateContact(CreateContactModel model)
        {
            var contact = new ContactModel
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Key = _contacts.Count + 1
            };
            _contacts.Add(contact);

            return contact;
        }
    }
}
