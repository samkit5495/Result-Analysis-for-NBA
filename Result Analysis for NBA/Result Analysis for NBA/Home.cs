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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void btnstudentnew_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Student.frmNew_Student obj = new Result_Analysis_for_NBA.Student.frmNew_Student();
            obj.Show();
        }

        private void btnstudentedit_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Student.frmEdit_Student obj = new Result_Analysis_for_NBA.Student.frmEdit_Student();
            obj.Show();
        }

        private void btnstaffnew_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Staff.frmNew_Staff obj = new Result_Analysis_for_NBA.Staff.frmNew_Staff();
            obj.Show();
        }

        private void btnstaffedit_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Staff.frmEdit_Staff obj = new Result_Analysis_for_NBA.Staff.frmEdit_Staff();
            obj.Show();
        }

        private void btnmarksnew_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Marks_Entry.frmMarks_Entry obj = new Result_Analysis_for_NBA.Marks_Entry.frmMarks_Entry();
            obj.Show();
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Result_Analysis_for_NBA.Settings.frmSettings obj = new Result_Analysis_for_NBA.Settings.frmSettings();
        }
    }
}
