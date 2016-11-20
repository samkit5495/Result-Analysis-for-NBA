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

namespace Result_Analysis_for_NBA
{
    public partial class frmForgot_Pass : Form
    {
        public frmForgot_Pass()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();
            bool f = false;
            foreach (User i in put)
            {
                //checks entered username with username in database 
                if (txtusername.Text.Trim() == i.username)
                {
                    f = true;
                    //take all this following values on 2nd form of forgot password
                    frmForgot_Pass2 obj = new frmForgot_Pass2();
                    obj.username = i.username;
                    obj.security = i.security;
                    obj.answer = i.answer;
                    this.Hide();
                    obj.Show();
                    break;
                }
            }
            //if username not matches with username in database then gives error
            if(!f)
                MessageBox.Show("Invalid Username!");
            txtusername.Focus();
        }

        //validation for username
        private void txtusername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text))
            {
                MessageBox.Show("Enter Username!");
                txtusername.Focus();
            }
        }

        //takes back to home page
        private void picBack_Click(object sender, EventArgs e)
        {
            frmLogin obj = new frmLogin();
            this.Hide();
            obj.Show();
        }
    }
}
