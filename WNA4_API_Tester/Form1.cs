using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WNA4_API_V2;

namespace WNA4_API_Tester
{
    public partial class Form1 : Form
    {
        string UserToken;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_CreateUser_Click(object sender, EventArgs e)
        {
            var email = textBox_Create_FirstName.Text + "." + textBox_Create_Lastname.Text + "@gmail.com";
            var phoneNumber = "6138500226";
            var password = "Sch00n3r1!";
            
            var passwordHash = HashPassword(password);

            var userCreated = WNA4.NewUser(textBox_Create_FirstName.Text, textBox_Create_Lastname.Text, email, phoneNumber, passwordHash);
        }

        private void button_SearchByName_Click(object sender, EventArgs e)
        {
            var contacts = WNA4.SearchContacts(UserToken, textBox_Search_FirstName.Text);
            UpdateGridView(contacts);
        }

        private void button_Search_ID_Click(object sender, EventArgs e)
        {
            var contact = WNA4.GetContact(textBox_Search_ID.Text, UserToken);
            UpdateGridView(JArray.FromObject(contact));
        }

        private void button_UpdateStatus_Click(object sender, EventArgs e)
        {
            var status = (WNA4.UserStatusTypes)comboBox_UserStatusTypes.SelectedIndex + 1;

            var statusSet = WNA4.SetUserStatus(status, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), true, false, "", WNA4.GetUserID(UserToken), UserToken);
        }

        private void button_SignIn_Click(object sender, EventArgs e)
        {
            var userToken = WNA4.Signin(WNA4.SignInType.WNA4);
        }

        private void UserSelected(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_FindAllGolfers_Click(object sender, EventArgs e)
        {
            var allGolfers = WNA4.GetAllAvailableGolfersForDate(DateTime.Today, checkBox_ContactsOnly.Checked, UserToken);
        }
        private void button_DateTimeSearch_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime(Convert.ToInt32(textBox_DateTimeSearch_Year.Text), Convert.ToInt32(textBox_DateTimeSearch_Month.Text), Convert.ToInt32(textBox_DateTimeSearch_Day.Text));

            var allGolfers = WNA4.GetAllAvailableGolfersForDate(date, checkBox_ContactsOnly.Checked, UserToken);
        }
        private void button_DateByUser_Click(object sender, EventArgs e)
        {
            var dates = WNA4.GetAllAvailableDatesForUser(textBox_DateSearchByUser.Text, UserToken);
        }

        private void button_SignInHard_Click(object sender, EventArgs e)
        {
            UserToken = WNA4.LoginUser(textBox_SignIn_Email.Text, textBox_SignIn_Password.Text);
        }

        //Util
        string HashPassword(string password)
        {
            byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        void UpdateGridView(JArray contacts)
        {
            dataGridView_Results.DataSource = contacts;
        }
    }
}
