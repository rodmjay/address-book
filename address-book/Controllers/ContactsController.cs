using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBook.Models;
using AddressBook.Service;

namespace AddressBook.Controllers
{
    [RoutePrefix("api")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet, Route("contacts")]
        public dynamic Get()
        {
            var contacts = _contactService.GetContacts();
            return Request.CreateResponse(HttpStatusCode.Accepted, contacts);
        }

        [HttpPost, Route("contacts")]
        public dynamic Create([FromBody]ContactModel value)
        {
            _contactService.CreateContact(value);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpPost, Route("contacts/{id}")]
        public dynamic Update([FromUri]int id, [FromBody]ContactModel value)
        {
            _contactService.UpdateContact(id, value);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        [HttpDelete, Route("contacts/{id}")]
        public dynamic Delete([FromUri]int id)
        {
            _contactService.DeleteContact(id);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
