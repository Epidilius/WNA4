using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WNA4_API_V2
{
    //TODO: Figure out how to deal with race conditions
    //TODO: Add a string to the arguments list. This string is the user's validation token. 
    //TODO: Make a class to handle authentication
    //TODO: Among other functions, give that class the ability to validate a token
    //TODO: Give that class a function to make a new token every log in
    //TODO: Tell Adel to generate a new token and pass it on every open/login
    //TODO: Give the auth controller a GetNewToken or RefreshToken function
    //TODO: Instead of bools, use HttpResponseMessage
    //TODO: Functions to get user data, like email and number
    //TODO: If non-WNA4 user creation, I have to figure that out
    //TODO: https://stackoverflow.com/questions/5228111/how-to-send-automated-emails for creation and password resets

    public static class WNA4
    {
        //TODO: Partial classes for each broad category? Auth, Cal, User?
        public enum SignInType
        {
            WNA4 = 0,
            Google,
            Facebook
        }
        public enum UserStatusTypes
        {
            Available = 0,
            Unavailable
        }

        public static string Signin(SignInType signInType)  //TODO: Have this popup with the choice?
        {
            var userToken = "";

            switch (signInType)
            {
                case SignInType.WNA4:
                    userToken = "WNA4"; //TODO: Actual tokens
                    break;
                case SignInType.Google:
                    userToken = "Google"; //TODO: Actual tokens
                    break;
                case SignInType.Facebook:
                    userToken = "Facebook"; //TODO: Actual tokens
                    break;
            }

            return userToken;
        }

        //CONTACTS
        public static bool AddContact(string contactID, string userToken)
        {
            return DatabaseManager.AddContact(userToken, contactID);
        }
        public static bool RemoveContact(string contactID, string userToken)
        {
            return DatabaseManager.RemoveContact(userToken, contactID);
        }
        public static JObject GetContact(string contactID, string userToken)
        {
            var contactData = DatabaseManager.GetContact(contactID, userToken).Rows[0];

            //var objType = JArray.FromObject(contactData, JsonSerializer.CreateDefault(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })).FirstOrDefault(); // Get the first row            
            //var js = objType.ToString();

            JObject contact = new JObject
            {
                { "FirstName", Convert.ToString(contactData["FirstName"]) },
                { "LastName", Convert.ToString(contactData["LastName"]) },
                { "Email", Convert.ToString(contactData["Email"]) },
                { "PhoneNumber", Convert.ToString(contactData["PhoneNumber"]) }
            };

            return contact;
        }
        public static JArray SearchContacts(string userToken, string name)
        {
            JArray contactIDs = GetAllContacts(userToken);
            JArray contacts = new JArray();

            foreach (var id in contactIDs)
            {
                var contactData = DatabaseManager.GetContact(Convert.ToString(id), userToken);

                JObject contact = new JObject();
                contact.Add("ID", Convert.ToString(id));
                contact.Add("FirstName", Convert.ToString(contactData.Rows[0]["FirstName"]));
                contact.Add("LastName", Convert.ToString(contactData.Rows[0]["LastName"]));

                //TODO: Proper fuzzy matching. Maybe try https://en.wikipedia.org/wiki/Levenshtein_distance?
                if (contact["FirstName"].Value<string>().ToLower().Contains(name.ToLower()) || contact["LastName"].Value<string>().ToLower().Contains(name.ToLower()))
                {
                    contacts.Add(contact);
                }
            }

            return contacts;
        }
        public static JArray GetAllContacts(string userToken)
        {
            JArray contacts = new JArray();

            var contactString = Convert.ToString(DatabaseManager.GetAllContacts(userToken).Rows[0]["Contacts"]);
            foreach (var contact in contactString.Split('|'))
            {
                if (contact == String.Empty)
                {
                    continue;
                }

                contacts.Add(contact);
            }

            return contacts;
        }

        //USER
        public static int GetUserID(string userToken)
        {
            var userData = DatabaseManager.GetUserFromToken(userToken).Rows[0];
            var userID = Convert.ToInt32(userData["ID"]);

            return userID;
        }
        public static JObject GetUser(string userID, string userToken)
        {
            var userData = DatabaseManager.GetUserFromID(userID).Rows[0];

            JObject user = new JObject
            {
                { "FirstName", Convert.ToString(userData["FirstName"]) },
                { "LastName", Convert.ToString(userData["LastName"]) },
                { "Email", Convert.ToString(userData["Email"]) },
                { "PhoneNumber", Convert.ToString(userData["PhoneNumber"]) }
            };

            return user;
        }
        public static bool SetUserStatus(UserStatusTypes userStatus, DateTime dateStart, DateTime dateEnd, bool isAllDay, bool isRecurring, string recurrencePattern, int userID, string userToken)
        {
            return DatabaseManager.SetUserStatus((int)userStatus, dateStart, dateEnd, isAllDay, isRecurring, recurrencePattern, userID, userToken);
        }

        //CALENDAR
        public static JArray GetAllAvailableGolfersForDate(DateTime date, bool contactsOnly, string userToken)
        {
            //TODO: 
            var availableGolfers = DatabaseManager.GetAllAvailableGolfersForDate(date, userToken);
            var golferIDs = new JArray();

            foreach (System.Data.DataRow golfer in availableGolfers.Rows)
            {
                var golferID = new JObject()
                {
                    {"ID", Convert.ToString(golfer[0]) }
                };

                var match = golferIDs.FirstOrDefault(j => j.ToString().Equals(golferID.ToString()));

                if (match == null)
                    golferIDs.Add(golferID);
            }

            return golferIDs;
        }
        public static JArray GetAllAvailableDatesForUser(string userID, string userToken)
        {
            //TODO: 
            var dateData = DatabaseManager.GetAllAvailableDatesForUser(userID, userToken);
            var dates = new JArray();

            foreach (System.Data.DataRow date in dateData.Rows)
            {
                var startDate = Convert.ToDateTime(date[0]).AddDays(1);
                var endDate = Convert.ToDateTime(date[1]).AddDays(-1);

                var userDates = new JObject()
                {
                    { "StartDate", startDate },
                    { "EndDate", endDate }
                };

                dates.Add(userDates);
            }

            return dates;
        }

        //AUTHENTICATION
        public static bool NewUser(string firstName, string lastName, string email, string phoneNumber, string passwordHash)
        {
            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "LastName", lastName },
                { "FirstName", firstName },
                { "Email", email },
                { "PhoneNumber", phoneNumber },
                { "PasswordHash", passwordHash },
                { "UserStatus", UserStatusTypes.Available },
                { "UserToken", "" },
                { "Contacts", "" }
            };

            DatabaseManager.AddNewUser(values);
            return true;
        }
        public static string LoginUser(string email, string password)
        {
            var userToken = DatabaseManager.LoginUser(email, password);
            return userToken;
        }
        public static bool LogoutUser(string userToken)
        {
            //TODO: Clear the user token from the DB
            return false;
        }
    }
}
