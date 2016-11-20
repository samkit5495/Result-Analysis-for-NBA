namespace Result_Analysis_for_NBA
{
    partial class frmView_Staff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvstaff = new System.Windows.Forms.DataGridView();
            this.Staff_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtstaffname = new System.Windows.Forms.TextBox();
            this.txtstaff_id = new System.Windows.Forms.TextBox();
            this.teaher = new System.Windows.Forms.Label();
            this.employee = new System.Windows.Forms.Label();
            this.picHome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvstaff
            // 
            this.dgvstaff.AllowUserToAddRows = false;
            this.dgvstaff.AllowUserToDeleteRows = false;
            this.dgvstaff.AllowUserToOrderColumns = true;
            this.dgvstaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Staff_Id,
            this.name});
            this.dgvstaff.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvstaff.Location = new System.Drawing.Point(606, 0);
            this.dgvstaff.MultiSelect = false;
            this.dgvstaff.Name = "dgvstaff";
            this.dgvstaff.ReadOnly = true;
            this.dgvstaff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvstaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvstaff.Size = new System.Drawing.Size(244, 528);
            this.dgvstaff.TabIndex = 1;
            this.dgvstaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstaff_CellContentClick);
            // 
            // Staff_Id
            // 
            this.Staff_Id.HeaderText = "Staff Id";
            this.Staff_Id.Name = "Staff_Id";
            this.Staff_Id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnreset);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtstaffname);
            this.panel1.Controls.Add(this.txtstaff_id);
            this.panel1.Controls.Add(this.teaher);
            this.panel1.Controls.Add(this.employee);
            this.panel1.Location = new System.Drawing.Point(76, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 321);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(36, 198);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 41);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(325, 198);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 41);
            this.btnreset.TabIndex = 6;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 198);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 41);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(135, 198);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 41);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Tag = "";
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(354, 95);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtstaffname
            // 
            this.txtstaffname.Location = new System.Drawing.Point(127, 139);
            this.txtstaffname.Name = "txtstaffname";
            this.txtstaffname.Size = new System.Drawing.Size(170, 20);
            this.txtstaffname.TabIndex = 2;
            this.txtstaffname.Validating += new System.ComponentModel.CancelEventHandler(this.txtstaffname_Validating);
            // 
            // txtstaff_id
            // 
            this.txtstaff_id.Location = new System.Drawing.Point(127, 104);
            this.txtstaff_id.Name = "txtstaff_id";
            this.txtstaff_id.Size = new System.Drawing.Size(170, 20);
            this.txtstaff_id.TabIndex = 0;
            // 
            // teaher
            // 
            this.teaher.AutoSize = true;
            this.teaher.Location = new System.Drawing.Point(19, 145);
            this.teaher.Name = "teaher";
            this.teaher.Size = new System.Drawing.Size(35, 13);
            this.teaher.TabIndex = 8;
            this.teaher.Text = "Name";
            // 
            // employee
            // 
            this.employee.AutoSize = true;
            this.employee.Location = new System.Drawing.Point(19, 110);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(41, 13);
            this.employee.TabIndex = 7;
            this.employee.Text = "Staff Id";
            // 
            // picHome
            // 
            this.picHome.Image = global::Result_Analysis_for_NBA.Properties.Resources.home;
            this.picHome.Location = new System.Drawing.Point(9, 9);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(54, 54);
            this.picHome.TabIndex = 40;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // frmView_Staff
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(850, 528);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvstaff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmView_Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Staff";
            this.Load += new System.EventHandler(this.frmView_Staff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvstaff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtstaffname;
        private System.Windows.Forms.TextBox txtstaff_id;
        private System.Windows.Forms.Label teaher;
        private System.Windows.Forms.Label employee;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Staff_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}