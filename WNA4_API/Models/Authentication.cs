using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WNA4_API.Models
{
    public class Authentication
    {
        public bool LoggedIn { get; set; }
        public string AuthToken { get; set; }
    }
}