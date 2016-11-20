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

namespace Result_Analysis_for_NBA.Marks_Entry
{
    public partial class frmMarks_Entry : Form
    {
        public frmMarks_Entry()
        {
            InitializeComponent();
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            // validation for semester if not selected;
            if (cmbsem.Text == "Select")   
            {
                MessageBox.Show("Select Semester");
                cmbsem.Focus();
            }
            else
            {
                //to take info from 1 form to 2nd create obj of 2nd form
                Marks_Entry.frmMarks_Entry2 obj = new Marks_Entry.frmMarks_Entry2();
                if (rdfe.Checked == true)
                    obj.clas = "F.E.";      // take class=F.E. on 2nd form
                else if (rdse.Checked == true)
                    obj.clas = "S.E.";
                else if (rdte.Checked == true)
                    obj.clas = "T.E.";
                else if (rdbe.Checked == true)
                    obj.clas = "B.E.";
                obj.sem = cmbsem.Text;  // take sem on 2nd form
                obj.academic_year = cmbacademicyear.Text;
                obj.Show();
            }
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide(); // back to home
        }

        private void frmMarks_Entry_Load(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Subjects> put = db.GetCollection<Subjects>("Subjects").FindAll();
            foreach (Subjects i in put)
            {
                // if your expected academic year is not in selections then type and it will get added in selection
                if (!cmbacademicyear.Items.Contains(i.academic_year))                    
                    cmbacademicyear.Items.Add(i.academic_year);
            }
        }
    }
}
