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

namespace Result_Analysis_for_NBA.Marks_Entry
{
    public partial class frmMarks_Entry2 : Form
    {
        public frmMarks_Entry2()
        {
            InitializeComponent();
        }
        public string clas, sem,academic_year;
        int stud_marks = 0, stud_tot_marks = 0;
        string[] sub = new string[24];
        int backlog=0;

        public void cal_marks()
        {
            backlog = 0;
            stud_marks = 0;
            stud_tot_marks = 0;
            foreach (Control a in groupBox1.Controls.OfType<Control>().OrderBy(c => c.TabIndex))
            {
                if (a is Label && a.Visible == true && a.Name.Contains("lblsubm"))
                {
                    // (whatever will be in label) as we add subject, total marks will get updated 
                    stud_tot_marks += Convert.ToInt32(((Label)a).Text.Trim());
                }
                else if(a is TextBox &&a.Visible==true)
                {
                    if(Convert.ToInt32(((TextBox)a).Text.Trim())<40)
                    {
                        // if marks are less than 40 then it is backlog
                        backlog++;// backlogs get incremented
                    }
                    // calculate student marks
                    stud_marks += Convert.ToInt32(((TextBox)a).Text.Trim()); 
                }
            }
        }

        public string grade()
        {
            string stud_grade;
            // calcultion of percentage
            float per = ((float)stud_marks / stud_tot_marks) * 100; 
            
            // decide grades
            if(backlog > 0&&backlog<=3)
                stud_grade = "A.T.K.T.";
            else if (per >= 0 && per < 40||backlog>3)
                stud_grade = "Fail";
            else if (per >= 40 && per < 50)
                stud_grade = "Pass Class";
            else if (per >= 50 && per < 55)
                stud_grade = "Second Class";
            else if (per >= 55 && per < 60)
                stud_grade = "Higher Secondary Class";
            else if (per >= 60 && per < 66)
                stud_grade = "First Class";
            else 
                stud_grade = "First Class with Distinction";
                return stud_grade; 
        }
        
        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtFind_Click(object sender, EventArgs e)
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
                    //show student name on form
                    lblname.Text = i.student_name;  
                    if (i.ad_type == "D.S.E." && clas == "F.E.")
                    {
                        MessageBox.Show("Can't Enter F.E. marks of D.S.E. student!");
                        this.Hide();
                    }
                    f = true;
                    break;
                }
            }
            if (!f)
                MessageBox.Show("Record not found!");
        }

        // validation function
        private bool validateForm() 
        {
            foreach (Control a in this.Controls) 
            {
                if (a is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)a).Text) || ((TextBox)a).Text == "")
                    {
                        MessageBox.Show("Enter All Fields!");
                        ((TextBox)a).Focus();
                        return false;
                    }
                }
            }
            foreach(Control a in groupBox1.Controls)
            { 
                if (a is TextBox && a.Visible == true)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)a).Text) || ((TextBox)a).Text == "")
                    {
                        MessageBox.Show("Enter All Fields!");
                        ((TextBox)a).Focus();
                        return false;
                    }
                }
            }
            return true;
        }

        private void show_sub(int count)
        {
            int x =0;

            foreach (Control a in groupBox1.Controls.OfType<Control>().OrderBy(c => c.TabIndex))
            {

                if (x != 2*count)
                {
                    //At first postion label is stored and after that textbox for marks. 
                    //so if a is label then from subject array it will get displayed and x++
                    if (a is Label)
                    {
                        ((Label)a).Text = sub[x++];
                    }
                    a.Show();
                }
                if (a is TextBox)
                {
                    //intialise each (textbox) marks with 0
                    ((TextBox)a).Text = "0";
                }
            }
        }
        private void load_subject()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            //in this subjects are orderd in ascending order as they are added in subject add form
            MongoCursor<Subjects> put = db.GetCollection<Subjects>("Subjects").Find(Query.And(Query.EQ("academic_year",academic_year),Query.EQ("clas",clas),Query.EQ("semester",sem))).SetSortOrder(SortBy.Ascending("srno"));
            //it will count how many subjects are added
            long count = put.Count();
            if (count == 0)
            {
                this.Hide();
                MessageBox.Show("No Subjects Added!");
                return;
            }
            int x = 0;
            foreach(Subjects i in put)
            {
                //subject name and their corresponding marks will be searched in collection
                sub[x++] = i.Subject_Name;
                sub[x++] = i.marks;
            }
            show_sub(Convert.ToInt32(count));
        }

        private void frmMarks_Entry2_Load(object sender, EventArgs e)
        {
            load_subject();
        }

        public bool isdigit(String x)
        {
            foreach(char a in x)
            {
                if (a >= 'a' && a <= 'z' || a >= 'A' && a <= 'Z')
                    return false;              
            }
            return true;

        }

        private void sub_validate(TextBox t,Label x)
        {
            t.ForeColor = Color.Black;
            // check marks entertd are less then toal marks of each sub; 
            if (!t.Text.Trim().All(char.IsDigit)||Convert.ToInt32(t.Text) > Convert.ToInt32(x.Text) ||Convert.ToInt32(t.Text)<0)
            {
                MessageBox.Show("Enter Valid Marks!");
                t.Focus();
            }
                //if marks enterd are less than 40 then give in color red
            else if(Convert.ToInt32(t.Text)<40)
            {
                t.ForeColor = Color.Red;
            }
        }

        // validation for each subject

        private void txtsub1_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub1,lblsubm1);
        }

        private void txtsub2_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub2, lblsubm2);
        }

        private void txtsub3_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub3, lblsubm3);
        }

        private void txtsub4_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub4, lblsubm4);
        }

        private void txtsub5_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub5, lblsubm5);
        }

        private void txtsub6_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub6, lblsubm6);
        }

        private void txtsub7_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub7, lblsubm7);
        }

        private void txtsub8_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub8, lblsubm8);
        }

        private void txtsub9_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub9, lblsubm9);
        }

        private void txtsub10_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub10, lblsubm10);
        }

        private void txtsub11_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub11, lblsubm11);
        }

        private void txtsub12_Validating(object sender, CancelEventArgs e)
        {
            sub_validate(txtsub12, lblsubm12);
        }

        // validation for seat no
        private void txtseatno_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtseatno.Text) || txtseatno.Text.Length != 10)
            {
                MessageBox.Show("Enter Valid Seat No!");
                txtseatno.Focus();
            }
        }


        private void clear()
        {
            foreach(Control a in this.Controls)
            {
                if (a is TextBox)
                    ((TextBox)a).Clear();
            }
            foreach (Control a in groupBox1.Controls)
            {
                if (a is TextBox)
                    //initialise each textbox with 0
                    ((TextBox)a).Text="0";  
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                cal_marks(); // calculate marks
                string stud_grade = grade(); // decide grade
                if (DialogResult.Cancel == MessageBox.Show(stud_marks + "/" + stud_tot_marks + "\n Grade : " + stud_grade, "Confirm Grade", MessageBoxButtons.OKCancel))
                    return;
                bool f = true;
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<Marks> put;
                if (clas == "F.E.")
                    put = db.GetCollection<Marks>("fe_marks").FindAll();
                else if (clas == "S.E.")
                    put = db.GetCollection<Marks>("se_marks").FindAll();
                else if (clas == "T.E.")
                    put = db.GetCollection<Marks>("te_marks").FindAll();
                else
                    put = db.GetCollection<Marks>("be_marks").FindAll();
                foreach (Marks i in put)
                {
                    if (txtprn.Text == i.prn)
                    {
                        f = false;
                        txtprn.Focus();
                        break;
                    }
                }

                MongoCollection<Marks> marks;
                if (clas == "F.E.")
                    marks = db.GetCollection<Marks>("fe_marks");
                else if (clas == "S.E.")
                    marks = db.GetCollection<Marks>("se_marks");
                else if (clas == "T.E.")
                    marks = db.GetCollection<Marks>("te_marks");
                else
                    marks = db.GetCollection<Marks>("be_marks");

                //if prn is not present and sem is sem I
                if (f && sem == "Sem I")
                {
                    Marks mark = new Marks();
                    mark.prn = txtprn.Text.Trim();
                    mark.seat_no = txtseatno.Text.Trim();
                    mark.sub1 = Convert.ToInt32(txtsub1.Text.Trim());
                    mark.sub2 = Convert.ToInt32(txtsub2.Text.Trim());
                    mark.sub3 = Convert.ToInt32(txtsub3.Text.Trim());
                    mark.sub4 = Convert.ToInt32(txtsub4.Text.Trim());
                    mark.sub5 = Convert.ToInt32(txtsub5.Text.Trim());
                    mark.sub6 = Convert.ToInt32(txtsub6.Text.Trim());
                    mark.sub7 = Convert.ToInt32(txtsub7.Text.Trim());
                    mark.sub8 = Convert.ToInt32(txtsub8.Text.Trim());
                    mark.sub9 = Convert.ToInt32(txtsub9.Text.Trim());
                    mark.sub10 = Convert.ToInt32(txtsub10.Text.Trim());
                    mark.sub11 = Convert.ToInt32(txtsub11.Text.Trim());
                    mark.sub12 = Convert.ToInt32(txtsub12.Text.Trim());
                    mark.sem1_total = stud_tot_marks;
                    mark.sem1_grade = stud_grade;
                    marks.Insert(mark);
                    MessageBox.Show("Record Added Successfully");
                    clear();
                }
                    //if prn is present and sem II
                else if(!f&&sem=="Sem II")
                {
                    foreach (Marks i in marks.Find(Query.EQ("prn", txtprn.Text.Trim())))
                    {
                        IMongoUpdate update1 = new UpdateDocument();
                        IMongoUpdate update2 = new UpdateDocument();
                        IMongoUpdate update3 = new UpdateDocument();
                        IMongoUpdate update4 = new UpdateDocument();
                        IMongoUpdate update5 = new UpdateDocument();
                        IMongoUpdate update6 = new UpdateDocument();
                        IMongoUpdate update7 = new UpdateDocument();
                        IMongoUpdate update8 = new UpdateDocument();
                        IMongoUpdate update9 = new UpdateDocument();
                        IMongoUpdate update10 = new UpdateDocument();
                        IMongoUpdate update11 = new UpdateDocument();
                        IMongoUpdate update12 = new UpdateDocument();
                        IMongoUpdate update13 = new UpdateDocument();
                        IMongoUpdate update14 = new UpdateDocument();

                        if (txtprn.Text != "")
                        {
                            update1 = MongoDB.Driver.Builders.Update.Set("sub13", Convert.ToInt32(txtsub1.Text.Trim()));
                            update2 = MongoDB.Driver.Builders.Update.Set("sub14", Convert.ToInt32(txtsub2.Text.Trim()));
                            update3 = MongoDB.Driver.Builders.Update.Set("sub15", Convert.ToInt32(txtsub3.Text.Trim()));
                            update4 = MongoDB.Driver.Builders.Update.Set("sub16", Convert.ToInt32(txtsub4.Text.Trim()));
                            update5 = MongoDB.Driver.Builders.Update.Set("sub17", Convert.ToInt32(txtsub5.Text.Trim()));
                            update6 = MongoDB.Driver.Builders.Update.Set("sub18", Convert.ToInt32(txtsub6.Text.Trim()));
                            update7 = MongoDB.Driver.Builders.Update.Set("sub19", Convert.ToInt32(txtsub7.Text.Trim()));
                            update8 = MongoDB.Driver.Builders.Update.Set("sub20", Convert.ToInt32(txtsub8.Text.Trim()));
                            update9 = MongoDB.Driver.Builders.Update.Set("sub21", Convert.ToInt32(txtsub9.Text.Trim()));
                            update10 = MongoDB.Driver.Builders.Update.Set("sub22", Convert.ToInt32(txtsub10.Text.Trim()));
                            update11 = MongoDB.Driver.Builders.Update.Set("sub23", Convert.ToInt32(txtsub11.Text.Trim()));
                            update12 = MongoDB.Driver.Builders.Update.Set("sub24", Convert.ToInt32(txtsub11.Text.Trim()));
                            update13 = MongoDB.Driver.Builders.Update.Set("sem2_total", stud_marks);
                            update14 = MongoDB.Driver.Builders.Update.Set("sem2_grade", stud_grade);

                        }
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update1);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update2);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update3);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update4);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update5);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update6);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update7);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update8);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update9);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update10);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update11);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update12);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update13);
                        marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update14);

                        MessageBox.Show("Record Added Successfully");
                        clear();
                        break;
                    }
                }
                    // prn is already present and sem I
                else if(sem=="Sem I")
                    MessageBox.Show("PRN No already exists!");
                    //prn is not present and sem II
                else
                    MessageBox.Show("Please enter Sem I Marks!");
                
            }
        }
    }
}
