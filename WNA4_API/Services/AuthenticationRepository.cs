﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WNA4_API.Models;

namespace WNA4_API.Services
{
    public class AuthenticationRepository
    {
        const string AuthenticationConnectionString = "";   //TODO: Make a SQL database

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
            //TODO: Give authentication a bool for succesful, a string for token
            var context = HttpContext.Current;

            if(context != null)
            {
                return (Authentication)context.Cache[AuthenticationConnectionString];   //TODO: call a function to make a new token, add it to the DB, return
            }

            return new Authentication() { };    //TODO: Login
        }

        public bool Login(string loginInfo)
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                try
                {
                    var userAuthStatus = (Authentication)context.Cache[AuthenticationConnectionString];
                    userAuthStatus.AuthToken = loginInfo;
                    userAuthStatus.LoggedIn = true; //TODO: Funcs for these
                    context.Cache[AuthenticationConnectionString] = userAuthStatus;
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}