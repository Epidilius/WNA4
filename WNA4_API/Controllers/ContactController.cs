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
    //TODO: Add a string to the arguments list. This string is the user's validation token. 
    //TODO: Make a class to handle authentication
    //TODO: Among other functions, give that class the ability to validate a token
    //TODO: Give that class a function to make a new token every log in
    //TODO: Tell Adel to generate a new token and pass it on every open/login
    //TODO: Give the auth controller a GetNewToken or RefreshToken function
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
