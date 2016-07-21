using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressBook.Models;

namespace AddressBook.Service
{
    public class SessionContactService : IContactService
    {

        private IList<ContactModel> Contacts()
        {
            var session = HttpContext.Current.Session["Contacts"];
            if (session == null)
            { 
                HttpContext.Current.Session["Contacts"] = session = new List<ContactModel>();
            }
            return (IList<ContactModel>)session;
        }

        public IEnumerable<ContactModel> GetContacts()
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
