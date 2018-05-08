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
        
        public string LoginUser(string username, string passwordHash)
        {
            //TODO: Compare to values in database
            var user = AuthenticationRepository.Login(username, passwordHash);

            if (user == null)           return "";
            if (user.LoggedIn == false) return "";

            return user.AuthToken;
        }
        public bool LogoutUser(string userToken)
        {
            return AuthenticationRepository.Logout(userToken);
        }

        public bool CreateUser()
        {
            //TODO: Take in all the user's info (username, passhash, email, etc)
            return true;
        }
    }
}