using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Result_Analysis_for_NBA.Settings
{
    public partial class frmRegistration_Form : Form
    {
        public frmRegistration_Form()
        {
            InitializeComponent();
        }
        public string username;
        public bool update=false;
        public string u_name, pusername, password, ptype, security, answer, email, mobileno;
        private void frmRegistration_Form_Load(object sender, EventArgs e)
        {
            //edit form
            if (update)
            {
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();
                foreach (User i in put)
                {
                    if (username == i.username)
                    {
                        //fill all the field by retriving information from database
                        txtname.Text = i.name;
                        txtusername.Text = i.username;
                        txtpassword.Text = i.password;
                        txtpassword.PasswordChar = '*';
                        txtconfirmpass.Text = i.password;
                        if (i.type == "Admin")
                            rdAdmin.Checked = true;
                        else
                            rdStaff.Checked = true;
                        txtconfirmpass.PasswordChar = '*';
                        txtemail.Text = i.email;
                        combosecurity.Text = i.security;
                        txtanswer.Text = i.answer;
                        txtmobile.Text = i.mobileno;
                        break;
                    }
                }
                btnsubmit.Text = "Update";
                //cannot change username
                txtusername.Enabled = false;
            }
                //(if not udo not want update means) new registration
            else
            {
                txtname.Text = "Enter name";
                txtname.ForeColor = Color.Gray;
                txtusername.Text = "Enter username";
                txtusername.ForeColor = Color.Gray;
                txtpassword.Text = "Enter password";
                txtpassword.ForeColor = Color.Gray;
                txtconfirmpass.Text = "Confirm password";
                txtconfirmpass.ForeColor = Color.Gray;
                txtemail.Text = "E.g. aishjagtap450@gmail.com";
                txtemail.ForeColor = Color.Gray;
                combosecurity.Text = "Choose any security question";
                combosecurity.ForeColor = Color.Gray;
                txtmobile.Text = "Enter 10 digit no.";
                txtmobile.ForeColor = Color.Gray;
            }
        }

        //validation of name
        private void txtname_Enter(object sender, EventArgs e)
        {
            if(txtname.Modified==false)
                txtname.Text = "";
            txtname.ForeColor = Color.Black;
        }


        private void txtname_Leave(object sender, EventArgs e)
        {
                
            if (txtname.Modified == false || txtname.Text == "")
            {
                txtname.Text = "Enter name";
                txtname.ForeColor = Color.Gray;
            }
        }

        //validation for username
        private void txtusername_Enter(object sender, EventArgs e)
        {
            if(txtusername.Modified== false)
                txtusername.Text = "";
            txtusername.ForeColor = Color.Black;
        }

        //leave event
        private void txtusername_Leave(object sender, EventArgs e)
        {
            if (txtusername.Modified == false || txtusername.Text == "")
            {
                txtusername.Text = "Enter username";
                txtusername.ForeColor = Color.Gray;
            }
        }
         //validation for password
        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Modified == false)
            {
                txtpassword.Clear();
                txtpassword.PasswordChar = '*';
                txtpassword.ForeColor = Color.Black;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (txtpassword.Modified == false || txtpassword.Text == "")
            {
                txtpassword.Text = "Enter Password";
                txtpassword.ForeColor = Color.Gray;
                txtpassword.PasswordChar = '\0';
            }
        }

        //validation for confirm password
        private void txtconfirmpass_Enter(object sender, EventArgs e)
        {
            if (txtconfirmpass.Modified == false)
            {
                txtconfirmpass.Text = "";
                txtconfirmpass.PasswordChar = '*';
                txtconfirmpass.ForeColor = Color.Black;
            }
        }

        private void txtconfirmpass_Leave(object sender, EventArgs e)
        {
            if (txtconfirmpass.Modified == false || txtconfirmpass.Text == "")
            {
                txtconfirmpass.Text = "Confirm Password";
                txtconfirmpass.ForeColor = Color.Gray;
                txtconfirmpass.PasswordChar = '\0';
            }
        }


        //validation for email
        private void txtemail_Enter(object sender, EventArgs e)
        {
            {
                if(txtemail.Modified==false)
                    txtemail.Text = "";
                txtemail.ForeColor = Color.Black;
            }
        }
        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Modified == false || txtemail.Text == "")
            {
                txtemail.Text = "E.g. aishjagtap450@gmail.com";
                txtemail.ForeColor = Color.Gray;
            }
        }

        private void txtmobile_Enter(object sender, EventArgs e)
        {
            if(txtmobile.Modified==false)
                txtmobile.Text = "";
            txtmobile.ForeColor = Color.Black;
        }


        private void txtmobile_Leave(object sender, EventArgs e)
        {
            if (txtmobile.Modified == false || txtmobile.Text == "")
            {
                txtmobile.Text = "Enter 10 digit no.";
                txtmobile.ForeColor = Color.Gray;
            }
        }

        //validate function
        private bool validateForm()
        {
            foreach (Control a in panel1.Controls)
            {
                //for textbox
                if (a is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)a).Text))
                    {
                        MessageBox.Show("Enter All Fields!");
                        ((TextBox)a).Focus();
                        return false;
                    }
                }
                    //for combobox
                else if(a is ComboBox)
                {
                    if(((ComboBox)a).Text=="")
                    {
                        MessageBox.Show("Enter All Fields!");
                        ((ComboBox)a).Focus();
                        return false;
                    }
                }

                //for radio button
                if (rdAdmin.Checked == false && rdStaff.Checked == false)
                {
                    MessageBox.Show("Select User Type!");
                    rdAdmin.Focus();
                    return false;
                }
            }
            return true;
        }
        
        //submit form
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                bool f= true;
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<User> put = db.GetCollection<User>("User").FindAll();
                foreach (User i in put)
                {
                    
                    if (txtusername.Text == i.username)
                    {
                        f = false;
                        MessageBox.Show("Username already exists!");
                        txtusername.Focus();
                        break;
                    }
                }
                //update
                MongoCollection<User> Users = db.GetCollection<User>("Users");
                string type = "Staff";
                if (rdAdmin.Checked == true)
                    type = "Admin";
                if (update)
                {
                    foreach (User i in Users.Find(Query.EQ("username", txtusername.Text.Trim())))
                    {
                        IMongoUpdate update1 = new UpdateDocument();
                        IMongoUpdate update2 = new UpdateDocument();
                        IMongoUpdate update3 = new UpdateDocument();
                        IMongoUpdate update4 = new UpdateDocument();
                        IMongoUpdate update5 = new UpdateDocument();
                        IMongoUpdate update6 = new UpdateDocument();
                        IMongoUpdate update7 = new UpdateDocument();

                        update1 = MongoDB.Driver.Builders.Update.Set("name", txtname.Text.Trim());
                        update2 = MongoDB.Driver.Builders.Update.Set("password", txtpassword.Text.Trim());
                        update3 = MongoDB.Driver.Builders.Update.Set("type", type);
                        update4 = MongoDB.Driver.Builders.Update.Set("security", combosecurity.Text.Trim());
                        update5 = MongoDB.Driver.Builders.Update.Set("answer", txtanswer.Text.Trim());
                        update6 = MongoDB.Driver.Builders.Update.Set("email", txtemail.Text.Trim());
                        update7 = MongoDB.Driver.Builders.Update.Set("mobileno", txtmobile.Text.Trim());

                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update1);
                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update2);
                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update3);
                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update4);
                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update5);
                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update6);
                        Users.Update(Query.EQ("username", txtusername.Text.Trim()), update7);
                        MessageBox.Show("Information Updated");
                        break;
                    }
                }
                //insert
                else if(f)
                {
                    BsonDocument user = new BsonDocument
                    {
                        {"name",txtname.Text.Trim()},
                        {"username",txtusername.Text.Trim()},
                        {"password",txtpassword.Text.Trim()},
                        {"type",type },
                        {"security",combosecurity.Text.Trim()},
                        {"answer",txtanswer.Text.Trim()},
                        {"email",txtemail.Text.Trim()},
                        {"mobileno",txtmobile.Text.Trim()}

                    };
                    Users.Insert(user);
                    MessageBox.Show("Login id created");
                }
                frmSettings obj = new frmSettings();
                obj.u_name = u_name;
                obj.username = pusername;
                obj.password = password;
                obj.type = ptype;
                obj.security = security;
                obj.answer = answer;
                obj.email = email;
                obj.mobileno = mobileno;
                obj.o = 2;
                this.Hide();
                obj.Show();
            }
        }


        private void btnreset_Click(object sender, EventArgs e)
        {
            txtname.Text = "Enter name";
            txtname.ForeColor = Color.Gray;
            txtusername.Text = "Enter username";
            txtusername.ForeColor = Color.Gray;
            txtpassword.PasswordChar = '\0';
            txtpassword.Text = "Enter password";
            txtpassword.ForeColor = Color.Gray;
            txtconfirmpass.PasswordChar = '\0';
            txtconfirmpass.Text = "Confirm password";
            txtconfirmpass.ForeColor = Color.Gray;
            rdAdmin.Checked = false;
            rdStaff.Checked = false;
            txtemail.Text = "E.g. aishjagtap450@gmail.com";
            txtemail.ForeColor = Color.Gray;
            combosecurity.Text = "Choose any security question";
            combosecurity.ForeColor = Color.Gray;
            txtmobile.Text = "Enter 10 digit no.";
            txtmobile.ForeColor = Color.Gray;
            txtanswer.Text = "";
        }

        private void txtname_Validating(object sender, CancelEventArgs e)
        {
            if (txtname.Modified == false)
            {
                MessageBox.Show("Please Enter name");
                txtname.Focus();
            }
        }

        private void txtusername_Validating(object sender, CancelEventArgs e)
        {
            if (txtusername.Modified == false)
            {
                MessageBox.Show("Please Enter username");
                txtusername.Focus();
            }
            else if (txtusername.Text.Length < 5)
            {
                MessageBox.Show("Length of username should be more than 5");
                txtusername.Focus();
            }
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();
            foreach (User i in put)
            {
                if (txtusername.Text == i.username)
                {
                    MessageBox.Show("Username already exists!");
                    txtusername.Focus();
                    break;
                }
            }
        }

        private void txtpassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtpassword.Modified == false)
            {
                MessageBox.Show("Please enter password");
            }
            if (txtpassword.Modified == true && txtpassword.Text.Length < 5)
            {
                MessageBox.Show("Length of password should be more than 5");
                txtpassword.Focus();
            }
        }

        private void txtconfirmpass_Validating(object sender, CancelEventArgs e)
        {
            if (txtconfirmpass.Modified == false)
            {
                MessageBox.Show("Please enter password");
                txtconfirmpass.Focus();
            }
            
            if (txtpassword.Text != txtconfirmpass.Text)
            {
                MessageBox.Show("Password mismatch");
            }
        }

        private void txtmobile_Validating(object sender, CancelEventArgs e)
        {
            if (txtmobile.Modified == false)
            {

                MessageBox.Show("Please enter mobile no");
                txtmobile.Focus();

            }
            else if (!txtmobile.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Enter only Digits!!!");
                txtmobile.Focus();
            }
            else if (txtmobile.Text.Length != 10  )
            {
                MessageBox.Show("Incorrect mobile no!");
                txtmobile.Focus();
            }
        }

        private void txtanswer_Validating(object sender, CancelEventArgs e)
        {
            if(txtanswer.Text=="" || txtanswer.Modified==false)
            {
                MessageBox.Show("Enter answer");
                txtanswer.Focus();

            }
        }

        private void txtemail_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void rdadmin_Validating(object sender, CancelEventArgs e)
        {
            if (rdAdmin.Checked == false && rdStaff.Checked == false)
            {
                MessageBox.Show("Select User Type!");
                rdAdmin.Focus();
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            frmSettings obj = new frmSettings();
            obj.u_name = u_name;
            obj.username = pusername;
            obj.password = password;
            obj.type = ptype;
            obj.security = security;
            obj.answer = answer;
            obj.email = email;
            obj.mobileno = mobileno;
            obj.o = 2;
            this.Hide();
            obj.Show();
        }
    }
}
