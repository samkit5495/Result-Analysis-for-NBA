namespace Result_Analysis_for_NBA
{
    partial class frmReport
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
            this.btnpdf = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmbacademicyear = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnpdf
            // 
            this.btnpdf.Location = new System.Drawing.Point(170, 180);
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(93, 38);
            this.btnpdf.TabIndex = 0;
            this.btnpdf.Text = "Create PDF";
            this.btnpdf.UseVisualStyleBackColor = true;
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // cmbacademicyear
            // 
            this.cmbacademicyear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbacademicyear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbacademicyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbacademicyear.FormattingEnabled = true;
            this.cmbacademicyear.Location = new System.Drawing.Point(155, 114);
            this.cmbacademicyear.Name = "cmbacademicyear";
            this.cmbacademicyear.Size = new System.Drawing.Size(121, 21);
            this.cmbacademicyear.TabIndex = 1;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 318);
            this.Controls.Add(this.cmbacademicyear);
            this.Controls.Add(this.btnpdf);
            this.Name = "frmReport";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnpdf;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cmbacademicyear;
    }
}