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
    public partial class frmView_Staff : Form
    {
        public frmView_Staff()
        {
            InitializeComponent();
        }

        private void txtstaffname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtstaffname.Text))
            {
                MessageBox.Show("Enter Valid Name!");
                txtstaffname.Focus();
            }
        }

        private bool validateForm()
        {
            foreach (Control a in panel1.Controls)
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
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                bool f = true;
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");
                MongoCursor<Staffs> put = db.GetCollection<Staffs>("Staffs").FindAll();
                foreach (Staffs i in put)
                {
                    if (txtstaff_id.Text == i.staff_id)
                    {
                        f = false;
                        MessageBox.Show("Staff Id already exists!");
                        txtstaff_id.Focus();
                        break;
                    }
                }
                if (f)
                {
                    MongoCollection<BsonDocument> Staffs = db.GetCollection<BsonDocument>("Staffs");
                    BsonDocument staff = new BsonDocument
                    {
                        {"staff_id",txtstaff_id.Text.Trim()},
                        {"staff_name",txtstaffname.Text.Trim()}
                    };
                    Staffs.Insert(staff);
                    MessageBox.Show("Record Added Successfully");
                    refresh();
                }
                clear();
            }
        }
        private void refresh()
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Staffs> put = db.GetCollection<Staffs>("Staffs").FindAll();
            dgvstaff.RowCount = 0;
            foreach (Staffs i in put)
            {
                dgvstaff.Rows.Add(Convert.ToString(i.staff_id), Convert.ToString(i.staff_name));
            }
        }

        public void clear()
        {
            txtstaff_id.Text = "";
            txtstaffname.Text = "";
            txtstaff_id.Focus();
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void frmView_Staff_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                bool f = false;
                MongoClient client = new MongoClient("mongodb://localhost");
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("NBA");

                MongoCursor<Staffs> put = db.GetCollection<Staffs>("Staffs").FindAll();
                foreach (Staffs i in put)
                {
                    if (txtstaff_id.Text == i.staff_id)
                    {
                        f = true;
                        break;
                    }
                }
                if (f)
                {
                    MongoCollection<Staffs> staffs = db.GetCollection<Staffs>("Staffs");
                    foreach (Staffs i in staffs.Find(Query.EQ("staff_id", txtstaff_id.Text.Trim())))
                    {
                        IMongoUpdate update = new UpdateDocument();
                        if (txtstaff_id.Text != "")
                        {
                            update = MongoDB.Driver.Builders.Update.Set("staff_name", txtstaffname.Text.Trim());
                        }
                        staffs.Update(Query.EQ("staff_id", txtstaff_id.Text.Trim()), update);
                        MessageBox.Show("Record Updated!");
                        refresh();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Staff Id does not exists!");
                    txtstaff_id.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCollection<Staffs> staffs = db.GetCollection<Staffs>("Staffs");
            foreach (Staffs staff in staffs.Find(Query.EQ("staff_id", txtstaff_id.Text.Trim())))
            {
                if (DialogResult.Yes == MessageBox.Show("Do u want to delete this record ?", "", MessageBoxButtons.YesNo))
                {
                    staffs.Remove(Query.EQ("staff_id", txtstaff_id.Text.Trim()));
                    MessageBox.Show("Record successfully deleted!");
                    clear();
                    refresh();
                }
                break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Staffs> put = db.GetCollection<Staffs>("Staffs").FindAll();
            bool f = false;
            foreach (Staffs i in put)
            {
                if (txtstaff_id.Text.Trim() == i.staff_id)
                {
                    txtstaffname.Text = i.staff_name;
                    f = true;
                    break;
                }
            }
            if (!f)
                MessageBox.Show("Record not found!");
        }

        private void picHome_Click(object sender, EventArgs e)
        {           
            this.Hide();
        }

        private void dgvstaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //when click on record fronm datagrid view then all fields  get filled in textbox
            txtstaff_id.Text = dgvstaff.SelectedCells[0].Value.ToString();
            txtstaffname.Text = dgvstaff.SelectedCells[1].Value.ToString();
        }
    }
}
