using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace WNA__API_V3.Controllers
{
    [Authorize]
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        public ContactController()
        {
        }
        
        public JObject AddContact(string userID, string contactID)
        {
            return new JObject();
        }
        public JObject RemoveContact(string userID, string contactID)
        {
            return new JObject();
        }

        public JObject GetContact(string contactID)
        {
            return new JObject();
        }
        public JArray SearchContacts(string name)
        {
            return new JArray();
        }
        public JArray GetAllContacts()
        {
            return new JArray();
        }
    }
}
