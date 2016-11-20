namespace Result_Analysis_for_NBA.Settings
{
    partial class frmView_Subject
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
            this.picBack = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbsrno = new System.Windows.Forms.ComboBox();
            this.lbljj = new System.Windows.Forms.Label();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbStaff_Name = new System.Windows.Forms.ComboBox();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubject_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.teaher = new System.Windows.Forms.Label();
            this.cmbacademicyear = new System.Windows.Forms.ComboBox();
            this.year = new System.Windows.Forms.Label();
            this.cmbsem = new System.Windows.Forms.ComboBox();
            this.lblsem = new System.Windows.Forms.Label();
            this.lblclass = new System.Windows.Forms.Label();
            this.rdbe = new System.Windows.Forms.RadioButton();
            this.rdte = new System.Windows.Forms.RadioButton();
            this.rdse = new System.Windows.Forms.RadioButton();
            this.rdfe = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBack
            // 
            this.picBack.Image = global::Result_Analysis_for_NBA.Properties.Resources.back;
            this.picBack.Location = new System.Drawing.Point(12, 12);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(54, 54);
            this.picBack.TabIndex = 63;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbsrno);
            this.panel1.Controls.Add(this.lbljj);
            this.panel1.Controls.Add(this.btnreset);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbStaff_Name);
            this.panel1.Controls.Add(this.txtMarks);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSubject_Name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.teaher);
            this.panel1.Controls.Add(this.cmbacademicyear);
            this.panel1.Controls.Add(this.year);
            this.panel1.Controls.Add(this.cmbsem);
            this.panel1.Controls.Add(this.lblsem);
            this.panel1.Controls.Add(this.lblclass);
            this.panel1.Controls.Add(this.rdbe);
            this.panel1.Controls.Add(this.rdte);
            this.panel1.Controls.Add(this.rdse);
            this.panel1.Controls.Add(this.rdfe);
            this.panel1.Location = new System.Drawing.Point(100, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 347);
            this.panel1.TabIndex = 0;
            // 
            // cmbsrno
            // 
            this.cmbsrno.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbsrno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsrno.FormattingEnabled = true;
            this.cmbsrno.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbsrno.Location = new System.Drawing.Point(138, 142);
            this.cmbsrno.Name = "cmbsrno";
            this.cmbsrno.Size = new System.Drawing.Size(73, 21);
            this.cmbsrno.TabIndex = 6;
            // 
            // lbljj
            // 
            this.lbljj.AutoSize = true;
            this.lbljj.Location = new System.Drawing.Point(59, 144);
            this.lbljj.Name = "lbljj";
            this.lbljj.Size = new System.Drawing.Size(40, 13);
            this.lbljj.TabIndex = 15;
            this.lbljj.Text = "Sr. No.";
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(228, 288);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 37);
            this.btnreset.TabIndex = 11;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(72, 288);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 37);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbStaff_Name
            // 
            this.cmbStaff_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStaff_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStaff_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff_Name.FormattingEnabled = true;
            this.cmbStaff_Name.Location = new System.Drawing.Point(133, 254);
            this.cmbStaff_Name.Name = "cmbStaff_Name";
            this.cmbStaff_Name.Size = new System.Drawing.Size(170, 21);
            this.cmbStaff_Name.Sorted = true;
            this.cmbStaff_Name.TabIndex = 9;
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(133, 216);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(170, 20);
            this.txtMarks.TabIndex = 8;
            this.txtMarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtMarks_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Marks";
            // 
            // txtSubject_Name
            // 
            this.txtSubject_Name.Location = new System.Drawing.Point(133, 179);
            this.txtSubject_Name.Name = "txtSubject_Name";
            this.txtSubject_Name.Size = new System.Drawing.Size(168, 20);
            this.txtSubject_Name.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Subject Name";
            // 
            // teaher
            // 
            this.teaher.AutoSize = true;
            this.teaher.Location = new System.Drawing.Point(41, 257);
            this.teaher.Name = "teaher";
            this.teaher.Size = new System.Drawing.Size(60, 13);
            this.teaher.TabIndex = 18;
            this.teaher.Text = "Staff Name";
            // 
            // cmbacademicyear
            // 
            this.cmbacademicyear.FormattingEnabled = true;
            this.cmbacademicyear.Location = new System.Drawing.Point(133, 28);
            this.cmbacademicyear.Name = "cmbacademicyear";
            this.cmbacademicyear.Size = new System.Drawing.Size(170, 21);
            this.cmbacademicyear.Sorted = true;
            this.cmbacademicyear.TabIndex = 0;
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(25, 35);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(79, 13);
            this.year.TabIndex = 12;
            this.year.Text = "Academic Year";
            // 
            // cmbsem
            // 
            this.cmbsem.AutoCompleteCustomSource.AddRange(new string[] {
            "Sem I",
            "Sem II"});
            this.cmbsem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbsem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbsem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsem.FormattingEnabled = true;
            this.cmbsem.Items.AddRange(new object[] {
            "Sem I",
            "Sem II"});
            this.cmbsem.Location = new System.Drawing.Point(135, 107);
            this.cmbsem.Name = "cmbsem";
            this.cmbsem.Size = new System.Drawing.Size(119, 21);
            this.cmbsem.TabIndex = 5;
            // 
            // lblsem
            // 
            this.lblsem.AutoSize = true;
            this.lblsem.Location = new System.Drawing.Point(52, 110);
            this.lblsem.Name = "lblsem";
            this.lblsem.Size = new System.Drawing.Size(54, 13);
            this.lblsem.TabIndex = 14;
            this.lblsem.Text = "Semester:";
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.Location = new System.Drawing.Point(69, 68);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(35, 13);
            this.lblclass.TabIndex = 13;
            this.lblclass.Text = "Class:";
            // 
            // rdbe
            // 
            this.rdbe.AutoSize = true;
            this.rdbe.Location = new System.Drawing.Point(334, 67);
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
            this.rdte.Location = new System.Drawing.Point(265, 67);
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
            this.rdse.Location = new System.Drawing.Point(197, 67);
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
            this.rdfe.Location = new System.Drawing.Point(135, 67);
            this.rdfe.Name = "rdfe";
            this.rdfe.Size = new System.Drawing.Size(44, 17);
            this.rdfe.TabIndex = 1;
            this.rdfe.TabStop = true;
            this.rdfe.Text = "F.E.";
            this.rdfe.UseVisualStyleBackColor = true;
            // 
            // frmView_Subject
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picBack);
            this.Name = "frmView_Subject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Subject";
            this.Load += new System.EventHandler(this.frmView_Subject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbStaff_Name;
        private System.Windows.Forms.TextBox txtMarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubject_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label teaher;
        private System.Windows.Forms.ComboBox cmbacademicyear;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.ComboBox cmbsem;
        private System.Windows.Forms.Label lblsem;
        private System.Windows.Forms.Label lblclass;
        private System.Windows.Forms.RadioButton rdbe;
        private System.Windows.Forms.RadioButton rdte;
        private System.Windows.Forms.RadioButton rdse;
        private System.Windows.Forms.RadioButton rdfe;
        private System.Windows.Forms.Label lbljj;
        private System.Windows.Forms.ComboBox cmbsrno;
    }
}