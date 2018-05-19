using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace WNA4_API_V2
{
    public static class DatabaseManager
    {
        //TODO: Refactor this class
        static string ConnectionString = "Server=parallelzodiac.com; Port=3306; Database=WNA4; Uid=WNA4DBBoss;Pwd=Sch00n3r1!;SslMode=none";
        static string TOKEN_REASON_LOGIN = "USER LOGIN";
        private static readonly object _syncObject = new object();

        //Utility Functions
        static MySqlCommand CreateCommand(string query)
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);

            MySqlCommand command = new MySqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            return command;
        }
        static MySqlCommand CreateCommandWithArgs(string query, Dictionary<string, object> values)
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);

            MySqlCommand command = new MySqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;

            var firstHalf = "";
            var secondHalf = "";

            int i = 0;
            var firstLoop = true;

            foreach(KeyValuePair<string, object> value in values)
            {
                if(firstLoop)
                {
                    firstHalf += "(";
                    secondHalf += "(";
                    firstLoop = false;
                }
                else
                {
                    firstHalf += ", ";
                    secondHalf += ", ";
                }

                firstHalf += value.Key;
                secondHalf += "@val" + i.ToString();
                i++;
            }

            i = 0;
            firstHalf += ")";
            secondHalf += ")";

            query += firstHalf + " VALUES " + secondHalf;

            command.CommandText = query;

            foreach (KeyValuePair<string, object> value in values)
            {
                try
                {
                    if(!String.IsNullOrWhiteSpace(value.Value.ToString()))
                        command.Parameters.AddWithValue("@val" + i.ToString(), value.Value);
                    else
                        command.Parameters.AddWithValue("@val" + i.ToString(), "");
                }
                catch(Exception ex)
                {
                    command.Parameters.AddWithValue("@val" + i.ToString(), "");
                }
                i++;
            }

            return command;
        }
        static MySqlDataAdapter CreateDataAdapter(MySqlCommand command)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            return adapter;
        }
        static DataTable CreateDataTable(MySqlDataAdapter dataAdapter)
        {
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return table;
        }
        public static DataTable RunQuery(string query)
        {
            lock (_syncObject)
            {
                MySqlCommand command = CreateCommand(query);
                MySqlDataAdapter adapter = CreateDataAdapter(command);
                DataTable table = CreateDataTable(adapter);

                return table;
            }
        }
        public static DataTable RunQueryWithArgs(string query, Dictionary<string, object> values)  
        {
            lock (_syncObject)
            {
                MySqlCommand command = CreateCommandWithArgs(query, values);
                MySqlDataAdapter adapter = CreateDataAdapter(command);
                DataTable table = CreateDataTable(adapter);

                return table;
            }
        }

        //Get Functions
        public static DataTable GetUserFromToken(string userToken)
        {
            var query = "SELECT * FROM Users WHERE UserToken = \'" + userToken + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetUserFromID(string userID)
        {
            var query = "SELECT * FROM Users WHERE ID = \'" + userID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetUserFromEmail(string email)
        {
            var query = "SELECT * FROM Users WHERE Email = \'" + email + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetUser(string firstName, string lastName)
        {
            var query = "SELECT * FROM Users WHERE FirstName = \'" + firstName + "\' AND LastName = \'" + lastName + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetUserStatus(string userID)
        {
            var query = "SELECT UserStatus FROM Users WHERE ID = \'" + userID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetAllContacts(string userID)
        {
            var query = "SELECT Contacts FROM Users WHERE ID = \'" + userID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetContact(string contactID)
        {
            var query = "SELECT FirstName, LastName, Email, PhoneNumber FROM Users WHERE ID = \'" + contactID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetUserCalender(string userID)
        {
            var query = "SELECT Contacts FROM Users WHERE ID = \'" + userID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetAllAvailableDatesForUser(string userID)
        {
            var query = "SELECT StartDate, EndDate FROM GolferAvailability WHERE GolferID = \'" + userID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetAllAvailableGolfersForDate(DateTime date)
        {
            var query = "SELECT GolferID FROM GolferAvailability WHERE \'" + date + "\' BETWEEN StartDate AND EndDate AND Status = '1'";
            var dataTable = RunQuery(query);
            return dataTable;
        }

        //Auth Functions
        public static string LoginUser(string email, string password)
        {
            // Fetch the stored value 
            var userData = GetUserFromEmail(email);
            string savedPasswordHash = Convert.ToString(userData.Rows[0]["PasswordHash"]);

            if(!ValidatePassword(savedPasswordHash, password))
            {
                throw new WNA4_Exceptions.InvalidPassWordException();
            }

            var token = GenerateUserToken(TOKEN_REASON_LOGIN, Convert.ToString(userData.Rows[0]["GUID"]), Convert.ToString(userData.Rows[0]["ID"]));
            var tokenSet = SetUserToken(Convert.ToString(userData.Rows[0]["ID"]), token);
            if(!tokenSet)
            {
                throw new WNA4_Exceptions.InvalidTokenException("Token not set");
            }

            return token;
        }
        public static bool LogoutUser(string userToken)
        {
            var query = "UPDATE Users SET UserToken = \'\' WHERE UserToken = \'" + userToken + "\'";
            var dataTable = RunQuery(query);
            return true;
        }
        static string GenerateUserToken(string reason, string userGUID, string userID)
        {
            var token = UserToken.GenerateToken(reason, userGUID, userID);
            return token;
        }
        public static UserToken.TokenValidation ValidateToken(string userToken)
        {
            var user = GetUserFromToken(userToken);

            var tokenValidation = UserToken.ValidateToken(TOKEN_REASON_LOGIN, Convert.ToString(user.Rows[0]["GUID"]), Convert.ToString(user.Rows[0]["ID"]), userToken);
            return tokenValidation;
        }

        //Modify Functions
        public static bool AddContact(string userID, string contactID)
        {
            var query = "UPDATE Users SET Contacts = Contacts + \'|" + contactID + "\' WHERE ID = \'" + userID + "\'";
            RunQuery(query);
            return true;
        }
        public static bool RemoveContact(string userID, string contactID)
        {
            var matchIndex = -1;
            var contactString = Convert.ToString(GetAllContacts(userID).Rows[0]["Contacts"]);
            var contactList = contactString.Split('|').ToList();

            for (int i = 0; i < contactList.Count, i++)
            {
                var contact = contactList[i];
                if (contact == contactID)
                {
                    matchIndex = i;
                    break;
                }                
            }

            if(matchIndex == -1)
            {
                throw new WNA4_Exceptions.ContactDoesNotExistException();
            }

            contactList.RemoveAt(matchIndex);
            contactString = string.Empty;

            for(int i = 0; i < contactList.Count; i++)
            {
                if(i != 0)
                {
                    contactString += "|";
                }

                contactString += contactList[i];
            }

            var query = "UPDATE Users SET Contacts = Contacts + \'|" + contactString + "\' WHERE ID = \'" + userID + "\'";
            RunQuery(query);

            return true;
        }
        public static bool SetUserStatus(int eventType, DateTime dateStart, DateTime dateEnd, bool isAllDay, bool isRecurring, string recurrencePattern, int golferID, string userToken)
        {
            var query = "INSERT INTO GolferAvailability ";

            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "Status", eventType },
                { "StartDate", dateStart },
                { "EndDate", dateEnd },
                { "IsAllDay", isAllDay },
                { "IsRecurring", isRecurring },
                { "RecurrencePattern", recurrencePattern},
                { "GolferID", golferID }
            };

            var dataTable = RunQueryWithArgs(query, values);
                        
            return true;
        }
        static bool SetUserToken(string userID, string userToken)
        {
            var query = "UPDATE Users SET UserToken = \'" + userToken + "\' WHERE ID = \'" + userID + "\'";
            var results = RunQuery(query);
            return true;
        }

        //Create Functions
        public static void AddNewUser(Dictionary<string, object> values)
        {
            values["PasswordHash"] = HashPassword(Convert.ToString(values["PasswordHash"]));

            var query = "INSERT INTO Users ";
            var dataTable = RunQueryWithArgs(query, values);
        }

        //UTIL
        static string HashPassword(string password)
        {
            byte[] salt = new byte[16];

            new RNGCryptoServiceProvider().GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
        static bool ValidatePassword(string passwordHash, string password)
        {
            // Extract the bytes 
            byte[] hashBytes = Convert.FromBase64String(passwordHash);

            // Get the salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute the hash on the password the user entered 
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Compare the results 
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            //throw new UnauthorizedAccessException();

            return true;
        }
    }
}
