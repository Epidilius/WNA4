using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WNA4_API.Models;
using WNA4_API.Services;

namespace WNA4_API.Controllers
{
    public class AuthenticationController : ApiController
    {
        AuthenticationRepository AuthenticationRepository;

        public AuthenticationController()
        {
            AuthenticationRepository = new AuthenticationRepository();
        }

        public Authentication GetNewToken()
        {
            return AuthenticationRepository.RefreshToken();
        }

        public HttpResponseMessage Post(string loginInfo)   //TODO: Multiple Login funcs, for different types (ie, GOogle, Facbeook, email, etc)
        {
            AuthenticationRepository.Login(loginInfo);

            var response = Request.CreateResponse<Authentication>(System.Net.HttpStatusCode.Created, loginInfo);

            return response;
        }
    }
}