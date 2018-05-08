using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WNA4_API.Models;
using WNA4_API.Services;

namespace WNA4_API.Controllers
{
    public class CalendarController
    {
        CalendarRepository CalendarRepository;

        public CalendarController()
        {
            CalendarRepository = new CalendarRepository();
        }

        public JArray GetAllAvailableGolfersForDate(string date)
        {
            //TODO: Make sure this also returns the current users status for that date. Ie, if the user is available, include them in the list. Else, dont
            //TODO: Make func in repo
            //TODO: Call func
            return null;
        }

        public JArray GetAllAvailableDatesForUser(string userID)
        {
            //TODO: Make func in repo
            //TODO: Call func
            return null;
        }
    }
}