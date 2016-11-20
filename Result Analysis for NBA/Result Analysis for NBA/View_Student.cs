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
    public partial class frmView_Student : Form
    {
        public frmView_Student()
        {
            InitializeComponent();
        }
        
        private void refresh()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Students> put = db.GetCollection<Students>("Students").FindAll();
            //clear all records from display 
            dgvstudent.RowCount = 0;
            foreach (Students i in put)
            {
                dgvstudent.Rows.Add(Convert.ToString(i.prn), Convert.ToString(i.student_name), Convert.ToString(i.academicyear), Convert.ToString(i.ad_type), Convert.ToString(i.migration));
                //if required academic year is not present selections then add in selections
                if(!cmbacademicyear.Items.Contains(i.academicyear))
                    cmbacademicyear.Items.Add(i.academicyear);
                if (!cmbMigration.Items.Contains(i.migration))
                    cmbMigration.Items.Add(i.migration);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                bool f = true;
                //just for initialization
                string ad_type = "F.E.";
                if (rdfe.Checked == true)
                    ad_type = "F.E.";
                else if (rddse.Checked == true)
                    ad_type = "D.S.E.";
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<Students> put = db.GetCollection<Students>("Students").FindAll();
                foreach (Students i in put)
                {
                    //if prn no already exists give error
                    if (txtprn.Text==i.prn)
                    {
                        f = false;
                        MessageBox.Show("PRN No already exists!");
                        txtprn.Focus();
                        break;
                    }
                }
                 //if prn does not exists 
                if (f)
                {
                    MongoCollection<BsonDocument> Students = db.GetCollection<BsonDocument>("Students");
                    BsonDocument student = new BsonDocument
                    {
                        {"prn",txtprn.Text.Trim()},
                        {"student_name",txtstudent_name.Text.Trim()},
                        {"academicyear",cmbacademicyear.Text.Trim()},
                        {"ad_type",ad_type},
                        {"migration",cmbMigration.Text.Trim() }
                    };
                    Students.Insert(student);
                    MessageBox.Show("Record Added Successfully");
                    refresh();
                }
                clear();
            }
        }

        //validating  student name
        private void txtstudent_name_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtstudent_name.Text))
            {
                MessageBox.Show("Enter Valid Name!");
                txtstudent_name.Focus();
            }
        }

        public void clear()
        {
            txtprn.Text = "";
            txtstudent_name.Text = "";
            cmbacademicyear.Text = "";
            rdfe.Checked = false;
            rddse.Checked = false;
            txtprn.Focus();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
        }

        //validating (radio buttons) admission type
        private void rdfe_Validating(object sender, CancelEventArgs e)
        {
            if (rdfe.Checked == false && rddse.Checked == false)
            {
                MessageBox.Show("Select Admission Type!");
                rdfe.Focus();
            }
        }

        //validation function
        private bool validateForm()
        {
            foreach (Control a in panel1.Controls)
            {
                if (a is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)a).Text) ||((TextBox)a).Text=="")
                    {
                        MessageBox.Show("Enter All Fields!");
                        ((TextBox)a).Focus();
                        return false;
                    }
                }
                else if (a is ComboBox)
                {
                    if (((ComboBox)a).Text == "")
                    {
                        MessageBox.Show("Enter All Fields!");
                        ((ComboBox)a).Focus();
                        return false;
                    }
                }
            }
            if(rdfe.Checked==false&&rddse.Checked==false)
            {
                MessageBox.Show("Select Admission Type!");
                rdfe.Focus();
                return false;
            }
            return true;
        }

        private void frmView_Student_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                bool f = false;
                string ad_type = "F.E.";
                if (rdfe.Checked == true)
                    ad_type = "F.E.";
                else
                    ad_type = "D.S.E.";
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");

                MongoCursor<Students> put = db.GetCollection<Students>("Students").FindAll();
                foreach (Students i in put)
                {
                    //wrong prn no
                    if (txtprn.Text == i.prn)
                    {
                        f = true;
                        break;
                    }
                }
                //prn no exists then update
                if (f)
                {
                    MongoCollection<Students> stud = db.GetCollection<Students>("Students");
                    foreach (Students i in stud.Find(Query.EQ("prn", txtprn.Text.Trim())))
                    {
                        IMongoUpdate update1 = new UpdateDocument();
                        IMongoUpdate update2 = new UpdateDocument();
                        IMongoUpdate update3 = new UpdateDocument();
                        IMongoUpdate update4 = new UpdateDocument();
                        if (txtprn.Text != "")
                        {
                            update1 = MongoDB.Driver.Builders.Update.Set("student_name", txtstudent_name.Text.Trim());
                            update2 = MongoDB.Driver.Builders.Update.Set("academicyear", cmbacademicyear.Text.Trim());
                            update3 = MongoDB.Driver.Builders.Update.Set("ad_type", ad_type);
                            update4 = MongoDB.Driver.Builders.Update.Set("migration", cmbMigration.Text.Trim());

                        }
                        stud.Update(Query.EQ("prn", txtprn.Text.Trim()), update1);
                        stud.Update(Query.EQ("prn", txtprn.Text.Trim()), update2);
                        stud.Update(Query.EQ("prn", txtprn.Text.Trim()), update3);
                        stud.Update(Query.EQ("prn", txtprn.Text.Trim()), update4);
                        MessageBox.Show("Record Updated!");
                        refresh();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("PRN No does not exists!");
                    txtprn.Focus();
                }
            }
        }

        //delete record
        private void btnDelete_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCollection<Students> student = db.GetCollection<Students>("Students");
            foreach (Students stud in student.Find(Query.EQ("prn", txtprn.Text.Trim())))
            {
                //gives message before deleting record
                if (DialogResult.Yes == MessageBox.Show("Do u want to delete this record ?", "", MessageBoxButtons.YesNo))
                {
                    student.Remove(Query.EQ("prn", txtprn.Text.Trim()));
                    MessageBox.Show("Record successfully deleted!");
                    clear();
                    refresh();
                }
                break;
            }
        }

        //search record
        private void btnSearch_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Students> put = db.GetCollection<Students>("Students").FindAll();
            bool f = false;
            foreach (Students i in put)
            {
                if (txtprn.Text.Trim() == i.prn)
                {
                    txtstudent_name.Text = i.student_name;
                    cmbacademicyear.Text = i.academicyear;
                    if (i.ad_type == "F.E.")
                        rdfe.Checked = true;
                    else
                        rddse.Checked = true;
                    cmbMigration.Text = i.migration;
                    f = true;
                    break;
                }
            }
            if (!f)
                MessageBox.Show("Record not found!");
        }

        private void dgvstudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //when click on record fronm datagrid view then all fields  get filled in textbox
            txtprn.Text= dgvstudent.SelectedCells[0].Value.ToString();
            txtstudent_name.Text= dgvstudent.SelectedCells[1].Value.ToString();
            cmbacademicyear.Text= dgvstudent.SelectedCells[2].Value.ToString();
            cmbMigration.Text = dgvstudent.SelectedCells[3].Value.ToString();
                
                //if value of admission type in datagrid is f.e. then get select f.e. radio button else d.s.e
            if (dgvstudent.SelectedCells[3].Value.ToString() == "F.E.")
                rdfe.Checked = true;
            else
                rddse.Checked = true;

        }

        
        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
    }
}
