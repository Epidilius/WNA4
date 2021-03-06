﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WNA4_API.Models;

namespace WNA4_API.Services
{
    public class AuthenticationRepository
    {
        //TODO: Make a SQL database
        string AuthenticationConnectionString = ConfigurationManager.ConnectionStrings["WNA4Database"].ConnectionString;

        public AuthenticationRepository()
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                if (context.Cache[AuthenticationConnectionString] == null)
                {
                    var contacts = new Authentication[]
                    {
                        new Authentication
                        {
                            //TODO: Generate key?
                        },
                    };

                    context.Cache[AuthenticationConnectionString] = contacts;
                }
            }
        }

        public Authentication RefreshToken()
        {
            var context = HttpContext.Current;

            if(context != null)
            {
                return (Authentication)context.Cache[AuthenticationConnectionString];   //TODO: call a function to make a new token, add it to the DB, return
            }

            return new Authentication() { };    //TODO: Login
        }

        public Authentication Login(string username, string passwordHash)
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                try
                {
                    var userAuthStatus = (Authentication)context.Cache[AuthenticationConnectionString];
                    userAuthStatus.AuthToken = username + passwordHash;
                    userAuthStatus.LoggedIn = true; //TODO: Funcs for these
                    context.Cache[AuthenticationConnectionString] = userAuthStatus;
                    return userAuthStatus;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

            return null;
        }

        public bool Logout(string userToken)
        {
            //TODO: Clear the token in the database
            return true;
        }
    }
}