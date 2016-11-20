namespace Result_Analysis_for_NBA.Marks_Entry
{
    partial class frmMarks_Entry
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
            this.btnnext = new System.Windows.Forms.Button();
            this.cmbsem = new System.Windows.Forms.ComboBox();
            this.lblsem = new System.Windows.Forms.Label();
            this.lblclass = new System.Windows.Forms.Label();
            this.rdbe = new System.Windows.Forms.RadioButton();
            this.rdte = new System.Windows.Forms.RadioButton();
            this.rdse = new System.Windows.Forms.RadioButton();
            this.rdfe = new System.Windows.Forms.RadioButton();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.cmbacademicyear = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(292, 194);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 37);
            this.btnnext.TabIndex = 6;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // cmbsem
            // 
            this.cmbsem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbsem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbsem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsem.FormattingEnabled = true;
            this.cmbsem.Items.AddRange(new object[] {
            "Sem I",
            "Sem II"});
            this.cmbsem.Location = new System.Drawing.Point(273, 144);
            this.cmbsem.Name = "cmbsem";
            this.cmbsem.Size = new System.Drawing.Size(121, 21);
            this.cmbsem.TabIndex = 5;
            // 
            // lblsem
            // 
            this.lblsem.AutoSize = true;
            this.lblsem.Location = new System.Drawing.Point(192, 150);
            this.lblsem.Name = "lblsem";
            this.lblsem.Size = new System.Drawing.Size(54, 13);
            this.lblsem.TabIndex = 9;
            this.lblsem.Text = "Semester:";
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.Location = new System.Drawing.Point(207, 104);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(35, 13);
            this.lblclass.TabIndex = 8;
            this.lblclass.Text = "Class:";
            // 
            // rdbe
            // 
            this.rdbe.AutoSize = true;
            this.rdbe.Location = new System.Drawing.Point(472, 103);
            this.rdbe.Name = "rdbe";
            this.rdbe.Size = new System.Drawing.Size(45, 17);
            this.rdbe.TabIndex = 4;
            this.rdbe.TabStop = true;
            this.rdbe.Text = "B.E.";
            this.rdbe.UseVisualStyleBackColor = true;
            // 
            // rdte
            // 
            this.rdte.AutoSize = true;
            this.rdte.Location = new System.Drawing.Point(403, 103);
            this.rdte.Name = "rdte";
            this.rdte.Size = new System.Drawing.Size(45, 17);
            this.rdte.TabIndex = 3;
            this.rdte.TabStop = true;
            this.rdte.Text = "T.E.";
            this.rdte.UseVisualStyleBackColor = true;
            // 
            // rdse
            // 
            this.rdse.AutoSize = true;
            this.rdse.Location = new System.Drawing.Point(335, 103);
            this.rdse.Name = "rdse";
            this.rdse.Size = new System.Drawing.Size(45, 17);
            this.rdse.TabIndex = 2;
            this.rdse.TabStop = true;
            this.rdse.Text = "S.E.";
            this.rdse.UseVisualStyleBackColor = true;
            // 
            // rdfe
            // 
            this.rdfe.AutoSize = true;
            this.rdfe.Location = new System.Drawing.Point(273, 103);
            this.rdfe.Name = "rdfe";
            this.rdfe.Size = new System.Drawing.Size(44, 17);
            this.rdfe.TabIndex = 1;
            this.rdfe.TabStop = true;
            this.rdfe.Text = "F.E.";
            this.rdfe.UseVisualStyleBackColor = true;
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
            // cmbacademicyear
            // 
            this.cmbacademicyear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbacademicyear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbacademicyear.FormattingEnabled = true;
            this.cmbacademicyear.Location = new System.Drawing.Point(273, 52);
            this.cmbacademicyear.Name = "cmbacademicyear";
            this.cmbacademicyear.Size = new System.Drawing.Size(170, 21);
            this.cmbacademicyear.Sorted = true;
            this.cmbacademicyear.TabIndex = 0;
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(165, 59);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(79, 13);
            this.year.TabIndex = 7;
            this.year.Text = "Academic Year";
            // 
            // frmMarks_Entry
            // 
            this.AcceptButton = this.btnnext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 309);
            this.Controls.Add(this.cmbacademicyear);
            this.Controls.Add(this.year);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.cmbsem);
            this.Controls.Add(this.lblsem);
            this.Controls.Add(this.lblclass);
            this.Controls.Add(this.rdbe);
            this.Controls.Add(this.rdte);
            this.Controls.Add(this.rdse);
            this.Controls.Add(this.rdfe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMarks_Entry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmMarks_Entry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.ComboBox cmbsem;
        private System.Windows.Forms.Label lblsem;
        private System.Windows.Forms.Label lblclass;
        private System.Windows.Forms.RadioButton rdbe;
        private System.Windows.Forms.RadioButton rdte;
        private System.Windows.Forms.RadioButton rdse;
        private System.Windows.Forms.RadioButton rdfe;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.ComboBox cmbacademicyear;
        private System.Windows.Forms.Label year;
    }
}