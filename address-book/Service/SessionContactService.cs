using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Models;

namespace AddressBook.Service
{
    public class SessionContactService : IContactService
    {
        private readonly HttpSessionStateBase _sessionBase;

        public SessionContactService(HttpSessionStateBase sessionBase)
        {
            _sessionBase = sessionBase;
        }

        private IList<ContactModel> Contacts()
        {
            var session = _sessionBase["Contacts"];
            if (session == null)
            {
                _sessionBase["Contacts"] = session = new List<ContactModel>();
            }
            return (IList<ContactModel>)session;
        }

        public IList<ContactModel> GetContacts()
        {
            return Contacts();
        }

        public void UpdateContact(int id, ContactModel value)
        {
            var contact = Contacts()[id];

            contact.Name = value.Name;
            contact.PhoneNumber = value.PhoneNumber;
        }

        public void CreateContact(ContactModel model)
        {
            var contact = new ContactModel
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
            };
            Contacts().Add(contact);
        }

        public void DeleteContact(int id)
        {
            Contacts().RemoveAt(id);
        }
    }
}
