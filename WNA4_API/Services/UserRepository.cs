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
            var context = HttpContext.Current;

            if (context != null)
            {
                if (context.Cache[CacheKey] == null)
                {
                    var contacts = new User[]
                    {
                        new User
                        {
                            Id = 1, Name = "Glenn Block"
                        },
                        new User
                        {
                            Id = 2, Name = "Dan Roth"
                        }
                    };

                    context.Cache[CacheKey] = contacts;
                }
            }
        }

        public User[] GetAllContacts()
        {
            var context = HttpContext.Current;

            if (context != null)
            {
                return (User[])context.Cache[CacheKey];
            }

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
            var context = HttpContext.Current;

            if (context != null)
            {
                try
                {
                    var currentData = ((User[])context.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    context.Cache[CacheKey] = currentData.ToArray();

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