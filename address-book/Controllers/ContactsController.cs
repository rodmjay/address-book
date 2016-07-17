﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBook.Models;
using AddressBook.Service;

namespace AddressBook.Controllers
{
    [RoutePrefix("api")]
    public class ContactController : ApiController
    {
        readonly IContactService _service = new InProcContactService();

        [HttpGet, Route("contacts")]
        public dynamic Get()
        {
            var contacts = _service.GetContacts();
            return Request.CreateResponse(HttpStatusCode.Accepted, contacts);
        }

        [HttpPost, Route("contacts")]
        // POST api/values
        public dynamic Post([FromBody]CreateContactModel value)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]UpdateContactModel value)
        {
            _service.UpdateContact(id, value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
