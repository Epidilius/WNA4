namespace WNA4_API_Tester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Create_FirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Create_Lastname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_CreateUser = new System.Windows.Forms.Button();
            this.button_SearchByName = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Search_FirstName = new System.Windows.Forms.TextBox();
            this.button_Search_ID = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Search_ID = new System.Windows.Forms.TextBox();
            this.dataGridView_Results = new System.Windows.Forms.DataGridView();
            this.comboBox_UserStatusTypes = new System.Windows.Forms.ComboBox();
            this.button_UpdateStatus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_ContactsOnly = new System.Windows.Forms.CheckBox();
            this.button_FindAllGolfers = new System.Windows.Forms.Button();
            this.button_SignIn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_SignIn_Email = new System.Windows.Forms.TextBox();
            this.button_SignInHard = new System.Windows.Forms.Button();
            this.textBox_SignIn_Password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_DateTimeSearch_Year = new System.Windows.Forms.TextBox();
            this.checkBox_DateSearch_ContactsOnly = new System.Windows.Forms.CheckBox();
            this.button_DateTimeSearch = new System.Windows.Forms.Button();
            this.button_DateByUser = new System.Windows.Forms.Button();
            this.checkBox_UserSearch_ContactsOnly = new System.Windows.Forms.CheckBox();
            this.textBox_DateSearchByUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_DateTimeSearch_Month = new System.Windows.Forms.TextBox();
            this.textBox_DateTimeSearch_Day = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Results)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Create_FirstName
            // 
            this.textBox_Create_FirstName.Location = new System.Drawing.Point(6, 32);
            this.textBox_Create_FirstName.Name = "textBox_Create_FirstName";
            this.textBox_Create_FirstName.Size = new System.Drawing.Size(100, 20);
            this.textBox_Create_FirstName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // textBox_Create_Lastname
            // 
            this.textBox_Create_Lastname.Location = new System.Drawing.Point(6, 71);
            this.textBox_Create_Lastname.Name = "textBox_Create_Lastname";
            this.textBox_Create_Lastname.Size = new System.Drawing.Size(100, 20);
            this.textBox_Create_Lastname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Search Results";
            // 
            // button_CreateUser
            // 
            this.button_CreateUser.Location = new System.Drawing.Point(7, 98);
            this.button_CreateUser.Name = "button_CreateUser";
            this.button_CreateUser.Size = new System.Drawing.Size(99, 29);
            this.button_CreateUser.TabIndex = 7;
            this.button_CreateUser.Text = "Create User";
            this.button_CreateUser.UseVisualStyleBackColor = true;
            this.button_CreateUser.Click += new System.EventHandler(this.button_CreateUser_Click);
            // 
            // button_SearchByName
            // 
            this.button_SearchByName.Location = new System.Drawing.Point(4, 58);
            this.button_SearchByName.Name = "button_SearchByName";
            this.button_SearchByName.Size = new System.Drawing.Size(101, 29);
            this.button_SearchByName.TabIndex = 12;
            this.button_SearchByName.Text = "Search";
            this.button_SearchByName.UseVisualStyleBackColor = true;
            this.button_SearchByName.Click += new System.EventHandler(this.button_SearchByName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name";
            // 
            // textBox_Search_FirstName
            // 
            this.textBox_Search_FirstName.Location = new System.Drawing.Point(6, 32);
            this.textBox_Search_FirstName.Name = "textBox_Search_FirstName";
            this.textBox_Search_FirstName.Size = new System.Drawing.Size(100, 20);
            this.textBox_Search_FirstName.TabIndex = 8;
            // 
            // button_Search_ID
            // 
            this.button_Search_ID.Location = new System.Drawing.Point(6, 172);
            this.button_Search_ID.Name = "button_Search_ID";
            this.button_Search_ID.Size = new System.Drawing.Size(100, 29);
            this.button_Search_ID.TabIndex = 17;
            this.button_Search_ID.Text = "Search";
            this.button_Search_ID.UseVisualStyleBackColor = true;
            this.button_Search_ID.Click += new System.EventHandler(this.button_Search_ID_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "User ID";
            // 
            // textBox_Search_ID
            // 
            this.textBox_Search_ID.Location = new System.Drawing.Point(6, 146);
            this.textBox_Search_ID.Name = "textBox_Search_ID";
            this.textBox_Search_ID.Size = new System.Drawing.Size(100, 20);
            this.textBox_Search_ID.TabIndex = 13;
            // 
            // dataGridView_Results
            // 
            this.dataGridView_Results.AllowUserToAddRows = false;
            this.dataGridView_Results.AllowUserToDeleteRows = false;
            this.dataGridView_Results.AllowUserToOrderColumns = true;
            this.dataGridView_Results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Results.Location = new System.Drawing.Point(135, 25);
            this.dataGridView_Results.MultiSelect = false;
            this.dataGridView_Results.Name = "dataGridView_Results";
            this.dataGridView_Results.ReadOnly = true;
            this.dataGridView_Results.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Results.Size = new System.Drawing.Size(590, 492);
            this.dataGridView_Results.TabIndex = 18;
            this.dataGridView_Results.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserSelected);
            // 
            // comboBox_UserStatusTypes
            // 
            this.comboBox_UserStatusTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserStatusTypes.FormattingEnabled = true;
            this.comboBox_UserStatusTypes.Items.AddRange(new object[] {
            "Available",
            "Unavailable",
            "Invisible"});
            this.comboBox_UserStatusTypes.Location = new System.Drawing.Point(731, 24);
            this.comboBox_UserStatusTypes.Name = "comboBox_UserStatusTypes";
            this.comboBox_UserStatusTypes.Size = new System.Drawing.Size(121, 21);
            this.comboBox_UserStatusTypes.TabIndex = 19;
            // 
            // button_UpdateStatus
            // 
            this.button_UpdateStatus.Location = new System.Drawing.Point(731, 51);
            this.button_UpdateStatus.Name = "button_UpdateStatus";
            this.button_UpdateStatus.Size = new System.Drawing.Size(121, 29);
            this.button_UpdateStatus.TabIndex = 20;
            this.button_UpdateStatus.Text = "Update Status";
            this.button_UpdateStatus.UseVisualStyleBackColor = true;
            this.button_UpdateStatus.Click += new System.EventHandler(this.button_UpdateStatus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Create_FirstName);
            this.groupBox1.Controls.Add(this.textBox_Create_Lastname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_CreateUser);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 134);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_ContactsOnly);
            this.groupBox2.Controls.Add(this.button_FindAllGolfers);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_Search_FirstName);
            this.groupBox2.Controls.Add(this.button_SearchByName);
            this.groupBox2.Controls.Add(this.button_Search_ID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_Search_ID);
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 365);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // checkBox_ContactsOnly
            // 
            this.checkBox_ContactsOnly.AutoSize = true;
            this.checkBox_ContactsOnly.Location = new System.Drawing.Point(5, 313);
            this.checkBox_ContactsOnly.Name = "checkBox_ContactsOnly";
            this.checkBox_ContactsOnly.Size = new System.Drawing.Size(92, 17);
            this.checkBox_ContactsOnly.TabIndex = 19;
            this.checkBox_ContactsOnly.Text = "Contacts Only";
            this.checkBox_ContactsOnly.UseVisualStyleBackColor = true;
            // 
            // button_FindAllGolfers
            // 
            this.button_FindAllGolfers.Location = new System.Drawing.Point(5, 336);
            this.button_FindAllGolfers.Name = "button_FindAllGolfers";
            this.button_FindAllGolfers.Size = new System.Drawing.Size(100, 29);
            this.button_FindAllGolfers.TabIndex = 18;
            this.button_FindAllGolfers.Text = "Find All Golfers";
            this.button_FindAllGolfers.UseVisualStyleBackColor = true;
            this.button_FindAllGolfers.Click += new System.EventHandler(this.button_FindAllGolfers_Click);
            // 
            // button_SignIn
            // 
            this.button_SignIn.Location = new System.Drawing.Point(731, 86);
            this.button_SignIn.Name = "button_SignIn";
            this.button_SignIn.Size = new System.Drawing.Size(121, 29);
            this.button_SignIn.TabIndex = 23;
            this.button_SignIn.Text = "Sign In User";
            this.button_SignIn.UseVisualStyleBackColor = true;
            this.button_SignIn.Click += new System.EventHandler(this.button_SignIn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_SignIn_Email);
            this.groupBox3.Controls.Add(this.button_SignInHard);
            this.groupBox3.Controls.Add(this.textBox_SignIn_Password);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(858, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(553, 148);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sign In";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email";
            // 
            // textBox_SignIn_Email
            // 
            this.textBox_SignIn_Email.Location = new System.Drawing.Point(6, 36);
            this.textBox_SignIn_Email.Name = "textBox_SignIn_Email";
            this.textBox_SignIn_Email.Size = new System.Drawing.Size(541, 20);
            this.textBox_SignIn_Email.TabIndex = 8;
            this.textBox_SignIn_Email.Text = "john.doe@gmail.com";
            // 
            // button_SignInHard
            // 
            this.button_SignInHard.Location = new System.Drawing.Point(7, 102);
            this.button_SignInHard.Name = "button_SignInHard";
            this.button_SignInHard.Size = new System.Drawing.Size(99, 29);
            this.button_SignInHard.TabIndex = 12;
            this.button_SignInHard.Text = "Sign in";
            this.button_SignInHard.UseVisualStyleBackColor = true;
            this.button_SignInHard.Click += new System.EventHandler(this.button_SignInHard_Click);
            // 
            // textBox_SignIn_Password
            // 
            this.textBox_SignIn_Password.Location = new System.Drawing.Point(6, 75);
            this.textBox_SignIn_Password.Name = "textBox_SignIn_Password";
            this.textBox_SignIn_Password.Size = new System.Drawing.Size(541, 20);
            this.textBox_SignIn_Password.TabIndex = 10;
            this.textBox_SignIn_Password.Text = "Sch00n3r1!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(731, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Availability By Date";
            // 
            // textBox_DateTimeSearch_Year
            // 
            this.textBox_DateTimeSearch_Year.Location = new System.Drawing.Point(732, 227);
            this.textBox_DateTimeSearch_Year.Name = "textBox_DateTimeSearch_Year";
            this.textBox_DateTimeSearch_Year.Size = new System.Drawing.Size(120, 20);
            this.textBox_DateTimeSearch_Year.TabIndex = 26;
            // 
            // checkBox_DateSearch_ContactsOnly
            // 
            this.checkBox_DateSearch_ContactsOnly.AutoSize = true;
            this.checkBox_DateSearch_ContactsOnly.Location = new System.Drawing.Point(732, 254);
            this.checkBox_DateSearch_ContactsOnly.Name = "checkBox_DateSearch_ContactsOnly";
            this.checkBox_DateSearch_ContactsOnly.Size = new System.Drawing.Size(92, 17);
            this.checkBox_DateSearch_ContactsOnly.TabIndex = 27;
            this.checkBox_DateSearch_ContactsOnly.Text = "Contacts Only";
            this.checkBox_DateSearch_ContactsOnly.UseVisualStyleBackColor = true;
            // 
            // button_DateTimeSearch
            // 
            this.button_DateTimeSearch.Location = new System.Drawing.Point(732, 282);
            this.button_DateTimeSearch.Name = "button_DateTimeSearch";
            this.button_DateTimeSearch.Size = new System.Drawing.Size(75, 23);
            this.button_DateTimeSearch.TabIndex = 28;
            this.button_DateTimeSearch.Text = "Search";
            this.button_DateTimeSearch.UseVisualStyleBackColor = true;
            this.button_DateTimeSearch.Click += new System.EventHandler(this.button_DateTimeSearch_Click);
            // 
            // button_DateByUser
            // 
            this.button_DateByUser.Location = new System.Drawing.Point(732, 380);
            this.button_DateByUser.Name = "button_DateByUser";
            this.button_DateByUser.Size = new System.Drawing.Size(75, 23);
            this.button_DateByUser.TabIndex = 32;
            this.button_DateByUser.Text = "Search";
            this.button_DateByUser.UseVisualStyleBackColor = true;
            this.button_DateByUser.Click += new System.EventHandler(this.button_DateByUser_Click);
            // 
            // checkBox_UserSearch_ContactsOnly
            // 
            this.checkBox_UserSearch_ContactsOnly.AutoSize = true;
            this.checkBox_UserSearch_ContactsOnly.Location = new System.Drawing.Point(732, 352);
            this.checkBox_UserSearch_ContactsOnly.Name = "checkBox_UserSearch_ContactsOnly";
            this.checkBox_UserSearch_ContactsOnly.Size = new System.Drawing.Size(92, 17);
            this.checkBox_UserSearch_ContactsOnly.TabIndex = 31;
            this.checkBox_UserSearch_ContactsOnly.Text = "Contacts Only";
            this.checkBox_UserSearch_ContactsOnly.UseVisualStyleBackColor = true;
            // 
            // textBox_DateSearchByUser
            // 
            this.textBox_DateSearchByUser.Location = new System.Drawing.Point(732, 325);
            this.textBox_DateSearchByUser.Name = "textBox_DateSearchByUser";
            this.textBox_DateSearchByUser.Size = new System.Drawing.Size(673, 20);
            this.textBox_DateSearchByUser.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(731, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Avialability By User";
            // 
            // textBox_DateTimeSearch_Month
            // 
            this.textBox_DateTimeSearch_Month.Location = new System.Drawing.Point(858, 227);
            this.textBox_DateTimeSearch_Month.Name = "textBox_DateTimeSearch_Month";
            this.textBox_DateTimeSearch_Month.Size = new System.Drawing.Size(120, 20);
            this.textBox_DateTimeSearch_Month.TabIndex = 33;
            // 
            // textBox_DateTimeSearch_Day
            // 
            this.textBox_DateTimeSearch_Day.Location = new System.Drawing.Point(984, 227);
            this.textBox_DateTimeSearch_Day.Name = "textBox_DateTimeSearch_Day";
            this.textBox_DateTimeSearch_Day.Size = new System.Drawing.Size(120, 20);
            this.textBox_DateTimeSearch_Day.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 529);
            this.Controls.Add(this.textBox_DateTimeSearch_Day);
            this.Controls.Add(this.textBox_DateTimeSearch_Month);
            this.Controls.Add(this.button_DateByUser);
            this.Controls.Add(this.checkBox_UserSearch_ContactsOnly);
            this.Controls.Add(this.textBox_DateSearchByUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_DateTimeSearch);
            this.Controls.Add(this.checkBox_DateSearch_ContactsOnly);
            this.Controls.Add(this.textBox_DateTimeSearch_Year);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_SignIn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_UpdateStatus);
            this.Controls.Add(this.comboBox_UserStatusTypes);
            this.Controls.Add(this.dataGridView_Results);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Results)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Create_FirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Create_Lastname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_CreateUser;
        private System.Windows.Forms.Button button_SearchByName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Search_FirstName;
        private System.Windows.Forms.Button button_Search_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Search_ID;
        private System.Windows.Forms.DataGridView dataGridView_Results;
        private System.Windows.Forms.ComboBox comboBox_UserStatusTypes;
        private System.Windows.Forms.Button button_UpdateStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_SignIn;
        private System.Windows.Forms.Button button_FindAllGolfers;
        private System.Windows.Forms.CheckBox checkBox_ContactsOnly;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_SignIn_Email;
        private System.Windows.Forms.Button button_SignInHard;
        private System.Windows.Forms.TextBox textBox_SignIn_Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_DateTimeSearch_Year;
        private System.Windows.Forms.CheckBox checkBox_DateSearch_ContactsOnly;
        private System.Windows.Forms.Button button_DateTimeSearch;
        private System.Windows.Forms.Button button_DateByUser;
        private System.Windows.Forms.CheckBox checkBox_UserSearch_ContactsOnly;
        private System.Windows.Forms.TextBox textBox_DateSearchByUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_DateTimeSearch_Month;
        private System.Windows.Forms.TextBox textBox_DateTimeSearch_Day;
    }
}

