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

namespace Result_Analysis_for_NBA
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //validdation for username
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Modified == false)
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Modified == false || txtUsername.Text == "")
            {
                txtUsername.Text = "Enter Username here";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        //validation for password
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Modified == false)
            {
                txtPassword.Clear();
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Modified == false || txtPassword.Text == "")
            {
                txtPassword.Text = "Enter Password here";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();
            bool f = false;
            foreach (User i in put)
            {
                //if username and paswword matches then login
                if (txtUsername.Text.Trim()==i.username && txtPassword.Text.Trim()==i.password)
                {
                    f = true;
                    frmHome_Page obj = new frmHome_Page();
                    obj.u_name = i.name;
                    obj.username = i.username;
                    obj.password = i.password;
                    obj.type = i.type;
                    obj.security = i.security;
                    obj.answer = i.answer;
                    obj.email = i.email;
                    obj.mobileno = i.mobileno;
                    obj.Show();
                    this.Hide();
                    break;
                }
            }
            if (!f)
            {
                MessageBox.Show("Invalid username or password");
                txtUsername.Focus();
            }
        }

        //reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0';
            txtPassword.Text = "Enter Password here";
            txtUsername.Text = "Enter Username here";
            txtUsername.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;
        }

        //forget password
        private void lblforgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgot_Pass obj = new frmForgot_Pass();
            this.Hide();
            obj.Show();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            txtUsername.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Text = "Enter Password here";
            txtUsername.Text = "Enter Username here";
        }
    }
}
