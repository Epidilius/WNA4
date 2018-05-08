using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WNA4_API.Services;
using WNA4_API.Models;
using Newtonsoft.Json.Linq;

namespace WNA4_API.Controllers
{
    //TODO: Add a string to the arguments list. This string is the user's validation token. 
    //TODO: Make a class to handle authentication
    //TODO: Among other functions, give that class the ability to validate a token
    //TODO: Give that class a function to make a new token every log in
    //TODO: Tell Adel to generate a new token and pass it on every open/login
    //TODO: Give the auth controller a GetNewToken or RefreshToken function
    //TODO: Instead of bools, use HttpResponseMessage
    public class UserController : ApiController
    {
        private UserRepository UserRepository;

        public UserController()
        {
            UserRepository = new UserRepository();
        }

        //CONTACT RELATED
        public User[] GetAllContacts(string userID, string userToken)
        {
            return UserRepository.GetAllContacts();
        }
        public HttpResponseMessage AddNewContact(string contactID, string userToken)
        {
            //this.UserRepository.SaveContact(userID);

            var response = Request.CreateResponse(HttpStatusCode.Created, contactID);

            return response;
        }
        public HttpResponseMessage RemoveContact(string contactID, string userToken)
        {
            //this.UserRepository.SaveContact(contact);

            var response = Request.CreateResponse(HttpStatusCode.Created, contactID);

            return response;
        }
        public JArray SearchContacts(string name)
        {
            //TODO: Add func to repo
            //TODO: Fuzzy search
            //TODO: Call func
            //TODO: Return all responses
            return null;
        }

        public bool SetUserStatus(string status, string start, string end, string userToken)
        {
            return UserRepository.SetStatus(status, start, end, userToken);
        }
    }
}
