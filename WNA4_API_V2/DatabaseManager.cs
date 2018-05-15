using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace WNA4_API_V2
{
    public static class DatabaseManager
    {
        //TODO: Refactor this class
        //TODO: Validate the user token everywhere I use it
        static string ConnectionString = @"Data Source=JOELSPC\SQLEXPRESSJOEL;Initial Catalog=WNA4;Integrated Security=True";
        private static readonly object _syncObject = new object();

        //Utility Functions
        static SqlCommand CreateCommand(string query)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = query;

            return command;
        }
        static SqlCommand CreateCommandWithArgs(string query, Dictionary<string, object> values)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
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
        static SqlDataAdapter CreateDataAdapter(SqlCommand command)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            return adapter;
        }
        static DataTable CreateDataTable(SqlDataAdapter dataAdapter)
        {
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return table;
        }
        public static DataTable RunQuery(string query)
        {
            lock (_syncObject)
            {
                SqlCommand command = CreateCommand(query);
                SqlDataAdapter adapter = CreateDataAdapter(command);
                DataTable table = CreateDataTable(adapter);

                return table;
            }
        }
        public static DataTable RunQueryWithArgs(string query, Dictionary<string, object> values)  
        {
            lock (_syncObject)
            {
                SqlCommand command = CreateCommandWithArgs(query, values);
                SqlDataAdapter adapter = CreateDataAdapter(command);
                DataTable table = CreateDataTable(adapter);

                return table;
            }
        }

        //Get Functions
        public static DataTable GetUserFromToken(string userToken)   //TODO: Return types for all of these
        {
            var dataTable = RunQuery("SELECT * FROM Users WHERE UserToken = \'" + userToken + "\'");
            return dataTable;
        }
        public static DataTable GetUserFromID(string userID)   //TODO: Return types for all of these
        {
            var dataTable = RunQuery("SELECT * FROM Users WHERE ID = \'" + userID + "\'");
            return dataTable;
        }
        public static DataTable GetUserFromEmail(string email)   //TODO: Return types for all of these
        {
            var dataTable = RunQuery("SELECT * FROM Users WHERE Email = \'" + email + "\'");
            return dataTable;
        }
        public static DataTable GetUser(string firstName, string lastName)
        {
            var dataTable = RunQuery("SELECT * FROM Users WHERE FirstName = \'" + firstName + "\' AND LastName = \'" + lastName + "\'");
            return dataTable;
        }
        public static DataTable GetUserStatus(string userToken)
        {
            var dataTable = RunQuery("SELECT UserStatus FROM Users WHERE ID = \'" + userToken + "\'");
            return dataTable;
        }
        public static DataTable GetAllContacts(string userToken)
        {
            //TODO: Here and everywhere else, make the query a variable and pass that var
            var dataTable = RunQuery("SELECT Contacts FROM Users WHERE UserToken = \'" + userToken + "\'");
            return dataTable;
        }
        public static DataTable GetContact(string contactID, string userToken)  //TODO: Make a function that takes a name?
        {
            var query = "SELECT FirstName, LastName, Email, PhoneNumber FROM Users WHERE ID = \'" + contactID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetUserCalender(string userToken)
        {   
            var dataTable = RunQuery("SELECT Contacts FROM Users WHERE ID = \'" + userToken + "\'");
            return dataTable;
        }
        public static DataTable GetAllAvailableDatesForUser(string userID, string userToken)
        {
            var query = "SELECT StartDate, EndDate FROM AvailabilityByDate WHERE GolferID = \'" + userID + "\'";
            var dataTable = RunQuery(query);
            return dataTable;
        }
        public static DataTable GetAllAvailableGolfersForDate(DateTime date, string userToken)
        {
            var query = "SELECT GolferID FROM AvailabilityByDate WHERE \'" + date + "\' BETWEEN StartDate AND EndDate AND EventID = '1'";
            var dataTable = RunQuery(query);
            return dataTable;
        }

        //Auth Functions
        public static string LoginUser(string email, string password)
        {
            // Fetch the stored value 
            var userData = GetUserFromEmail(email);
            string savedPasswordHash = Convert.ToString(userData.Rows[0]["PasswordHash"]);

            // Extract the bytes 
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            // Get the salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute the hash on the password the user entered 
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000); //TODO: Move the 10000 to the config file
            byte[] hash = pbkdf2.GetBytes(20);

            // Compare the results 
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return String.Empty;
                    //throw new UnauthorizedAccessException();

            var token = GenerateUserToken();
            var tokenSet = SetuserToken(Convert.ToString(userData.Rows[0]["ID"]), token);
            if(!tokenSet)
            {
                //TODO: Throw exception? Do this. Extend the Exception class and make some custom exceptions Adel can catch
                return String.Empty;
            }

            return token;
        }
        public static bool LogoutUser(string userToken)
        {
            //TODO:
            return false;
        }
        static string GenerateUserToken()
        {
            //Take a look at Walter's answer: https://stackoverflow.com/questions/14643735/how-to-generate-a-unique-token-which-expires-after-24-hours
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(token, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        //Modify Functions
        public static bool AddContact(string userToken, string contactID)
        {
            //TODO: Append to contact list

            return true;
        }
        public static bool RemoveContact(string userToken, string contactID)
        {
            //TODO: Get contacts, remove ID from list, update contacts

            return true;
        }
        public static bool SetUserStatus(int eventType, DateTime dateStart, DateTime dateEnd, bool isAllDay, bool isRecurring, string recurrencePattern, int golferID, string userToken)
        {
            //TODO: Should I take eventID? Then just add users and remove them from the events 1 and 2?

            var query = "INSERT INTO AvailabilityByDate ";

            Dictionary<string, object> values = new Dictionary<string, object>()
            {
                { "EventID", eventType },
                { "StartDate", dateStart },
                { "EndDate", dateEnd },
                { "IsAllDay", isAllDay },
                { "IsRecurring", isRecurring },
                { "RecurrencePattern", recurrencePattern},
                { "GolferID", golferID }
            };

            var dataTable = RunQueryWithArgs(query, values);

            //var userQuery = "UPDATE AvailabilityByGolfer SET Dates = Dates + \'|" + "\'";
            
            return true;
        }
        static bool SetuserToken(string userID, string userToken)
        {
            var query = "UPDATE Users SET UserToken = \'" + userToken + "\' WHERE ID = \'" + userID + "\'";
            var results = RunQuery(query);
            //TODO: Check for success, don't just assume. At least throw a try/catch around this
            return true;
        }

        //Create Functions
        public static void AddNewUser(Dictionary<string, object> values)
        {
            var query = "INSERT INTO Users ";
            RunQueryWithArgs(query, values);

            var dateQuery = ""; //TODO: Set the availability tables to ""
            var userQuery = "";
        }
    }
}
