using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WNA4_API_V2
{
    //TODO: https://stackoverflow.com/questions/5228111/how-to-send-automated-emails for creation and password resets
    public static class WNA4
    {
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
        
        public static class Authentication
        {
            public static string Signin(SignInType signInType) 
            {
                //TODO: Non-WNA4 authentication
                var userToken = "";

                switch (signInType)
                {
                    case SignInType.WNA4:
                        userToken = "WNA4";
                        break;
                    case SignInType.Google:
                        userToken = "Google";
                        break;
                    case SignInType.Facebook:
                        userToken = "Facebook";
                        break;
                }

                return userToken;
            }

            public static bool NewUser(string firstName, string lastName, string email, string phoneNumber, string password)
            {
                Dictionary<string, object> values = new Dictionary<string, object>()
                {
                    { "GUID", Guid.NewGuid() },
                    { "LastName", lastName },
                    { "FirstName", firstName },
                    { "Email", email },
                    { "PhoneNumber", phoneNumber },
                    { "PasswordHash", password },
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
                ValidateToken(userToken);

                var isLoggedOut = DatabaseManager.LogoutUser(userToken);

                return isLoggedOut;
            }

            public static void ValidateToken(string userToken)
            {
                var tokenValidation = DatabaseManager.ValidateToken(userToken);

                if (!tokenValidation.Validated)
                {
                    var message = "Invalid token. Reasons:\r\n";

                    for(int i = 0; i < tokenValidation.Errors.Count; i++)
                    {
                        message += "\r\n" + i + " " + tokenValidation.Errors[i];
                    }

                    throw new WNA4_Exceptions.InvalidTokenException(message);
                }
            }
        }
        public static class Calendar
        {
            public static JArray GetAllAvailableGolfersForDate(DateTime date, bool contactsOnly, string userToken)
            {
                Authentication.ValidateToken(userToken);

                var availableGolfers = DatabaseManager.GetAllAvailableGolfersForDate(date);
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
                Authentication.ValidateToken(userToken);

                var dateData = DatabaseManager.GetAllAvailableDatesForUser(userID);
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
        }
        public static class User
        {
            public static int GetUserID(string userToken)
            {
                Authentication.ValidateToken(userToken);

                var userData = DatabaseManager.GetUserFromToken(userToken).Rows[0];
                var userID = Convert.ToInt32(userData["ID"]);

                return userID;
            }
            public static JObject GetUser(string userID, string userToken)
            {
                Authentication.ValidateToken(userToken);

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
                Authentication.ValidateToken(userToken);
                return DatabaseManager.SetUserStatus((int)userStatus, dateStart, dateEnd, isAllDay, isRecurring, recurrencePattern, userID, userToken);
            }
        }
        public static class Contacts
        {
            public static bool AddContact(string contactID, string userToken)
            {
                Authentication.ValidateToken(userToken);
                return DatabaseManager.AddContact(userToken, contactID);
            }
            public static bool RemoveContact(string contactID, string userToken)
            {
                Authentication.ValidateToken(userToken);
                return DatabaseManager.RemoveContact(userToken, contactID);
            }

            public static JObject GetContact(string contactID, string userToken)
            {
                Authentication.ValidateToken(userToken);

                var contactData = DatabaseManager.GetContact(contactID).Rows[0];

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
            public static JArray SearchContacts(string name, string userToken)
            {
                Authentication.ValidateToken(userToken);

                JArray contactIDs = GetAllContacts(userToken);
                JArray contacts = new JArray();

                foreach (var id in contactIDs)
                {
                    var contactData = DatabaseManager.GetContact(Convert.ToString(id));

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
                Authentication.ValidateToken(userToken);

                JArray contacts = new JArray();

                var userID = Convert.ToString(DatabaseManager.GetUserFromToken(userToken).Rows[0]["ID"]);

                var contactString = Convert.ToString(DatabaseManager.GetAllContacts(userID).Rows[0]["Contacts"]);
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
        }
    }
}
