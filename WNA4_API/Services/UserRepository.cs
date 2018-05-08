using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WNA4_API.Models;

namespace WNA4_API.Services
{
    public class UserRepository
    {
        private const string CacheKey = "ContactStore"; //TODO: ConnectionString instead of CacheKey

        public UserRepository()
        {
            //TODO: Nothing? Maybe check DB connection?
        }

        public User[] GetAllContacts()
        {
            return new User[]
            {
                new User
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }

        public bool SaveContact(User contact)
        {
            //TODO: Add to user's contact field
            return false;
        }

        public bool SetStatus(string status, string start, string end, string userToken)
        {

            return false;
        }
    }
}