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
    public partial class frmView_Marks : Form
    {
        public frmView_Marks()
        {
            InitializeComponent();
        }
        string academic_year;
        int stud_marks = 0, stud_tot_marks = 0;
        int backlog = 0;
        private void refresh(bool f,string academic_year)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Students> put;
            if (academic_year == "0")
                put = db.GetCollection<Students>("Students").FindAll();
            else
                put = db.GetCollection<Students>("Students").Find(Query.EQ("academicyear",academic_year));
            if(f)
                dgvStudent.RowCount = 0;
            foreach (Students i in put)
            {

                if(f)
                    dgvStudent.Rows.Add(Convert.ToString(i.prn), Convert.ToString(i.student_name), Convert.ToString(i.ad_type));
                else if (!cmbacademicyear.Items.Contains(i.academicyear))
                    cmbacademicyear.Items.Add(i.academicyear);
            }
        }

        private void frmView_Marks_Load(object sender, EventArgs e)
        {
            refresh(false,"0");
            tabControlMarks.TabPages.Remove(tabPage1);
            tabControlMarks.TabPages.Remove(tabPage2);
            tabControlMarks.TabPages.Remove(tabPage3);
            tabControlMarks.TabPages.Remove(tabPage4);
            tabControlMarks.Hide();
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbacademicyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh(true,cmbacademicyear.Text.Trim());
        }

        private void load_marks(string prn)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Students> put = db.GetCollection<Students>("Students").Find(Query.EQ("prn", prn));
            bool f = false;
            txtprn.Text = prn;
            foreach (Students i in put)
            {
                lblStudentName.Text = i.student_name;
                academic_year = i.academicyear;
                f = true;
                break;
            }
            if (!f)
            {
                MessageBox.Show("Record not found!");
                return;
            }
            MongoCursor<Marks> marks;
            f = false;
            marks = db.GetCollection<Marks>("fe_marks").Find(Query.EQ("prn",prn));
            if (marks.Count() > 0)
            {
                f = true;
                tabControlMarks.Show();
                tabControlMarks.TabPages.Add(tabPage1);
                foreach (Marks i in marks)
                {
                    txt1seatno.Text = i.seat_no;
                    txt1sub1.Text = i.sub1.ToString();
                    txt1sub2.Text = i.sub2.ToString();
                    txt1sub3.Text = i.sub3.ToString();
                    txt1sub4.Text = i.sub4.ToString();
                    txt1sub5.Text = i.sub5.ToString();
                    txt1sub6.Text = i.sub6.ToString();
                    txt1sub7.Text = i.sub7.ToString();
                    txt1sub8.Text = i.sub8.ToString();
                    txt1sub9.Text = i.sub9.ToString();
                    txt1sub10.Text = i.sub10.ToString();
                    txt1sub11.Text = i.sub11.ToString();
                    txt1sub12.Text = i.sub12.ToString();
                    txt1sub13.Text = i.sub13.ToString();
                    txt1sub14.Text = i.sub14.ToString();
                    txt1sub15.Text = i.sub15.ToString();
                    txt1sub16.Text = i.sub16.ToString();
                    txt1sub17.Text = i.sub17.ToString();
                    txt1sub18.Text = i.sub18.ToString();
                    txt1sub19.Text = i.sub19.ToString();
                    txt1sub20.Text = i.sub20.ToString();
                    txt1sub21.Text = i.sub21.ToString();
                    txt1sub22.Text = i.sub22.ToString();
                    txt1sub23.Text = i.sub23.ToString();
                    txt1sub24.Text = i.sub24.ToString();
                }
            }
            marks = db.GetCollection<Marks>("se_marks").Find(Query.EQ("prn", prn));
            if (marks.Count() > 0)
            {
                f = true;
                tabControlMarks.Show();
                tabControlMarks.TabPages.Add(tabPage2);

                foreach (Marks i in marks)
                {
                    txt2seatno.Text = i.seat_no;
                    txt2sub1.Text = i.sub1.ToString();
                    txt2sub2.Text = i.sub2.ToString();
                    txt2sub3.Text = i.sub3.ToString();
                    txt2sub4.Text = i.sub4.ToString();
                    txt2sub5.Text = i.sub5.ToString();
                    txt2sub6.Text = i.sub6.ToString();
                    txt2sub7.Text = i.sub7.ToString();
                    txt2sub8.Text = i.sub8.ToString();
                    txt2sub9.Text = i.sub9.ToString();
                    txt2sub10.Text = i.sub10.ToString();
                    txt2sub11.Text = i.sub11.ToString();
                    txt2sub12.Text = i.sub12.ToString();
                    txt2sub13.Text = i.sub13.ToString();
                    txt2sub14.Text = i.sub14.ToString();
                    txt2sub15.Text = i.sub15.ToString();
                    txt2sub16.Text = i.sub16.ToString();
                    txt2sub17.Text = i.sub17.ToString();
                    txt2sub18.Text = i.sub18.ToString();
                    txt2sub19.Text = i.sub19.ToString();
                    txt2sub20.Text = i.sub20.ToString();
                    txt2sub21.Text = i.sub21.ToString();
                    txt2sub22.Text = i.sub22.ToString();
                    txt2sub23.Text = i.sub23.ToString();
                    txt2sub24.Text = i.sub24.ToString();
                }
            }

            marks = db.GetCollection<Marks>("te_marks").Find(Query.EQ("prn", prn));
            if (marks.Count() > 0)
            {
                f = true;
                tabControlMarks.Show();
                tabControlMarks.TabPages.Add(tabPage3);

                foreach (Marks i in marks)
                {
                    txt3seatno.Text = i.seat_no;
                    txt3sub1.Text = i.sub1.ToString();
                    txt3sub2.Text = i.sub2.ToString();
                    txt3sub3.Text = i.sub3.ToString();
                    txt3sub4.Text = i.sub4.ToString();
                    txt3sub5.Text = i.sub5.ToString();
                    txt3sub6.Text = i.sub6.ToString();
                    txt3sub7.Text = i.sub7.ToString();
                    txt3sub8.Text = i.sub8.ToString();
                    txt3sub9.Text = i.sub9.ToString();
                    txt3sub10.Text = i.sub10.ToString();
                    txt3sub11.Text = i.sub11.ToString();
                    txt3sub12.Text = i.sub12.ToString();
                    txt3sub13.Text = i.sub13.ToString();
                    txt3sub14.Text = i.sub14.ToString();
                    txt3sub15.Text = i.sub15.ToString();
                    txt3sub16.Text = i.sub16.ToString();
                    txt3sub17.Text = i.sub17.ToString();
                    txt3sub18.Text = i.sub18.ToString();
                    txt3sub19.Text = i.sub19.ToString();
                    txt3sub20.Text = i.sub20.ToString();
                    txt3sub21.Text = i.sub21.ToString();
                    txt3sub22.Text = i.sub22.ToString();
                    txt3sub23.Text = i.sub23.ToString();
                    txt3sub24.Text = i.sub24.ToString();
                }
            }

            marks = db.GetCollection<Marks>("be_marks").Find(Query.EQ("prn", prn));
            if (marks.Count() > 0)
            {
                f = true;
                tabControlMarks.Show();
                tabControlMarks.TabPages.Add(tabPage4);
                foreach (Marks i in marks)
                {
                    txt4seatno.Text = i.seat_no;
                    txt4sub1.Text = i.sub1.ToString();
                    txt4sub2.Text = i.sub2.ToString();
                    txt4sub3.Text = i.sub3.ToString();
                    txt4sub4.Text = i.sub4.ToString();
                    txt4sub5.Text = i.sub5.ToString();
                    txt4sub6.Text = i.sub6.ToString();
                    txt4sub7.Text = i.sub7.ToString();
                    txt4sub8.Text = i.sub8.ToString();
                    txt4sub9.Text = i.sub9.ToString();
                    txt4sub10.Text = i.sub10.ToString();
                    txt4sub11.Text = i.sub11.ToString();
                    txt4sub12.Text = i.sub12.ToString();
                    txt4sub13.Text = i.sub13.ToString();
                    txt4sub14.Text = i.sub14.ToString();
                    txt4sub15.Text = i.sub15.ToString();
                    txt4sub16.Text = i.sub16.ToString();
                    txt4sub17.Text = i.sub17.ToString();
                    txt4sub18.Text = i.sub18.ToString();
                    txt4sub19.Text = i.sub19.ToString();
                    txt4sub20.Text = i.sub20.ToString();
                    txt4sub21.Text = i.sub21.ToString();
                    txt4sub22.Text = i.sub22.ToString();
                    txt4sub23.Text = i.sub23.ToString();
                    txt4sub24.Text = i.sub24.ToString();
                }
            }
            if (!f)
                MessageBox.Show("No Marks Entered!");
        }

        private void show_sub(string[] sub,int count,GroupBox gb)
        {
            int x = 0;
            foreach (Control a in gb.Controls.OfType<Control>().OrderBy(c => c.TabIndex))
            {
                if (x != count)
                {
                    if (a is Label)
                    {
                        ((Label)a).Text = sub[x];
                        x++;
                    }
                    a.Show();
                }
            }
        }
        private void load_subject()
        {
            string[] sub11=new string[24];
            string[] sub12 = new string[24];
            string[] sub21 = new string[24];
            string[] sub22 = new string[24];
            string[] sub31 = new string[24];
            string[] sub32 = new string[24];
            string[] sub41 = new string[24];
            string[] sub42 = new string[24];
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Subjects> put = db.GetCollection<Subjects>("Subjects").Find(Query.EQ("academic_year", academic_year)).SetSortOrder(SortBy.Ascending("srno"));
            int x11 = 0;
            int x12 = 0;
            int x21 = 0;
            int x22 = 0;
            int x31 = 0;
            int x32 = 0;
            int x41 = 0;
            int x42 = 0;
            foreach (Subjects i in put)
            {
                if (i.clas == "F.E." && i.semester == "Sem I")
                {
                    sub11[x11++] = i.Subject_Name;
                    sub11[x11++] = i.marks;
                    
                }
                else if(i.clas=="F.E."&&i.semester=="Sem II")
                {
                    sub12[x12++] = i.Subject_Name;
                    sub12[x12++] = i.marks;
                }
                else if (i.clas == "S.E." && i.semester == "Sem I")
                {
                    sub21[x21++] = i.Subject_Name;
                    sub21[x21++] = i.marks;
                }
                else if (i.clas == "S.E." && i.semester == "Sem II")
                {
                    sub22[x22++] = i.Subject_Name;
                    sub22[x22++] = i.marks;
                }
                else if (i.clas == "T.E." && i.semester == "Sem I")
                {
                    sub31[x31++] = i.Subject_Name;
                    sub31[x31++] = i.marks;
                }
                else if (i.clas == "T.E." && i.semester == "Sem II")
                {
                    sub32[x32++] = i.Subject_Name;
                    sub32[x32++] = i.marks;
                }
                else if (i.clas == "B.E." && i.semester == "Sem I")
                {
                    sub41[x41++] = i.Subject_Name;
                    sub41[x41++] = i.marks;
                }
                else if (i.clas == "B.E." && i.semester == "Sem II")
                {
                    sub42[x42++] = i.Subject_Name;
                    sub42[x42++] = i.marks;
                }
            }
            show_sub(sub11, x11, gb11);
            show_sub(sub12, x12, gb12);
            show_sub(sub21, x21, gb21);
            show_sub(sub22, x22, gb22);
            show_sub(sub31, x31, gb31);
            show_sub(sub32, x32, gb32);
            show_sub(sub41, x41, gb41);
            show_sub(sub42, x42, gb42);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clear();
            load_marks(txtprn.Text.Trim());
            load_subject();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            load_marks(dgvStudent.SelectedCells[0].Value.ToString());
            load_subject();
        }

        private void cleargb(GroupBox gb)
        {
            foreach (Control a in gb.Controls)
            {
                if (a is TextBox)
                {
                    ((TextBox)a).Clear();
                    ((TextBox)a).Hide();
                }
                else if (a is Label)
                {
                    ((Label)a).Text="";
                    ((Label)a).Hide();
                }
            }
        }

        private void clear()
        {
            
            cleargb(gb11);
            cleargb(gb12);
            cleargb(gb21);
            cleargb(gb22);
            cleargb(gb31);
            cleargb(gb32);
            cleargb(gb41);
            cleargb(gb42);
            tabControlMarks.TabPages.Remove(tabPage1);
            tabControlMarks.TabPages.Remove(tabPage2);
            tabControlMarks.TabPages.Remove(tabPage3);
            tabControlMarks.TabPages.Remove(tabPage4);
            tabControlMarks.Hide();

        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtprn.Clear();
            clear();
            cmbacademicyear.Focus();
            lblStudentName.Text = "Student Name";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCollection<Marks> marks;
            if (DialogResult.Yes == MessageBox.Show("Do u want to delete this record ?", "", MessageBoxButtons.YesNo))
            {
                marks = db.GetCollection<Marks>("fe_marks");
                if (marks.Count() > 0)
                {
                    foreach (Marks mark in marks.Find(Query.EQ("prn", txtprn.Text.Trim())))
                    {
                        marks.Remove(Query.EQ("prn", txtprn.Text.Trim()));
                        break;
                    }
                }
                marks = db.GetCollection<Marks>("se_marks");
                if (marks.Count() > 0)
                {
                    foreach (Marks mark in marks.Find(Query.EQ("prn", txtprn.Text.Trim())))
                    {
                        marks.Remove(Query.EQ("prn", txtprn.Text.Trim()));
                        break;
                    }
                }
                marks = db.GetCollection<Marks>("te_marks");
                if (marks.Count() > 0)
                {
                    foreach (Marks mark in marks.Find(Query.EQ("prn", txtprn.Text.Trim())))
                    {
                        marks.Remove(Query.EQ("prn", txtprn.Text.Trim()));
                        break;
                    }
                }
                marks = db.GetCollection<Marks>("be_marks");
                if (marks.Count() > 0)
                {
                    foreach (Marks mark in marks.Find(Query.EQ("prn", txtprn.Text.Trim())))
                    {
                        marks.Remove(Query.EQ("prn", txtprn.Text.Trim()));
                        break;
                    }
                }
                clear();
            }
        }

        private void update(MongoCollection<Marks> marks,string column,object data,int o)
        {
            foreach (Marks i in marks.Find(Query.EQ("prn", txtprn.Text.Trim())))
            {
                IMongoUpdate update = new UpdateDocument();
                if(o==0)//insert as integer
                    update = MongoDB.Driver.Builders.Update.Set(column,Convert.ToInt32(data));
                else//insert as string
                    update = MongoDB.Driver.Builders.Update.Set(column, data.ToString());
                marks.Update(Query.EQ("prn", txtprn.Text.Trim()), update);
                break;
            }
        }
        
        public void cal_marks(GroupBox gb,string lblsubm)
        {
            backlog = 0;
            stud_marks = 0;
            stud_tot_marks = 0;
            foreach (Control a in gb.Controls.OfType<Control>().OrderBy(c => c.TabIndex))
            {
                if (a is Label && a.Visible == true && a.Name.Contains(lblsubm))
                {
                    // (whatever will be in label) as we add subject, total marks will get updated 
                    stud_tot_marks += Convert.ToInt32(((Label)a).Text.Trim());
                }
                else if (a is TextBox && a.Visible == true)
                {
                    if (Convert.ToInt32(((TextBox)a).Text.Trim()) < 40)
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
            if (backlog > 0 && backlog <= 3)
                stud_grade = "A.T.K.T.";
            else if (per >= 0 && per < 40 || backlog > 3)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCollection<Marks> marks;
            marks = db.GetCollection<Marks>("fe_marks");
            if (marks.Count() > 0)
            {

                update(marks, "seat_no", txt1seatno.Text.Trim(), 0);

                update(marks, "sub1", txt1sub1.Text.Trim(), 0);
                update(marks, "sub2", txt1sub2.Text.Trim(), 0);
                update(marks, "sub3", txt1sub3.Text.Trim(), 0);
                update(marks, "sub4", txt1sub4.Text.Trim(), 0);
                update(marks, "sub5", txt1sub5.Text.Trim(), 0);
                update(marks, "sub6", txt1sub6.Text.Trim(), 0);
                update(marks, "sub7", txt1sub7.Text.Trim(), 0);
                update(marks, "sub8", txt1sub8.Text.Trim(), 0);
                update(marks, "sub9", txt1sub9.Text.Trim(), 0);
                update(marks, "sub10", txt1sub10.Text.Trim(), 0);
                update(marks, "sub11", txt1sub11.Text.Trim(), 0);
                update(marks, "sub12", txt1sub12.Text.Trim(), 0);
                update(marks, "sub13", txt1sub13.Text.Trim(), 0);
                update(marks, "sub14", txt1sub14.Text.Trim(), 0);
                update(marks, "sub15", txt1sub15.Text.Trim(), 0);
                update(marks, "sub16", txt1sub16.Text.Trim(), 0);
                update(marks, "sub17", txt1sub17.Text.Trim(), 0);
                update(marks, "sub18", txt1sub18.Text.Trim(), 0);
                update(marks, "sub19", txt1sub19.Text.Trim(), 0);
                update(marks, "sub20", txt1sub20.Text.Trim(), 0);
                update(marks, "sub21", txt1sub21.Text.Trim(), 0);
                update(marks, "sub22", txt1sub22.Text.Trim(), 0);
                update(marks, "sub23", txt1sub23.Text.Trim(), 0);
                update(marks, "sub24", txt1sub24.Text.Trim(), 0);
                cal_marks(gb11, "lbl1subm"); // calculate marks
                update(marks, "sem1_total", stud_tot_marks, 0);
                update(marks, "sem1_grade", grade(), 1);
                cal_marks(gb12, "lbl1subm"); // calculate marks
                update(marks, "sem2_total", stud_tot_marks, 0);
                update(marks, "sem2_grade", grade(), 1);
            }
            marks = db.GetCollection<Marks>("se_marks");
            if (marks.Count() > 0)
            {
                update(marks, "seat_no", txt2seatno.Text.Trim(), 0);

                update(marks, "sub1", txt2sub1.Text.Trim(), 0);
                update(marks, "sub2", txt2sub2.Text.Trim(), 0);
                update(marks, "sub3", txt2sub3.Text.Trim(), 0);
                update(marks, "sub4", txt2sub4.Text.Trim(), 0);
                update(marks, "sub5", txt2sub5.Text.Trim(), 0);
                update(marks, "sub6", txt2sub6.Text.Trim(), 0);
                update(marks, "sub7", txt2sub7.Text.Trim(), 0);
                update(marks, "sub8", txt2sub8.Text.Trim(), 0);
                update(marks, "sub9", txt2sub9.Text.Trim(), 0);
                update(marks, "sub10", txt2sub10.Text.Trim(), 0);
                update(marks, "sub11", txt2sub11.Text.Trim(), 0);
                update(marks, "sub12", txt2sub12.Text.Trim(), 0);
                update(marks, "sub13", txt2sub13.Text.Trim(), 0);
                update(marks, "sub14", txt2sub14.Text.Trim(), 0);
                update(marks, "sub15", txt2sub15.Text.Trim(), 0);
                update(marks, "sub16", txt2sub16.Text.Trim(), 0);
                update(marks, "sub17", txt2sub17.Text.Trim(), 0);
                update(marks, "sub18", txt2sub18.Text.Trim(), 0);
                update(marks, "sub19", txt2sub19.Text.Trim(), 0);
                update(marks, "sub20", txt2sub20.Text.Trim(), 0);
                update(marks, "sub21", txt2sub21.Text.Trim(), 0);
                update(marks, "sub22", txt2sub22.Text.Trim(), 0);
                update(marks, "sub23", txt2sub23.Text.Trim(), 0);
                update(marks, "sub24", txt2sub24.Text.Trim(), 0);
                cal_marks(gb21, "lbl2subm"); // calculate marks
                update(marks, "sem1_total", stud_tot_marks, 0);
                update(marks, "sem1_grade", grade(), 1);
                cal_marks(gb22, "lbl2subm"); // calculate marks
                update(marks, "sem2_total", stud_tot_marks, 0);
                update(marks, "sem2_grade", grade(), 1);
            }
            marks = db.GetCollection<Marks>("te_marks");
            if (marks.Count() > 0)
            {
                update(marks, "seat_no", txt3seatno.Text.Trim(), 0);

                update(marks, "sub1", txt3sub1.Text.Trim(), 0);
                update(marks, "sub2", txt3sub2.Text.Trim(), 0);
                update(marks, "sub3", txt3sub3.Text.Trim(), 0);
                update(marks, "sub4", txt3sub4.Text.Trim(), 0);
                update(marks, "sub5", txt3sub5.Text.Trim(), 0);
                update(marks, "sub6", txt3sub6.Text.Trim(), 0);
                update(marks, "sub7", txt3sub7.Text.Trim(), 0);
                update(marks, "sub8", txt3sub8.Text.Trim(), 0);
                update(marks, "sub9", txt3sub9.Text.Trim(), 0);
                update(marks, "sub10", txt3sub10.Text.Trim(), 0);
                update(marks, "sub11", txt3sub11.Text.Trim(), 0);
                update(marks, "sub12", txt3sub12.Text.Trim(), 0);
                update(marks, "sub13", txt3sub13.Text.Trim(), 0);
                update(marks, "sub14", txt3sub14.Text.Trim(), 0);
                update(marks, "sub15", txt3sub15.Text.Trim(), 0);
                update(marks, "sub16", txt3sub16.Text.Trim(), 0);
                update(marks, "sub17", txt3sub17.Text.Trim(), 0);
                update(marks, "sub18", txt3sub18.Text.Trim(), 0);
                update(marks, "sub19", txt3sub19.Text.Trim(), 0);
                update(marks, "sub20", txt3sub20.Text.Trim(), 0);
                update(marks, "sub21", txt3sub21.Text.Trim(), 0);
                update(marks, "sub22", txt3sub22.Text.Trim(), 0);
                update(marks, "sub23", txt3sub23.Text.Trim(), 0);
                update(marks, "sub24", txt3sub24.Text.Trim(), 0);
                cal_marks(gb31, "lbl3subm"); // calculate marks
                update(marks, "sem1_total", stud_tot_marks, 0);
                update(marks, "sem1_grade", grade(), 1);
                cal_marks(gb32, "lbl3subm"); // calculate marks
                update(marks, "sem2_total", stud_tot_marks, 0);
                update(marks, "sem2_grade", grade(), 1);
            }
            marks = db.GetCollection<Marks>("be_marks");
            if (marks.Count() > 0)
            {
                update(marks, "seat_no", txt4seatno.Text.Trim(), 0);

                update(marks, "sub1", txt4sub1.Text.Trim(), 0);
                update(marks, "sub2", txt4sub2.Text.Trim(), 0);
                update(marks, "sub3", txt4sub3.Text.Trim(), 0);
                update(marks, "sub4", txt4sub4.Text.Trim(), 0);
                update(marks, "sub5", txt4sub5.Text.Trim(), 0);
                update(marks, "sub6", txt4sub6.Text.Trim(), 0);
                update(marks, "sub7", txt4sub7.Text.Trim(), 0);
                update(marks, "sub8", txt4sub8.Text.Trim(), 0);
                update(marks, "sub9", txt4sub9.Text.Trim(), 0);
                update(marks, "sub10", txt4sub10.Text.Trim(), 0);
                update(marks, "sub11", txt4sub11.Text.Trim(), 0);
                update(marks, "sub12", txt4sub12.Text.Trim(), 0);
                update(marks, "sub13", txt4sub13.Text.Trim(), 0);
                update(marks, "sub14", txt4sub14.Text.Trim(), 0);
                update(marks, "sub15", txt4sub15.Text.Trim(), 0);
                update(marks, "sub16", txt4sub16.Text.Trim(), 0);
                update(marks, "sub17", txt4sub17.Text.Trim(), 0);
                update(marks, "sub18", txt4sub18.Text.Trim(), 0);
                update(marks, "sub19", txt4sub19.Text.Trim(), 0);
                update(marks, "sub20", txt4sub20.Text.Trim(), 0);
                update(marks, "sub21", txt4sub21.Text.Trim(), 0);
                update(marks, "sub22", txt4sub22.Text.Trim(), 0);
                update(marks, "sub23", txt4sub23.Text.Trim(), 0);
                update(marks, "sub24", txt4sub24.Text.Trim(), 0);
                cal_marks(gb41, "lbl4subm"); // calculate marks
                update(marks, "sem1_total", stud_tot_marks, 0);
                update(marks, "sem1_grade", grade(), 1);
                cal_marks(gb42, "lbl4subm"); // calculate marks
                update(marks, "sem2_total", stud_tot_marks, 0);
                update(marks, "sem2_grade", grade(), 1);
            }
        }

        private void txtprn_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtprn.Text) || txtprn.Text.Length != 9)
            {
                MessageBox.Show("Enter Valid PRN No!");
                txtprn.Focus();
            }
        }
    }
}
