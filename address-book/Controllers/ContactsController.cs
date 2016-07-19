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
        // todo: use IoC container 
        readonly IContactService _service = new SessionContactService();

        [HttpGet, Route("contacts")]
        public dynamic Get()
        {
            var contacts = _service.GetContacts();
            return Request.CreateResponse(HttpStatusCode.Accepted, contacts);
        }

        [HttpPost, Route("contacts")]
        // POST api/values
        public dynamic Post([FromBody]ContactModel value)
        {
            _service.CreateContact(value);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        // PUT api/values/5
        [HttpPost, Route("contacts/{id}")]
        public dynamic Put([FromUri]int id, [FromBody]ContactModel value)
        {
            _service.UpdateContact(id, value);
            return Request.CreateResponse(HttpStatusCode.Accepted);

        }

        // DELETE api/values/5
        [HttpDelete, Route("contacts/{id}")]
        public dynamic Delete(int id)
        {
            _service.DeleteContact(id);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
