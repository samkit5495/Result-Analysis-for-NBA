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
    public partial class frmView_Subject : Form
    {
        public frmView_Subject()
        {
            InitializeComponent();
        }
        public string Subject_Name,academicyear;
        public bool update;
        public string u_name, pusername, password, ptype, security, answer, email, mobileno;

        private void txtMarks_Validating(object sender, CancelEventArgs e)
        {
            if (txtMarks.Modified == false)
            {

                MessageBox.Show("Please enter mobile no");
                txtMarks.Focus();

            }
            else if (!txtMarks.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Enter only Digits!!!");
                txtMarks.Focus();
            }
        }

        // back to home
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
            obj.o = 1;
            this.Hide();
            obj.Show();
        }

        private void frmView_Subject_Load(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Staffs> staff = db.GetCollection<Staffs>("Staffs").FindAll();

            foreach (Staffs i in staff)
            {
                
                if (!cmbStaff_Name.Items.Contains(i.staff_name))
                    cmbStaff_Name.Items.Add(i.staff_name);
            }

            MongoCursor<Subjects> sub = db.GetCollection<Subjects>("Subjects").FindAll();
            foreach (Subjects i in sub)
            {
                if (!cmbacademicyear.Items.Contains(i.academic_year))
                    cmbacademicyear.Items.Add(i.academic_year);
            }
            cmbacademicyear.Text = academicyear;
            if (update)
            {
                MongoCursor<Subjects> put = db.GetCollection<Subjects>("Subjects").FindAll();
                foreach (Subjects i in put)
                {
                    if (Subject_Name == i.Subject_Name)
                    {
                        cmbacademicyear.Text = i.academic_year;
                        if (i.clas == "F.E.")
                            rdfe.Checked = true;
                        else if (i.clas == "S.E.")
                            rdse.Checked = true;
                        else if (i.clas == "T.E.")
                            rdte.Checked = true;
                        else
                            rdbe.Checked = true;
                        cmbsem.Text = i.semester;
                        cmbsrno.Text = i.srno.ToString();
                        txtSubject_Name.Text = i.Subject_Name;
                        txtMarks.Text = i.marks;
                        cmbStaff_Name.Text = i.Staff_Name;
                        break;
                    }
                }
                btnAdd.Text = "Update";
                txtSubject_Name.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                bool f = true;
                string clas;
                if (rdfe.Checked)
                    clas = "F.E.";
                else if (rdse.Checked)
                    clas = "S.E.";
                else if (rdte.Checked)
                    clas = "T.E.";
                else if (rdbe.Checked)
                    clas = "B.E.";
                else
                {
                    MessageBox.Show("Please select the class");
                    return;
                }
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<Subjects> put = db.GetCollection<Subjects>("Subjects").Find(Query.EQ("academic_year", cmbacademicyear.Text.Trim()));
                foreach (Subjects i in put)
                {
                    if (clas == i.clas && cmbsem.Text.Trim() == i.semester && Convert.ToInt32(cmbsrno.Text) == i.srno)
                    {
                        f = false;
                        if (!update)
                        {
                            MessageBox.Show("Subject Sr. No. already exists in this Academic Year!");
                            txtSubject_Name.Focus();
                        }
                        break;
                    }
                }
                //update
                MongoCollection<Subjects> subjects = db.GetCollection<Subjects>("Subjects");
                if (update)
                {
                    foreach (Subjects i in subjects.Find(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim())))
                    {
                        IMongoUpdate update1 = new UpdateDocument();
                        IMongoUpdate update2 = new UpdateDocument();
                        IMongoUpdate update3 = new UpdateDocument();
                        IMongoUpdate update4 = new UpdateDocument();
                        IMongoUpdate update5 = new UpdateDocument();
                        IMongoUpdate update6 = new UpdateDocument();
                        IMongoUpdate update7 = new UpdateDocument();
        
                        update1 = MongoDB.Driver.Builders.Update.Set("academic_year", cmbacademicyear.Text.Trim());
                        update2 = MongoDB.Driver.Builders.Update.Set("clas", clas);
                        update3 = MongoDB.Driver.Builders.Update.Set("semester",cmbsem.Text.Trim());
                        update4 = MongoDB.Driver.Builders.Update.Set("srno", Convert.ToInt32(cmbsrno.Text.Trim()));
                        update5 = MongoDB.Driver.Builders.Update.Set("Subject_Name", txtSubject_Name.Text.Trim());
                        update6 = MongoDB.Driver.Builders.Update.Set("marks", txtMarks.Text.Trim());
                        update7 = MongoDB.Driver.Builders.Update.Set("Staff_Name", cmbStaff_Name.Text.Trim());

                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update1);
                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update2);
                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update3);
                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update4);
                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update5);
                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update6);
                        subjects.Update(Query.EQ("Subject_Name", txtSubject_Name.Text.Trim()), update7);
                        MessageBox.Show("Information Updated");
                        break;
                    }
                }
                //insert
                else if (f)
                {
                    Subjects subject = new Subjects();
                    subject.academic_year = cmbacademicyear.Text.Trim();
                    subject.clas = clas;
                    subject.semester = cmbsem.Text.Trim();
                    subject.srno = Convert.ToInt32(cmbsrno.Text.Trim());
                    subject.Subject_Name = txtSubject_Name.Text.Trim();
                    subject.marks = txtMarks.Text.Trim();
                    subject.Staff_Name = cmbStaff_Name.Text.Trim();
                    subjects.Insert(subject);
                    MessageBox.Show("Subject Added!");
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
                obj.o = 1;
                this.Hide();
                obj.Show();
            }   
        }

        private void clear()
        {
            foreach (Control a in panel1.Controls)
            {
                if (a is TextBox)
                    ((TextBox)a).Clear();
                else if(a is ComboBox)
                    ((ComboBox)a).Text="Select";
                else if(a is RadioButton)
                    ((RadioButton)a).Checked=false;
            }
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
        }
        private bool validateForm()
        {
            foreach (Control a in panel1.Controls)
            {
                if (a is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)a).Text))
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
            return true;
        }
    }
}
