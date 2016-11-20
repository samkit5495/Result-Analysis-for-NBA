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
using System.IO;

namespace Result_Analysis_for_NBA.Settings
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        public string u_name,username,password,type,security,answer,email,mobileno;
        public int o=0;

        //change password
        private void btnSaveChangePassword_Click(object sender, EventArgs e)
        {
            if (password != txtoldpassword.Text)
            {
                // validate old password
                MessageBox.Show("Wrong Password!"); 
                txtoldpassword.Focus();
            }
            else if (validateForm())
            {
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCollection<User> Users = db.GetCollection<User>("Users");
                foreach (User i in Users.Find(Query.EQ("username", username)))
                {
                    IMongoUpdate update = new UpdateDocument();
                    //update password
                    update = MongoDB.Driver.Builders.Update.Set("password", txtnewpassword.Text.Trim());

                    Users.Update(Query.EQ("username", username), update);
                    MessageBox.Show("Password Updated");
                    break;
                }
            }
        }
        
        //validate passsword
        private void txtnewpassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnewpassword.Text))
            {
                MessageBox.Show("Enter New Password!");
                txtnewpassword.Focus();
            }
        }
         // vvalidate username
        private void txtnewusername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnewusername.Text))
            {
                MessageBox.Show("Enter New Username!");
                txtnewusername.Focus();
            }
        }
        
        //validate confirm password
        private void txtconfirmpassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtnewpassword.Text != txtconfirmpassword.Text)
            {
                MessageBox.Show("Password Mismatch!");
                txtconfirmpassword.Focus();
            }
        }

        //change username, validate if not equal to old username
        private void btnSaveUsername_Click(object sender, EventArgs e)
        {
            if (username != txtoldusername.Text)
            {
                MessageBox.Show("Wrong Username!");
                txtoldusername.Focus();
            }
            else if (validateForm())
            {
                bool f=false;
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();
                foreach (User i in put)
                {
                    
                    if (txtnewusername.Text == i.username)
                    {
                        f = true;
                        MessageBox.Show("Username already exists!");
                        txtnewusername.Focus();
                        break;
                    }
                }
                if (!f)
                {   //change username
                    MongoCollection<User> Users = db.GetCollection<User>("Users");
                    foreach (User i in Users.Find(Query.EQ("username", username)))
                    {

                        IMongoUpdate update = new UpdateDocument();

                        update = MongoDB.Driver.Builders.Update.Set("username", txtnewusername.Text.Trim());

                        Users.Update(Query.EQ("username", username), update);
                        MessageBox.Show("Username Updated");
                        username = txtnewusername.Text;
                        txtoldusername.Text = "";
                        txtnewusername.Text = "";
                        txtconfirmusername.Text = "";
                        break;
                    }
                }
            }
        }

        //edit users
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistration_Form obj = new frmRegistration_Form();
                obj.username = dgvUsers.SelectedCells[1].Value.ToString();
                obj.update = true;
                obj.u_name = u_name;
                obj.pusername = username;
                obj.password = password;
                obj.ptype = type;
                obj.security = security;
                obj.answer = answer;
                obj.email = email;
                obj.mobileno = mobileno;
                this.Hide();
                obj.Show();
            }

            //if record not selected to display in datagridview from selections then give error
            catch (NullReferenceException)
            {
                MessageBox.Show("Select a Record from the list!");
            }
        }

        

        //delete user
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCollection<User> users = db.GetCollection<User>("Users");
            try
            {
                foreach (User user in users.Find(Query.EQ("username", dgvUsers.SelectedCells[1].Value.ToString())))
                {
                    //show alert message before deleting
                    if (DialogResult.Yes == MessageBox.Show("Do u want to delete this record ?", "", MessageBoxButtons.YesNo))
                    {
                        users.Remove(Query.EQ("username", dgvUsers.SelectedCells[1].Value.ToString()));
                        MessageBox.Show("Record successfully deleted!");
                        refreshUsers();
                    }
                    break;
                }
            }
            // if record not selected to delete from selections
            catch(NullReferenceException)
            {
                MessageBox.Show("Select a Record from the list!");
            }
        }

        private void cmbacademicyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshSubjects(1);
        }

        
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            frmView_Subject obj = new frmView_Subject();
            obj.u_name = u_name;
            obj.pusername = username;
            obj.password = password;
            obj.ptype = type;
            obj.security = security;
            obj.answer = answer;
            obj.email = email;
            obj.mobileno = mobileno;
            obj.academicyear = cmbacademicyear.Text.Trim();
            this.Hide();
            obj.Show();
        }

        private void btnEditSubject_Click(object sender, EventArgs e)
        {
            try
            {
                frmView_Subject obj = new frmView_Subject();
                obj.Subject_Name = dgvSubjects.SelectedCells[3].Value.ToString();
                obj.update = true;
                obj.u_name = u_name;
                obj.pusername = username;
                obj.password = password;
                obj.ptype = type;
                obj.security = security;
                obj.answer = answer;
                obj.email = email;
                obj.mobileno = mobileno;
                this.Hide();
                obj.Show();
            }
            catch(Exception)
            {
                MessageBox.Show("First select Data to edit!");
            }
        }

        //delete subject
        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCollection<Subjects> subjects = db.GetCollection<Subjects>("Subjects");
            try
            {
                foreach (Subjects subject in subjects.Find(Query.EQ("Subject_Name", dgvUsers.SelectedCells[1].Value.ToString())))
                {
                    if (DialogResult.Yes == MessageBox.Show("Do u want to delete this record ?", "", MessageBoxButtons.YesNo))
                    {
                        subjects.Remove(Query.EQ("username", dgvUsers.SelectedCells[2].Value.ToString()));
                        MessageBox.Show("Record successfully deleted!");
                        refreshUsers();
                    }
                    break;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select a Record from the list!");
            }
        }

        //take backup
        private void btnBackup_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            //stop server first
            server.stop();
            //source path form where backup will be taken
            string sourcePath = @"F:\Dropbox\Documents\College Programs\Project\NBA Project\Result Analysis for NBA\DB";
           
            //target path where bakup will be stored
            string targetPath;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //select path for target
                targetPath = folderBrowserDialog1.SelectedPath+"\\"+DateTime.Now.ToString("yyyy-M-d h.mm");
                //if path does not exists then create path
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                //if sourcepath exists then get files from their
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                    MessageBox.Show("Backup Successful!!!");
                }
                else
                {
                    Console.WriteLine("Database not found!!!");
                }
            }
            //start server again
            server.start();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.stop();
            string sourcePath;
            string targetPath = @"F:\Dropbox\Documents\College Programs\Project\NBA Project\Result Analysis for NBA\DB";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                sourcePath = folderBrowserDialog1.SelectedPath;
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                    MessageBox.Show("Restored Successful!!!");
                }
                else
                {
                    Console.WriteLine("Database not found!!!");
                }
            }
            server.start();
        }

        private void txtmobile_Validating(object sender, CancelEventArgs e)
        {
            if (txtmobile.Modified == false)
            {

                MessageBox.Show("Please enter mobile no");
                txtmobile.Focus();

            }
            else if (!txtmobile.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("Enter only Digits!!!");
                txtmobile.Focus();
            }
            else if (txtmobile.Text.Length != 10)
            {
                MessageBox.Show("Incorrect mobile no!");
                txtmobile.Focus();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmRegistration_Form obj = new frmRegistration_Form();
            obj.u_name = u_name;
            obj.pusername = username;
            obj.password = password;
            obj.ptype = type;
            obj.security = security;
            obj.answer = answer;
            obj.email = email;
            obj.mobileno = mobileno;
            this.Hide();
            obj.Show();
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            frmHome_Page obj = new frmHome_Page();
            obj.username = username;
            obj.type = type;
            this.Hide();
            obj.Show();
        }

        private bool validateForm()
        {
            foreach (Control a in tabPagePersonalInformation.Controls)
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

        //edit users information
        private void btnSavePersonalInfo_Click(object sender, EventArgs e)
        {
            if(validateForm())
            {
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCollection<User> Users = db.GetCollection<User>("Users");
                foreach (User i in Users.Find(Query.EQ("username", username)))
                {
                    IMongoUpdate update1 = new UpdateDocument();
                    IMongoUpdate update2 = new UpdateDocument();
                    IMongoUpdate update3 = new UpdateDocument();
                    IMongoUpdate update4 = new UpdateDocument();
                    IMongoUpdate update5 = new UpdateDocument();

                    update1 = MongoDB.Driver.Builders.Update.Set("name", txtname.Text.Trim());
                    update2 = MongoDB.Driver.Builders.Update.Set("security", combosecurity.Text.Trim());
                    update3 = MongoDB.Driver.Builders.Update.Set("answer", txtanswer.Text.Trim());
                    update4 = MongoDB.Driver.Builders.Update.Set("email", txtemail.Text.Trim());
                    update5 = MongoDB.Driver.Builders.Update.Set("mobileno", txtmobile.Text.Trim());

                    Users.Update(Query.EQ("username", username), update1);
                    Users.Update(Query.EQ("username", username), update2);
                    Users.Update(Query.EQ("username", username), update3);
                    Users.Update(Query.EQ("username", username), update4);
                    Users.Update(Query.EQ("username", username), update5);
                    MessageBox.Show("Information Updated");
                    break;
                }
            }
        }

        //whenever we perform operation on users list datagrid view get refreshed
        private void refreshUsers()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<User> put = db.GetCollection<User>("Users").FindAll();

            dgvUsers.RowCount = 0;
            foreach (User i in put)
            {
                dgvUsers.Rows.Add(Convert.ToString(i.name), Convert.ToString(i.username),Convert.ToString(i.type));
            }
        }
        private void refreshSubjects(int o)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Subjects> put;
            //if give specigic academic yer then show recors according to year
            if (o == 1)
            {
                put = db.GetCollection<Subjects>("Subjects").Find(Query.EQ("academic_year", cmbacademicyear.Text.Trim()));
                dgvSubjects.RowCount = 0;
            }
                //otherwise show all records
            else
                put = db.GetCollection<Subjects>("Subjects").FindAll();
            foreach (Subjects i in put)
            {
                if(o==1)
                    dgvSubjects.Rows.Add(Convert.ToString(i.srno),Convert.ToString(i.clas), Convert.ToString(i.semester), Convert.ToString(i.Subject_Name), Convert.ToString(i.marks),Convert.ToString(i.Staff_Name));
                else if (!cmbacademicyear.Items.Contains(i.academic_year))
                    cmbacademicyear.Items.Add(i.academic_year);
            }
        }
        private void frmSettings_Load(object sender, EventArgs e)
        {
            // Hide the tab page
            tabControlSettings.TabPages.Remove(tabPageEditUsers);

            txtname.Text = u_name;
            combosecurity.Text = security;
            txtanswer.Text = answer;
            txtemail.Text = email;
            txtmobile.Text = mobileno;

            if (type=="Admin")
            {
                // Show the tab page (insert it to the correct position)
                tabControlSettings.TabPages.Insert(4, tabPageEditUsers);
                refreshUsers();
            }
            refreshSubjects(0);
            if (o == 0)
                tabControlSettings.SelectedIndex = 0;
            else if(o==1)
                tabControlSettings.SelectedIndex = 3;
            else
                tabControlSettings.SelectedIndex = 4;

        }
    }
}
