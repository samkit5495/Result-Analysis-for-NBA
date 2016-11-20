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
    public partial class frmHome_Page : Form
    {
        public frmHome_Page()
        {
            InitializeComponent();
        }

        public string u_name,username, password, type, security, answer, email, mobileno;

        private void btnView_Analysis_Click(object sender, EventArgs e)
        {
            frmReport obj = new frmReport();
            obj.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to logout ?", "Logout", MessageBoxButtons.YesNo))
            {
                
                Server server = new Server();
                server.stop();
                Application.Exit();
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            frmView_Student obj = new frmView_Student();
            obj.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            frmView_Staff obj = new frmView_Staff();
            obj.Show();
        }

        private void btnMarks_Entry_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Marks_Entry.frmMarks_Entry obj = new Result_Analysis_for_NBA.Marks_Entry.frmMarks_Entry();
            obj.Show();
        }

        private void btnView_Marks_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Marks_Entry.frmView_Marks obj = new Result_Analysis_for_NBA.Marks_Entry.frmView_Marks();
            obj.Show();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Settings.frmSettings obj = new Result_Analysis_for_NBA.Settings.frmSettings();
            obj.u_name = u_name;
            obj.username = username;
            obj.password = password;
            obj.type = type;
            obj.security = security;
            obj.answer = answer;
            obj.email = email;
            obj.mobileno = mobileno;
            this.Hide();
            obj.Show();
        }

        private void frmHome_Page_Load(object sender, EventArgs e)
        {
            lbluser.Text = username+",";
        }
    }
}
