using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace WNA__API_V3.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public UserController()
        {
        }
        
        public JObject GetUserID()
        {
            return new JObject();
        }
        public JObject GetUser(string userID)
        {
            return new JObject();
        }
        public JObject SetUserStatus(int userStatus, DateTime dateStart, DateTime dateEnd, bool isAllDay, bool isRecurring, string recurrencePattern, int userID)
        {
            return new JObject();
        }
    }
}
