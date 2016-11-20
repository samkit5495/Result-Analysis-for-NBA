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
    public partial class frmForgot_Pass3 : Form
    {
        public frmForgot_Pass3()
        {
            InitializeComponent();
        }
        public string username, security, answer;

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //password validation
            if (txtnewpassword.Text != txtconfirmpassword.Text)
            {
                MessageBox.Show("Password Mismatch!");
                txtnewpassword.Focus();
            }
            else
            {
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCollection<User> user = db.GetCollection<User>("Users");
                MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();
                //find username in database
                foreach (User i in user.Find(Query.EQ("username", username)))
                {
                    IMongoUpdate update = new UpdateDocument();
                    update = MongoDB.Driver.Builders.Update.Set("password", txtnewpassword.Text);
                    user.Update(Query.EQ("username", username), update);
                    MessageBox.Show("Password Changed Successfully!");
                    break;
                }
                frmLogin obj = new frmLogin();
                this.Hide();
                obj.Show();
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {

            frmForgot_Pass2 obj = new frmForgot_Pass2();
            obj.username = username;
            obj.security = security;
            obj.answer = answer;
            this.Hide();
            obj.Show();
        }
    }
}
