namespace Result_Analysis_for_NBA.Settings
{
    partial class frmRegistration_Form
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
            this.btnsubmit = new System.Windows.Forms.Button();
            this.btnreset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdStaff = new System.Windows.Forms.RadioButton();
            this.rdAdmin = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.combosecurity = new System.Windows.Forms.ComboBox();
            this.txtanswer = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lblanswer = new System.Windows.Forms.Label();
            this.lblsecurity = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtconfirmpass = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblmobileno = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblconfirmpassword = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(60, 397);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 37);
            this.btnsubmit.TabIndex = 0;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(251, 397);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(75, 37);
            this.btnreset.TabIndex = 11;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdStaff);
            this.panel1.Controls.Add(this.rdAdmin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.combosecurity);
            this.panel1.Controls.Add(this.btnreset);
            this.panel1.Controls.Add(this.btnsubmit);
            this.panel1.Controls.Add(this.txtanswer);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.lblanswer);
            this.panel1.Controls.Add(this.lblsecurity);
            this.panel1.Controls.Add(this.lblusername);
            this.panel1.Controls.Add(this.txtmobile);
            this.panel1.Controls.Add(this.txtemail);
            this.panel1.Controls.Add(this.txtconfirmpass);
            this.panel1.Controls.Add(this.txtpassword);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.lblmobileno);
            this.panel1.Controls.Add(this.lblemail);
            this.panel1.Controls.Add(this.lblconfirmpassword);
            this.panel1.Controls.Add(this.lblpassword);
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Location = new System.Drawing.Point(153, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 447);
            this.panel1.TabIndex = 0;
            // 
            // rdStaff
            // 
            this.rdStaff.AutoSize = true;
            this.rdStaff.Location = new System.Drawing.Point(245, 200);
            this.rdStaff.Name = "rdStaff";
            this.rdStaff.Size = new System.Drawing.Size(47, 17);
            this.rdStaff.TabIndex = 6;
            this.rdStaff.TabStop = true;
            this.rdStaff.Text = "Staff";
            this.rdStaff.UseVisualStyleBackColor = true;
            // 
            // rdAdmin
            // 
            this.rdAdmin.AutoSize = true;
            this.rdAdmin.Location = new System.Drawing.Point(164, 200);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(54, 17);
            this.rdAdmin.TabIndex = 5;
            this.rdAdmin.TabStop = true;
            this.rdAdmin.Text = "Admin";
            this.rdAdmin.UseVisualStyleBackColor = true;
            this.rdAdmin.Validating += new System.ComponentModel.CancelEventHandler(this.rdadmin_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "User Type";
            // 
            // combosecurity
            // 
            this.combosecurity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combosecurity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combosecurity.FormattingEnabled = true;
            this.combosecurity.Items.AddRange(new object[] {
            "What is your nick-name?",
            "Your first mobile no ?",
            "What is your birth place ?"});
            this.combosecurity.Location = new System.Drawing.Point(162, 237);
            this.combosecurity.Name = "combosecurity";
            this.combosecurity.Size = new System.Drawing.Size(191, 21);
            this.combosecurity.TabIndex = 7;
            // 
            // txtanswer
            // 
            this.txtanswer.Location = new System.Drawing.Point(162, 275);
            this.txtanswer.Name = "txtanswer";
            this.txtanswer.Size = new System.Drawing.Size(191, 20);
            this.txtanswer.TabIndex = 8;
            this.txtanswer.Validating += new System.ComponentModel.CancelEventHandler(this.txtanswer_Validating);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(162, 73);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(191, 20);
            this.txtusername.TabIndex = 2;
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            this.txtusername.Validating += new System.ComponentModel.CancelEventHandler(this.txtusername_Validating);
            // 
            // lblanswer
            // 
            this.lblanswer.AutoSize = true;
            this.lblanswer.Location = new System.Drawing.Point(51, 282);
            this.lblanswer.Name = "lblanswer";
            this.lblanswer.Size = new System.Drawing.Size(45, 13);
            this.lblanswer.TabIndex = 18;
            this.lblanswer.Text = "Answer:";
            // 
            // lblsecurity
            // 
            this.lblsecurity.AutoSize = true;
            this.lblsecurity.Location = new System.Drawing.Point(51, 237);
            this.lblsecurity.Name = "lblsecurity";
            this.lblsecurity.Size = new System.Drawing.Size(91, 13);
            this.lblsecurity.TabIndex = 17;
            this.lblsecurity.Text = "Security question:";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(51, 73);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(58, 13);
            this.lblusername.TabIndex = 13;
            this.lblusername.Text = "Username:";
            // 
            // txtmobile
            // 
            this.txtmobile.Location = new System.Drawing.Point(162, 357);
            this.txtmobile.MaxLength = 10;
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(191, 20);
            this.txtmobile.TabIndex = 10;
            this.txtmobile.Enter += new System.EventHandler(this.txtmobile_Enter);
            this.txtmobile.Leave += new System.EventHandler(this.txtmobile_Leave);
            this.txtmobile.Validating += new System.ComponentModel.CancelEventHandler(this.txtmobile_Validating);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(162, 313);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(191, 20);
            this.txtemail.TabIndex = 9;
            this.txtemail.Enter += new System.EventHandler(this.txtemail_Enter);
            this.txtemail.Leave += new System.EventHandler(this.txtemail_Leave);
            this.txtemail.Validating += new System.ComponentModel.CancelEventHandler(this.txtemail_Validating);
            // 
            // txtconfirmpass
            // 
            this.txtconfirmpass.Location = new System.Drawing.Point(162, 163);
            this.txtconfirmpass.Name = "txtconfirmpass";
            this.txtconfirmpass.Size = new System.Drawing.Size(191, 20);
            this.txtconfirmpass.TabIndex = 4;
            this.txtconfirmpass.Enter += new System.EventHandler(this.txtconfirmpass_Enter);
            this.txtconfirmpass.Leave += new System.EventHandler(this.txtconfirmpass_Leave);
            this.txtconfirmpass.Validating += new System.ComponentModel.CancelEventHandler(this.txtconfirmpass_Validating);
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(162, 116);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(191, 20);
            this.txtpassword.TabIndex = 3;
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            this.txtpassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtpassword_Validating);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(162, 28);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(191, 20);
            this.txtname.TabIndex = 1;
            this.txtname.Enter += new System.EventHandler(this.txtname_Enter);
            this.txtname.Leave += new System.EventHandler(this.txtname_Leave);
            this.txtname.Validating += new System.ComponentModel.CancelEventHandler(this.txtname_Validating);
            // 
            // lblmobileno
            // 
            this.lblmobileno.AutoSize = true;
            this.lblmobileno.Location = new System.Drawing.Point(51, 360);
            this.lblmobileno.Name = "lblmobileno";
            this.lblmobileno.Size = new System.Drawing.Size(58, 13);
            this.lblmobileno.TabIndex = 20;
            this.lblmobileno.Text = "Mobile No:";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(51, 314);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(49, 13);
            this.lblemail.TabIndex = 19;
            this.lblemail.Text = "E-mail id:";
            // 
            // lblconfirmpassword
            // 
            this.lblconfirmpassword.AutoSize = true;
            this.lblconfirmpassword.Location = new System.Drawing.Point(51, 163);
            this.lblconfirmpassword.Name = "lblconfirmpassword";
            this.lblconfirmpassword.Size = new System.Drawing.Size(94, 13);
            this.lblconfirmpassword.TabIndex = 15;
            this.lblconfirmpassword.Text = "Confirm Password:";
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Location = new System.Drawing.Point(51, 116);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(56, 13);
            this.lblpassword.TabIndex = 14;
            this.lblpassword.Text = "Password:";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(51, 39);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(38, 13);
            this.lblname.TabIndex = 12;
            this.lblname.Text = "Name:";
            // 
            // picBack
            // 
            this.picBack.Image = global::Result_Analysis_for_NBA.Properties.Resources.back;
            this.picBack.Location = new System.Drawing.Point(12, 12);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(54, 54);
            this.picBack.TabIndex = 46;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // frmRegistration_Form
            // 
            this.AcceptButton = this.btnsubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 521);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmRegistration_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Form";
            this.Load += new System.EventHandler(this.frmRegistration_Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combosecurity;
        private System.Windows.Forms.TextBox txtanswer;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lblanswer;
        private System.Windows.Forms.Label lblsecurity;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox txtmobile;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtconfirmpass;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblmobileno;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblconfirmpassword;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.RadioButton rdStaff;
        private System.Windows.Forms.RadioButton rdAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBack;
    }
}