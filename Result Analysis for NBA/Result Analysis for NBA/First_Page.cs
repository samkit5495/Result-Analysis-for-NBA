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
    public partial class frmFirst_Page : Form
    {
        public frmFirst_Page()
        {
            InitializeComponent();
        }

        private void frmFirst_Page_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Black;
            this.BackColor = Color.Black;
            timer1.Start();       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            frmLogin obj = new frmLogin();
            this.Hide();
            obj.Show();
        }
    }
}
