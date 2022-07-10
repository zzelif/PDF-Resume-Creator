using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace PDF_Resume_Creator
{
    public partial class Form1 : Form
    {
        private readonly string _fileName = @"C:\Users\ASUS\source\repos\PDF Resumer Creator\resume.json";
        public Form1()
        {
            InitializeComponent();
            string jsonFromFile;
            using (var reader = new StreamReader(_fileName))
            {
                jsonFromFile = reader.ReadToEnd();
            }
        }

        public class Resume
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Website { get; set; }
            public string Street { get; set; }
            public string Province { get; set; }
            public string Municipality { get; set; }
            public string PostalCode { get; set; }
            public string Region { get; set; }
            public string College { get; set; }
            public string CollegeGraduated { get; set; }
            public string HighSchool { get; set; }
            public string HighSchoolGraduated { get; set; }
            public string Award { get; set; }
            public string Skill1 { get; set; }
            public string Skill2 { get; set; }
            public string Skill3 { get; set; }
            public string Skill4 { get; set; }
            public string Skill5 { get; set; }

        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string jsonFromFile;
            using (var reader = new StreamReader(_fileName))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            var resumeFromJson = JsonConvert.DeserializeObject<Resume>(jsonFromFile);

            string Firstname = resumeFromJson.FirstName;
            string Lastname = resumeFromJson.LastName;
            string Email = resumeFromJson.Email;
            string Phone = resumeFromJson.Phone;
            string Website = resumeFromJson.Website;

            string Street = resumeFromJson.Street;
            string Province = resumeFromJson.Province;
            string Municipality = resumeFromJson.Municipality;
            string PostalCode = resumeFromJson.PostalCode;
            string Region = resumeFromJson.Region;

            string College = resumeFromJson.College;
            string CollegeGraduated = resumeFromJson.CollegeGraduated;
            string HighSchool = resumeFromJson.HighSchool;
            string HighSchoolGraduated = resumeFromJson.HighSchoolGraduated;

            string Award = resumeFromJson.Award;

            string Skill1 = resumeFromJson.Skill1;
            string Skill2 = resumeFromJson.Skill2;
            string Skill3 = resumeFromJson.Skill3;
            string Skill4 = resumeFromJson.Skill4;
            string Skill5 = resumeFromJson.Skill5;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = @"C:\Users\Public\Documents\Resume";
                saveFileDialog.FileName = Lastname + "" + Firstname + ".pdf";
                saveFileDialog.Filter = "PDF|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = Lastname + "_" + "Resume";
                    PdfPage page = pdf.AddPage();
                    XGraphics graph = XGraphics.FromPdfPage(page); ;
                    XFont bigfont = new XFont("TimesNewRoman", 18, XFontStyle.Regular);
                    XFont smallfont = new XFont("TimesNewRoman", 12, XFontStyle.Regular);
                    XFont titlefont = new XFont("TimesNewRoman", 35, XFontStyle.Regular);
                    XPen pen = new XPen(XColors.White, 20);
                    XPen linerleft = new XPen(XColors.Black, 1); ;
                    XPen linerright = new XPen(XColors.DarkGray, 1);
                    graph.DrawRoundedRectangle(XBrushes.Bisque, 0, 0, page.Width.Point, page.Height.Point, 30, 20);
                    graph.DrawRoundedRectangle(XBrushes.WhiteSmoke, 200, 50, page.Width.Point, page.Height.Point, 100, 100);
                    graph.DrawRectangle(pen, 0, 0, page.Width.Point, page.Height.Point);

                    graph.DrawString(Lastname + "" + Firstname, bigfont, XBrushes.White, new XRect(0, 20, page.Width.Point - 20, page.Height.Point - 50), XStringFormats.TopRight);

                    int marginleft = 25;
                    int initialleft = 200;

                    string png = @"C:\Users\ASUS\Downloads\Dan Gabriel R. Lettac.png";
                    XImage image = XImage.FromFile(png);
                    graph.DrawImage(image, marginleft, 50, 150, 150);

                    graph.DrawString("Basic Info:", bigfont, XBrushes.White, new XRect(marginleft, initialleft + 20, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("First Name: " + Firstname, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 50, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Last Name: " + Lastname, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 65, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Email, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 80, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Website, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 95, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Phone, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 110, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);


                    //Line Separator
                    graph.DrawRectangle(linerleft, marginleft, initialleft + 130, 150, 1);

                    //Address
                    graph.DrawString("Address:", bigfont, XBrushes.White, new XRect(marginleft, initialleft + 135, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Street, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 160, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Province, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 190, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Municipality, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 190, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(PostalCode, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 175, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Region, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 205, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //right side of PDF

                    int marginmiddle = 220;
                    int initialmiddle = 200;

                    //BIG First name and last name
                    graph.DrawString(Firstname, titlefont, XBrushes.Black, new XRect(marginmiddle, initialmiddle - 110, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Lastname, titlefont, XBrushes.Black, new XRect(marginmiddle, initialmiddle - 70, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //Line Separator
                    graph.DrawRectangle(linerright, marginmiddle, initialmiddle - 10, 350, 1);

                    //Education
                    graph.DrawString("Education:", bigfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(College, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 30, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(CollegeGraduated, smallfont, XBrushes.Black, new XRect(marginmiddle + 25, initialmiddle + 45, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(HighSchool, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(HighSchoolGraduated, smallfont, XBrushes.Black, new XRect(marginmiddle + 25, initialmiddle + 75, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //Awards

                    initialmiddle += 100;

                    //Line Separator
                    graph.DrawRectangle(linerright, marginmiddle, initialmiddle - 5, 350, 1);

                    graph.DrawString("Awards:", bigfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 30, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //Skills

                    initialmiddle += 150;
                    //Line Separator
                    graph.DrawRectangle(linerright, marginmiddle, initialmiddle - 5, 350, 1);

                    graph.DrawString("Skills:", bigfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill1, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 30, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill2, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 45, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill3, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill4, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 75, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill5, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 90, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);


                    pdf.Save(saveFileDialog.FileName);

                }
            }
            Application.Restart();
        }
    }
}
