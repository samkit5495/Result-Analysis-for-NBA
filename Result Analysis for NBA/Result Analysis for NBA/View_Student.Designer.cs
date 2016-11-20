namespace Result_Analysis_for_NBA
{
    partial class frmView_Student
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
            this.dgvstudent = new System.Windows.Forms.DataGridView();
            this.prnno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.academic_year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admission_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.migration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbMigration = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rddse = new System.Windows.Forms.RadioButton();
            this.rdfe = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbacademicyear = new System.Windows.Forms.ComboBox();
            this.txtstudent_name = new System.Windows.Forms.TextBox();
            this.txtprn = new System.Windows.Forms.TextBox();
            this.year = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.prn = new System.Windows.Forms.Label();
            this.picHome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstudent)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvstudent
            // 
            this.dgvstudent.AllowUserToAddRows = false;
            this.dgvstudent.AllowUserToDeleteRows = false;
            this.dgvstudent.AllowUserToOrderColumns = true;
            this.dgvstudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prnno,
            this.name,
            this.academic_year,
            this.admission_type,
            this.migration});
            this.dgvstudent.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvstudent.Location = new System.Drawing.Point(442, 0);
            this.dgvstudent.MultiSelect = false;
            this.dgvstudent.Name = "dgvstudent";
            this.dgvstudent.ReadOnly = true;
            this.dgvstudent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvstudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvstudent.Size = new System.Drawing.Size(515, 508);
            this.dgvstudent.TabIndex = 1;
            this.dgvstudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstudent_CellContentClick);
            // 
            // prnno
            // 
            this.prnno.HeaderText = "PRN No";
            this.prnno.Name = "prnno";
            this.prnno.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // academic_year
            // 
            this.academic_year.HeaderText = "Academic Year";
            this.academic_year.Name = "academic_year";
            this.academic_year.ReadOnly = true;
            // 
            // admission_type
            // 
            this.admission_type.HeaderText = "Admission Type";
            this.admission_type.Name = "admission_type";
            this.admission_type.ReadOnly = true;
            // 
            // migration
            // 
            this.migration.HeaderText = "Migration";
            this.migration.Name = "migration";
            this.migration.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbMigration);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rddse);
            this.panel1.Controls.Add(this.rdfe);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnreset);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.cmbacademicyear);
            this.panel1.Controls.Add(this.txtstudent_name);
            this.panel1.Controls.Add(this.txtprn);
            this.panel1.Controls.Add(this.year);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.prn);
            this.panel1.Location = new System.Drawing.Point(12, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 291);
            this.panel1.TabIndex = 0;
            // 
            // cmbMigration
            // 
            this.cmbMigration.AutoCompleteCustomSource.AddRange(new string[] {
            "No"});
            this.cmbMigration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMigration.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMigration.CausesValidation = false;
            this.cmbMigration.FormattingEnabled = true;
            this.cmbMigration.Items.AddRange(new object[] {
            "No"});
            this.cmbMigration.Location = new System.Drawing.Point(128, 183);
            this.cmbMigration.Name = "cmbMigration";
            this.cmbMigration.Size = new System.Drawing.Size(157, 21);
            this.cmbMigration.Sorted = true;
            this.cmbMigration.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Migration";
            // 
            // rddse
            // 
            this.rddse.AutoSize = true;
            this.rddse.Location = new System.Drawing.Point(249, 153);
            this.rddse.Name = "rddse";
            this.rddse.Size = new System.Drawing.Size(56, 17);
            this.rddse.TabIndex = 5;
            this.rddse.TabStop = true;
            this.rddse.Text = "D.S.E.";
            this.rddse.UseVisualStyleBackColor = true;
            // 
            // rdfe
            // 
            this.rdfe.AutoSize = true;
            this.rdfe.Location = new System.Drawing.Point(150, 153);
            this.rdfe.Name = "rdfe";
            this.rdfe.Size = new System.Drawing.Size(44, 17);
            this.rdfe.TabIndex = 4;
            this.rdfe.TabStop = true;
            this.rdfe.Text = "F.E.";
            this.rdfe.UseVisualStyleBackColor = true;
            this.rdfe.Validating += new System.ComponentModel.CancelEventHandler(this.rdfe_Validating);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 225);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 41);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(333, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 34);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(301, 225);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 41);
            this.btnreset.TabIndex = 10;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(206, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 41);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(108, 225);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 41);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Tag = "";
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbacademicyear
            // 
            this.cmbacademicyear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbacademicyear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbacademicyear.FormattingEnabled = true;
            this.cmbacademicyear.Location = new System.Drawing.Point(128, 107);
            this.cmbacademicyear.Name = "cmbacademicyear";
            this.cmbacademicyear.Size = new System.Drawing.Size(157, 21);
            this.cmbacademicyear.Sorted = true;
            this.cmbacademicyear.TabIndex = 3;
            // 
            // txtstudent_name
            // 
            this.txtstudent_name.Location = new System.Drawing.Point(128, 62);
            this.txtstudent_name.Name = "txtstudent_name";
            this.txtstudent_name.Size = new System.Drawing.Size(160, 20);
            this.txtstudent_name.TabIndex = 2;
            this.txtstudent_name.Validating += new System.ComponentModel.CancelEventHandler(this.txtstudent_name_Validating);
            // 
            // txtprn
            // 
            this.txtprn.Location = new System.Drawing.Point(128, 17);
            this.txtprn.Name = "txtprn";
            this.txtprn.Size = new System.Drawing.Size(160, 20);
            this.txtprn.TabIndex = 0;
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(40, 114);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(79, 13);
            this.year.TabIndex = 13;
            this.year.Text = "Academic Year";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(40, 64);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 12;
            this.label.Text = "Name";
            // 
            // prn
            // 
            this.prn.AutoSize = true;
            this.prn.Location = new System.Drawing.Point(40, 16);
            this.prn.Name = "prn";
            this.prn.Size = new System.Drawing.Size(50, 13);
            this.prn.TabIndex = 11;
            this.prn.Text = "PRN No.";
            // 
            // picHome
            // 
            this.picHome.Image = global::Result_Analysis_for_NBA.Properties.Resources.home;
            this.picHome.Location = new System.Drawing.Point(12, 12);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(54, 54);
            this.picHome.TabIndex = 41;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // frmView_Student
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 508);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvstudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmView_Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Student";
            this.Load += new System.EventHandler(this.frmView_Student_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstudent)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvstudent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rddse;
        private System.Windows.Forms.RadioButton rdfe;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cmbacademicyear;
        private System.Windows.Forms.TextBox txtstudent_name;
        private System.Windows.Forms.TextBox txtprn;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label prn;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.ComboBox cmbMigration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn prnno;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn academic_year;
        private System.Windows.Forms.DataGridViewTextBoxColumn admission_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn migration;
    }
}