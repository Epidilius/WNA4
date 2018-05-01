using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WNA4_API.Services;
using WNA4_API.Models;

namespace WNA4_API.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository ContactRepository;

        public ContactController()
        {
            ContactRepository = new ContactRepository();
        }

        public Contact[] Get()
        {
            return ContactRepository.GetAllContacts();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this.ContactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}
