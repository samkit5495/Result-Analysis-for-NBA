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
using iTextSharp.text;
using System.Reflection;
using iTextSharp.text.pdf;
using System.IO;

namespace Result_Analysis_for_NBA
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        
       private string pre_academic_year(String academicyear)
        {
            string y1="";
            int i = 0;
            while(academicyear[i]!='-')
            {
                y1+= academicyear[i++];
            }
            i++;
            string y2 = "";
            while (academicyear[i]!='.')
            {
                y2 += academicyear[i++];
            }
            y1 = (Convert.ToInt32(y1) - 1).ToString();
            y2 = (Convert.ToInt32(y2) - 1).ToString();
            return y1+"-"+y2;
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            if (cmbacademicyear.Text.Trim() == "")
            {
                MessageBox.Show("Select Acadamic Year!!!");
                return;
            }
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Students> put;
            MongoCursor<Marks> put1;
            bool f;
            string academicyear=cmbacademicyear.Text.Trim();
            string[] yr = new string[4];
            long[] n1 = new long[4];
            long[] n2 = new long[4];
            long[] withb1 = { 0, 0, 0, 0 }, withoutb1 = { 0, 0, 0, 0 };
            long[] withb2 = { 0, 0, 0, 0 }, withoutb2 = { 0, 0, 0, 0 };
            long[] withb3 = { 0, 0, 0, 0 }, withoutb3 = { 0, 0, 0, 0 };
            long[] withb4 = { 0, 0, 0, 0 }, withoutb4 = { 0, 0, 0, 0 };
            long[] withoutb = { 0, 0, 0, 0 };
            for (int a = 0; a < 4; a++)
            {
                yr[a] = academicyear;
                put = db.GetCollection<Students>("Students").Find(Query.And(Query.EQ("academicyear", academicyear), Query.EQ("ad_type", "F.E."), Query.EQ("migration", "No")));
                
                n1[a] = put.Count();
                put = db.GetCollection<Students>("Students").Find(Query.And(Query.EQ("academicyear", academicyear), Query.EQ("ad_type", "D.S.E.")));
                n2[a] = put.Count();
                put = db.GetCollection<Students>("Students").Find(Query.EQ("academicyear", academicyear));
                foreach (Students i in put)
                {
                    f = false;
                    put1 = db.GetCollection<Marks>("fe_marks").Find(Query.EQ("prn", i.prn));
                    foreach (Marks j in put1)
                    {
                        if (j.sem1_grade == "A.T.K.T." || j.sem2_grade == "A.T.K.T.")
                        {
                            withb1[a]++;
                            f = true;
                        }
                        else if (j.sem1_grade != "Fail" || j.sem2_grade != "Fail")
                        {
                            withoutb1[a]++;
                        }
                    }
                    put1 = db.GetCollection<Marks>("se_marks").Find(Query.EQ("prn", i.prn));
                    foreach (Marks j in put1)
                    {
                        if (j.sem1_grade == "A.T.K.T." || j.sem2_grade == "A.T.K.T.")
                        {
                            withb2[a]++;
                            f = true;
                        }
                        else if(j.sem1_grade != "Fail"|| j.sem2_grade != "Fail")
                        {
                            withoutb2[a]++;
                        }
                    }
                    put1 = db.GetCollection<Marks>("te_marks").Find(Query.EQ("prn", i.prn));
                    foreach (Marks j in put1)
                    {
                        if (j.sem1_grade == "A.T.K.T." || j.sem2_grade == "A.T.K.T.")
                        {
                            withb3[a]++;
                            f = true;
                        }
                        else if (j.sem1_grade != "Fail" || j.sem2_grade != "Fail")
                        {
                            withoutb3[a]++;
                        }
                    }
                    put1 = db.GetCollection<Marks>("be_marks").Find(Query.EQ("prn", i.prn));
                    foreach (Marks j in put1)
                    {
                        if (j.sem1_grade == "A.T.K.T." || j.sem2_grade == "A.T.K.T.")
                        {
                            withb4[a]++;
                            f = true;
                        }
                        else if (j.sem1_grade != "Fail" || j.sem2_grade != "Fail")
                        {
                            withoutb4[a]++;
                        }
                    }
                    if (!f)
                        withoutb[a]++;
                }
                academicyear = pre_academic_year(academicyear + ".");
            }






            string path;
            f=true;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
                string[] files = Directory.GetFiles(path);
                foreach (string i in files)
                {
                    if (i == path+"\\Report.pdf")
                        if (DialogResult.No == MessageBox.Show("Replace Existing File ?", "", MessageBoxButtons.YesNo))
                            f = false;
                }
                if (f)
                {
                    Document doc = new Document(PageSize.A4);
                    try
                    {
                        PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream((path + "\\Report.pdf"), FileMode.Create));
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Close Opened Report PDF file!");
                    }
                    doc.Open();
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("NBA_logo.png");
                    img.ScaleToFit(100f, 500f);
                    img.Border = iTextSharp.text.Rectangle.BOX;
                    img.BorderColor = iTextSharp.text.BaseColor.BLACK;
                    img.BorderWidth = 5f;
                    doc.Add(img);

                    PdfPTable table = new PdfPTable(5);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.WidthPercentage = 90;

                    Phrase p1 = new Phrase("Students’ Performance (150) (150)");
                    doc.Add(p1);



                    table.AddCell("Item");
                    table.AddCell("CAY("+yr[0]+")");
                    for(int i=1;i<4;i++)
                        table.AddCell("CAYm"+i+"("+yr[i]+")");

                    table.AddCell("Sanctioned intake strength of the programme (N)");
                    table.AddCell("59");
                    table.AddCell("57");
                    table.AddCell("61");
                    table.AddCell("64");

                    table.AddCell("students admitted in first year minus number of students migrated to other programmes at the end of 1st year (N1)");
                    for(int i=0;i<4;i++)
                        table.AddCell(n1[i].ToString());
                    
                    table.AddCell("Number of students admitted in 2nd year in the same batch via lateral entry (N2)");
                    for (int i = 0; i < 4; i++)
                        table.AddCell(n2[i].ToString());

                    table.AddCell("Total number of students admitted in the Programme (N1+N2)");
                    for (int i = 0; i < 4; i++)
                        table.AddCell((n1[i]+n2[i]).ToString());

                    doc.Add(table);

                    PdfPTable table2 = new PdfPTable(6);
                    table2.HorizontalAlignment = Element.ALIGN_LEFT;
                    table2.WidthPercentage = 100;
                    table2.SpacingBefore = 50;
                    PdfPCell cell1 = new PdfPCell(new Phrase("Year of entry(in reverse Chronological order"));
                    cell1.Rowspan = 2;
                    table2.AddCell(cell1);
                    PdfPCell cell2 = new PdfPCell(new Phrase("Number of students admitted in 1st year+ admitted via lateral entry in 2nd year (N1+N2)"));
                    cell2.Rowspan = 2;
                    table2.AddCell(cell2);
                    PdfPCell cell3 = new PdfPCell(new Phrase("Number of students who have successfully graduated*"));
                    cell3.Colspan = 4;
                    table2.AddCell(cell3);

                    table2.AddCell("I year");
                    table2.AddCell("II year");
                    table2.AddCell("III year");
                    table2.AddCell("IV year");

                    table2.AddCell("CAY");
                    table2.AddCell((n1[0] + n2[0]).ToString());
                    table2.AddCell((withb1[0] + withoutb1[0]).ToString());
                    table2.AddCell((withb2[0] + withoutb2[0]).ToString());
                    table2.AddCell((withb3[0] + withoutb3[0]).ToString());
                    table2.AddCell((withb4[0] + withoutb4[0]).ToString());

                    for (int i = 1; i < 4; i++)
                    {
                        table2.AddCell("CAYm"+i);
                        table2.AddCell((n1[i] + n2[i]).ToString());
                        table2.AddCell((withb1[i] + withoutb1[i]).ToString());
                        table2.AddCell((withb2[i] + withoutb2[i]).ToString());
                        table2.AddCell((withb3[i] + withoutb3[i]).ToString());
                        table2.AddCell((withb4[i] + withoutb4[i]).ToString());
                    }

                   /* table2.AddCell("CAYm4 (LYG)");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");

                    table2.AddCell("CAYm5 (LYGm1)");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");



                    table2.AddCell("CAYm6 (LYGm2)");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    table2.AddCell("");
                    */

                    doc.Add(table2);

                    doc.Add(new Paragraph("*successfully completed implies zero backlogs"));


                    doc.NewPage();
                    doc.Add(new Phrase("\n\n\n\n\n\n"));
                    PdfPTable table3 = new PdfPTable(6);
                    table3.HorizontalAlignment = Element.ALIGN_LEFT;
                    table3.WidthPercentage = 100;
                    table3.SpacingBefore = 50;
                    PdfPCell cell4 = new PdfPCell(new Phrase("Year of entry(in reverse Chronological order"));
                    cell4.Rowspan = 2;
                    table3.AddCell(cell4);
                    PdfPCell cell5 = new PdfPCell(new Phrase("Number of students admitted in 1st year+ admitted via lateral entry in 2nd year(N1+N2)"));
                    cell5.Rowspan = 2;
                    table3.AddCell(cell5);
                    PdfPCell cell6 = new PdfPCell(new Phrase("Number of students who have successfully graduated without backlogs in any year of study*"));
                    cell6.Colspan = 4;
                    table3.AddCell(cell6);

                    table3.AddCell("I year");
                    table3.AddCell("II year");
                    table3.AddCell("III year");
                    table3.AddCell("IV year");

                    table3.AddCell("CAY");
                    table3.AddCell((n1[0] + n2[0]).ToString());
                    table3.AddCell((withoutb1[0]).ToString());
                    table3.AddCell((withoutb2[0]).ToString());
                    table3.AddCell((withoutb3[0]).ToString());
                    table3.AddCell((withoutb4[0]).ToString());

                    for (int i = 1; i < 4; i++)
                    {
                        table3.AddCell("CAYm" + i);
                        table3.AddCell((n1[i] + n2[i]).ToString());
                        table3.AddCell((withoutb1[i]).ToString());
                        table3.AddCell((withoutb2[i]).ToString());
                        table3.AddCell((withoutb3[i]).ToString());
                        table3.AddCell((withoutb4[i]).ToString());
                    }
                    /*
                    table3.AddCell("CAYm4 (LYG)");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");


                    table3.AddCell("CAYm5 (LYGm1)");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");


                    table3.AddCell("CAYm6 (LYGm2)");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");
                    table3.AddCell("");*/
                    doc.Add(table3);
                    /*
                    doc.Add(new Phrase("* successfully completed implies zero backlogs", FontFactory.GetFont("bookman old style", 14, BaseColor.RED)));

                    doc.Add(new Phrase("\n 4.1. Success Rate in the stipulated period of the programme (50)(50)\n 4.1.1. Success rate without backlogs in any year of study (25) (25)", FontFactory.GetFont("bookman old style", 12)));
                    doc.Add(new Phrase("\n SI= (Number of students who graduated from the programme without backlog)/\n (Number of students admitted in the first year of that batch and admitted in 2nd year via lateral entry) \n \n Average SI = Mean of success index (SI) for past three batches \n Success rate without backlogs in any year of study = 20 × Average SI"));

                    doc.NewPage();
                    doc.Add(new Phrase("\n\n\n\n\n\n"));
                    PdfPTable table4 = new PdfPTable(4);
                    table4.HorizontalAlignment = Element.ALIGN_LEFT;
                    table4.WidthPercentage = 100;
                    table4.SpacingBefore = 50;
                    table4.AddCell("Item");
                    table4.AddCell("Latest Year of Graduation, LYG (CAYm4)(" + yr[1] + ")");
                    table4.AddCell("Latest Year of Graduation minus 1,LYGm1 (CAYm5) (" + yr[2] + ")");
                    table4.AddCell("Latest Year of Graduation minus 2,LYGm2(CAYm6) (" + yr[3] + ")");

                    table4.AddCell("Number of students admitted in the corresponding First Year + admitted via lateral entry in 2nd year");
                    table4.AddCell("");
                    table4.AddCell("");
                    table4.AddCell("");

                    table4.AddCell("Number of students who have graduated without backlogs in the stipulated period");
                    table4.AddCell("");
                    table4.AddCell("");
                    table4.AddCell("");

                    table4.AddCell("Success index (SI)");
                    table4.AddCell("");
                    table4.AddCell("");
                    table4.AddCell("");
                    doc.Add(table4);

                    doc.NewPage();
                    doc.Add(new Phrase("4.1.2. Success rate in stipulated period (25)(25)", FontFactory.GetFont("bookman old style", 14)));
                    doc.Add(new Phrase("SI= (Number of students who graduated from the programme in the stipulated period of course duration)/ \n (Number of students admitted in the first year of that batch and admitted in 2nd year via lateral entry) \n Average SI = mean of success index (SI) for past three batches \n Success rate = 30 × Average SI"));
                    PdfPTable table5 = new PdfPTable(4);
                    table5.HorizontalAlignment = Element.ALIGN_LEFT;
                    table5.WidthPercentage = 100;

                    table5.AddCell("Item");
                    table5.AddCell("Latest Year of Graduation, LYG(CAYm4)");
                    table5.AddCell("Latest Year of Graduation minus 1,LYGm1(CAYm5)");
                    table5.AddCell("Latest Year of Graduation minus 2,LYGm2(CAYm6)");

                    table5.AddCell("Number of students admitted in the corresponding First Year + admitted via lateral entry in 2nd year");
                    table5.AddCell("");
                    table5.AddCell("");
                    table5.AddCell("");

                    table5.AddCell("Number of students who have graduated in the stipulated period");
                    table5.AddCell("");
                    table5.AddCell("");
                    table5.AddCell("");

                    table5.AddCell("Success index (SI)");
                    table5.AddCell("");
                    table5.AddCell("");
                    table5.AddCell("");
                    doc.Add(table5);



                    doc.Add(new Phrase("\n \n 4.2. Academic Performance in Fourth Year (10) (10)", FontFactory.GetFont("bookman old style", 12)));
                    doc.Add(new Phrase("Academic Performance Level = ((Mean of 4h Year Grade Point Average of all successful Students on a 10 point scale) or \n (Mean of the percentage of marks of all successful students in Fourth Year/10)) x (successful students/number of students appeared in the examination) Successful students are those who passed in all the final year courses"));

                    PdfPTable table6 = new PdfPTable(2);
                    table6.HorizontalAlignment = Element.ALIGN_LEFT;
                    table6.WidthPercentage = 100;
                    //table6.SpacingBefore = 50;
                    table6.AddCell("Academic Performance Level");
                    table6.AddCell("LYG(CAYm4) – IV Year No. of Students");

                    table6.AddCell("9-10");
                    table6.AddCell("0");

                    table6.AddCell("8-9");
                    table6.AddCell("");

                    table6.AddCell("7-8");
                    table6.AddCell("");

                    table6.AddCell("6-7");
                    table6.AddCell("");

                    table6.AddCell("5-6");
                    table6.AddCell("");

                    table6.AddCell("OTotal");
                    table6.AddCell("");

                    PdfPCell cell7 = new PdfPCell(new Phrase("Approximating API by Mid-CGPA"));
                    cell7.HorizontalAlignment = 1;
                    cell7.Colspan = 2;
                    table6.AddCell(cell7);

                    table6.AddCell("Mean of CGPA/Percentage of all the students (API)");
                    table6.AddCell("");


                    table6.AddCell("Total no. of successful students");
                    table6.AddCell("");


                    table6.AddCell("Total no. of students appeared in the examination");
                    table6.AddCell("");

                    PdfPCell cel11 = new PdfPCell(new Phrase("Assessment", FontFactory.GetFont("bookman old style", 12, BaseColor.RED)));
                    table6.AddCell(cel11);
                    table6.AddCell("");
                    doc.Add(table6);

                    // table7


                    PdfPTable table7 = new PdfPTable(2);
                    table7.HorizontalAlignment = Element.ALIGN_LEFT;
                    table7.WidthPercentage = 100;
                    //table7.SpacingBefore = 50;
                    doc.NewPage();
                    doc.Add(new Phrase("\n \n 4.3. Academic Performance in Third Year (20)(20)", FontFactory.GetFont("bookman old style", 12)));
                    doc.Add(new Phrase("Academic Performance Level = 2 * ((Mean of 3rd Year Grade Point Average of all successful Students on a 10 point scale) or (Mean of the percentage of marks of all successful students inThird Year/ 10)) x (successful students/number of students appeared in the examination)Successful students are those who are permitted to proceed to the final year"));
                    table7.AddCell("Academic Performance Level");
                    table7.AddCell("LYG(CAYm4) – IV Year No. of Students");

                    table7.AddCell("9-10");
                    table7.AddCell("0");

                    table7.AddCell("8-9");
                    table7.AddCell("");

                    table7.AddCell("7-8");
                    table7.AddCell("");

                    table7.AddCell("6-7");
                    table7.AddCell("");

                    table7.AddCell("5-6");
                    table7.AddCell("");

                    table7.AddCell("OTotal");
                    table7.AddCell("");

                    PdfPCell cell8 = new PdfPCell(new Phrase("Approximating API by Mid-CGPA"));
                    cell8.HorizontalAlignment = 1;
                    cell8.Colspan = 2;
                    table7.AddCell(cell8);

                    table7.AddCell("Mean of CGPA/Percentage of all the students (API)");
                    table7.AddCell("");


                    table7.AddCell("Total no. of successful students");
                    table7.AddCell("");


                    table7.AddCell("Total no. of students appeared in the examination");
                    table7.AddCell("");

                    doc.Add(table7);


                    //table 8


                    PdfPTable table8 = new PdfPTable(2);
                    table8.HorizontalAlignment = Element.ALIGN_LEFT;
                    table8.WidthPercentage = 100;
                    //table8.SpacingBefore = 50;
                    doc.Add(new Phrase("\n \n 4.4. Academic Performance in Second Year (20)(20)", FontFactory.GetFont("bookman old style", 12)));
                    doc.Add(new Phrase("Academic Performance Level = 2 * ((Mean of 2nd Year Grade Point Average of all successful Students on a 10 point scale) or (Mean of the percentage of marks of all successful students in Second Year / 10)) x (successful students/number of students appeared in the examination)Successful students are those who are permitted to proceed to the third year"));
                    table8.AddCell("Academic Performance Level");
                    table8.AddCell("LYG(CAYm4) – IV Year No. of Students");

                    table8.AddCell("9-10");
                    table8.AddCell("0");

                    table8.AddCell("8-9");
                    table8.AddCell("");

                    table8.AddCell("7-8");
                    table8.AddCell("");

                    table8.AddCell("6-7");
                    table8.AddCell("");

                    table8.AddCell("5-6");
                    table8.AddCell("");

                    table8.AddCell("OTotal");
                    table8.AddCell("");

                    PdfPCell cell9 = new PdfPCell(new Phrase("Approximating API by Mid-CGPA"));
                    cell9.HorizontalAlignment = 1;
                    cell9.Colspan = 2;
                    table8.AddCell(cell9);

                    table8.AddCell("Mean of CGPA/Percentage of all the students (API)");
                    table8.AddCell("");


                    table8.AddCell("Total no. of successful students");
                    table8.AddCell("");


                    table8.AddCell("Total no. of students appeared in the examination");
                    table8.AddCell("");

                    doc.Add(table8);*/
                    doc.Close();

                    System.Diagnostics.Process.Start(path + "\\Report.pdf");
                }
            }
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost");
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("NBA");
            MongoCursor<Students> put = db.GetCollection<Students>("Students").FindAll();
            foreach (Students i in put)
            {
                if (!cmbacademicyear.Items.Contains(i.academicyear))
                    cmbacademicyear.Items.Add(i.academicyear);
            }
        }
    }
}
