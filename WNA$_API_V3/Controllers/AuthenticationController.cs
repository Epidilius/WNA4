using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace WNA__API_V3.Controllers
{
    [Authorize]
    [RoutePrefix("api/Authentication")] //TODO: Last, as backup
    public class AuthenticationController : ApiController
    {
        public AuthenticationController()
        {
        }

        // GET: Calendar
        public JArray GetAllAvailableGolfersForDate(DateTime date, bool contactsOnly)
        {
            return new JArray();
        }

        // GET: Calendar/Details/5
        public JArray GetAllAvailableDatesForUser(string userID)
        {
            return new JArray();
        }
    }
}
