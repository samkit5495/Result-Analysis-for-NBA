using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Result_Analysis_for_NBA
{
    public partial class frmForgot_Pass2 : Form
    {
        public frmForgot_Pass2()
        {
            InitializeComponent();
        }
        public string username, security, answer;

        //take back to home page
        private void picBack_Click(object sender, EventArgs e)
        {
            frmForgot_Pass obj = new frmForgot_Pass();
            this.Hide();
            obj.Show();
        }

        private void frmForgot_Pass2_Load(object sender, EventArgs e)
        {
            //takes value of security from first page of forgot password
            lblquestion.Text = security;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //check if given security ans is matched with ans in database
            if (txtanswer.Text.Trim() == answer)
            {
                //take all this following value on form 3 of forgot pssword
                frmForgot_Pass3 obj = new frmForgot_Pass3();
                obj.username = username;
                obj.security = security;
                obj.answer = answer;
                this.Hide();
                obj.Show();
            }
            else//if ans mismatched
            {
                MessageBox.Show("Wrong Answer!");
                txtanswer.Focus();
            }
        }
    }
}
