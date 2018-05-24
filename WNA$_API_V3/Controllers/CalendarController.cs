using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace WNA__API_V3.Controllers
{
    [Authorize]
    [RoutePrefix("api/Calendar")]
    public class CalendarController : ApiController
    {
        public CalendarController()
        {
        }

        public JArray GetAllAvailableGolfersForDate(DateTime date, bool contactsOnly)
        {
            return new JArray();
        }
        
        public JArray GetAllAvailableDatesForUser(string userID)
        {
            return new JArray();
        }
    }
}
