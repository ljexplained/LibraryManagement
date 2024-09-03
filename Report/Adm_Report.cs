using iTextSharp.text.pdf;
using iTextSharp.text;
using Libms.Models;
using OfficeOpenXml.Style;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Libms.Report
{

   
    public class Adm_Report
    {
        private readonly IHostingEnvironment _environment;
        public Adm_Report(IHostingEnvironment environment)
        {
            //_logger = logger;
            _environment = environment;

        }



        #region Declaration
        int _totalColumn = 2;
        Document document;
        Font font;
        PdfPTable table = new PdfPTable(2);
        PdfPCell cell;

        int _totalColumn1 = 8;
        PdfPTable table1 = new PdfPTable(8);
        PdfPCell cell1;

        int _totalColumn2 = 8;
        PdfPTable table2 = new PdfPTable(8);
        PdfPCell cell2;

        int _totalColumn3 = 13;
        PdfPTable table3 = new PdfPTable(13);
        PdfPCell cell3;

        int _totalColumn4 = 5;
        PdfPTable table4 = new PdfPTable(5);
        PdfPCell cell4;

        MemoryStream _memoryStream = new MemoryStream();
        List<My_session> _mysession = new List<My_session>();
        #endregion
        string uname = "";
        string s_level = "";
        string acadyear = "";
        string s_session = "";
        string s_programme = "";
        string s_enroll = "";
        string s_unirno = "";
        string s_admcat = "";
        string s_merit = "";
        string s_name = "";

        string s_father = "";
        string s_gaurdian = "";
        string s_mother = "";
        string s_dob = "";
       


        string s_nation = "";
        string s_gender = "";
        string s_category = "";
        string s_subucat = "";
        string s_address = "";
        string s_town = "";
        string s_tehsil = "";
        string s_post = "";
        string s_thana = "";
        string s_district = "";
        string s_state = "";
        string s_pin = "";
        string s_sport = "";
        string s_spouse = "";
        string s_ncc = "";
        string s_scout = "";
        string s_hostel = "";
        string s_email = "";
        string s_whatsapp = "";



        string twyear = "";
        string twmarksobt = "";
        string twmaxmark = "";
        string twdiv = "";
        string twpercent = "";
        string twgroup = "";
        string twschool = "";
        string twboard = "";



        string tenyear = "";
        string tenmarksobt = "";
        string tenmaxmark = "";
        string tendiv = "";
        string tenpercent = "";
        string tengroup = "";
        string tenschool = "";
        string tenboard = "";



        string ugyear = "";
        string ugmarksobt = "";
        string ugmaxmark = "";
        string ugdiv = "";
        string ugpercent = "";
        string uggroup = "";
        string ugschool = "";
        string ugboard = "";




        string pgyear = "";
        string pgmarksobt = "";
        string pgmaxmark = "";
        string pgdiv = "";
        string pgpercent = "";
        string pggroup = "";
        string pgschool = "";
        string pgboard = "";
        string punish = "";
        int d = 0;
        int m = 0;  
        int y = 0;
        string s_profile = "";
        DateTime dts = DateTime.Now;
        public byte[] PrepareAdmissionReport(string username)
        {
            Console.WriteLine(username);
            uname = username;
           string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
           //string conn = "Data Source=localhost\\sqlexpress;Initial Catalog=db_a9eacf_library;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from regmaster where registrationid = @registrationid";

            SqlCommand command = new SqlCommand(query, connection);
            if (username != null)
            { command.Parameters.AddWithValue("@registrationid", username); } 
            else
            {
                command.Parameters.AddWithValue("@registrationid","");
            }
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                s_level = reader.GetString(1);
                s_programme = reader.GetString(2);
                acadyear = reader.GetString(3);
                s_unirno = reader.GetString(4);
                s_admcat = reader.GetString(5);
                s_merit = reader.GetString(6);
                s_name = reader.GetString(7);

                s_father = reader.GetString(8);
               
                s_gaurdian = reader.GetString(9);
                s_mother = reader.GetString(10);
                s_dob = reader.GetString(11);


                s_nation = reader.GetString(12);
                s_gender = reader.GetString(13);
                s_category = reader.GetString(14);
                s_subucat = reader.GetString(15);
                s_address = reader.GetString(16);

                s_town = reader.GetString(17);
                s_tehsil = reader.GetString(18);
                s_post = reader.GetString(19);
                s_thana = reader.GetString(20);
                s_district = reader.GetString(21);
                s_state = reader.GetString(22);
                s_pin = reader.GetString(23);
                s_sport = reader.GetString(24);
                s_spouse = reader.GetString(25);
                s_ncc = reader.GetString(26);
                s_scout = reader.GetString(27);
                s_hostel = reader.GetString(28);
                s_email = reader.GetString(29);
                s_whatsapp = reader.GetString(30);  


                tenyear = reader.GetString(31); 
                tenmarksobt = reader.GetString(32);
                tenmaxmark = reader.GetString(33);
                tendiv = reader.GetString(34);
                tenpercent = reader.GetString(35);

                tengroup = reader.GetString(36);
                tenschool = reader.GetString(37);
                tenboard = reader.GetString(38);


                twyear = reader.GetString(39);
                twmarksobt = reader.GetString(40);
                twmaxmark = reader.GetString(41);
                twdiv = reader.GetString(42);
                twpercent = reader.GetString(43);

                twgroup = reader.GetString(44);
                twschool = reader.GetString(45);
                twboard = reader.GetString(46);


                ugyear = reader.GetString(47);
                ugmarksobt = reader.GetString(48);
                ugmaxmark = reader.GetString(49);
                ugdiv = reader.GetString(50);
                ugpercent = reader.GetString(51);

                uggroup = reader.GetString(52);
                ugschool = reader.GetString(53);
                ugboard = reader.GetString(54);

                pgyear = reader.GetString(55);
                pgmarksobt = reader.GetString(56);
                pgmaxmark = reader.GetString(57);
                pgdiv = reader.GetString(58);
                pgpercent = reader.GetString(59);

                pggroup = reader.GetString(60);
                pgschool = reader.GetString(61);
                pgboard = reader.GetString(62);
                punish = reader.GetString(63);

                s_profile = reader.GetString(80);
                


               DateTime dt = (DateTime)reader.GetValue(82);
                d = dt.Day;
                m = dt.Month;
                y = dt.Year;
                

            }









            connection.Close();


            #region
            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);



            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table1.WidthPercentage = 100;
            table1.HorizontalAlignment = Element.ALIGN_LEFT;
            table2.WidthPercentage = 100;
            table2.HorizontalAlignment = Element.ALIGN_LEFT;
            table3.WidthPercentage = 100;
            table3.HorizontalAlignment = Element.ALIGN_LEFT;
            table4.WidthPercentage = 100;
            table4.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfWriter.GetInstance(document, _memoryStream);
            document.Open();
            table.SetWidths(new float[] { 80f, 120f});
            table1.SetWidths(new float[] { 100f, 30f,50f,30f, 40f ,50f,60f,60f});
            table2.SetWidths(new float[] { 100f, 30f, 100f, 30f, 100f, 30f, 100f, 30f });
            table3.SetWidths(new float[] {10f,130f, 130f, 200f,30f,40f, 10f, 130f, 130f, 200f, 30f,40f,400f });
            table4.SetWidths(new float[] {500f,40f,500f,40f,400f});
            #endregion
             
            this.ReportHeader();
            this.ReportBody();
            this.ReportBody1();
            this.ReportHeader1();
            this.ReportBody2();
            this.ReportHeader3();
            this.ReportBody3();
            this.ReportHeader4();
            this.ReportBody4();
            this.ReportHeader5();
            this.ReportBody5();
            table.HeaderRows = 1;
            table1.HeaderRows = 1;
            table2.HeaderRows = 1;
            table4.HeaderRows = 1;
            table3.HeaderRows = 1;
            document.Add(table);
            document.Add(table1 );
            document.Add(table2);
            document.Add(table4);
            document.Add(table3);
            document.Close();
            return _memoryStream.ToArray();
        }




        private void ReportHeader()
        {

            font = FontFactory.GetFont("Arial", 25f, 1);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();


        }



        private void ReportBody()
        {

            #region Table header


            //report header




            font = FontFactory.GetFont("Arial", 25f, 1);
            cell = new PdfPCell(new Phrase("DPBS COLLEGE", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();

            font = FontFactory.GetFont("Arial", 9f, 0);
            cell = new PdfPCell(new Phrase("ANUPSHAHAR (Bulandshahar) U.P.-203390", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();

            font = FontFactory.GetFont("Arial", 8f, 0);
            cell = new PdfPCell(new Phrase("[Form for admission to Regular/Self Finance Course]", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();

            font = FontFactory.GetFont("Arial", 8f, 1);
            cell = new PdfPCell(new Phrase("www.dpbspgcollege.edu.in[PHONE No. 7895-05734]", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);
            table.CompleteRow();

            font = FontFactory.GetFont("Arial", 8f, 1);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = 0;
            cell.BackgroundColor = BaseColor.WHITE;
            table.AddCell(cell);

            var filepath = "";

            if (string.IsNullOrEmpty(uname))
            {
                filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\demophoto.png");
            }
            else {

                if(string.IsNullOrEmpty(s_profile))
                {
                    filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\demophoto.png");
                }
                else
                {
                    filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images\\"+s_profile);
                }

               
            }
            if(File.Exists(filepath))
            {
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(filepath);
                jpg.ScaleToFit(100f, 100f);

                font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
                cell = new PdfPCell(jpg);
                cell.Colspan = _totalColumn;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.ExtraParagraphSpace = 5;
                table.AddCell(cell);
                table.CompleteRow();
            }
            else
            {
                filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\demophoto.png");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(filepath);
                jpg.ScaleToFit(100f, 100f);
                font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
                cell = new PdfPCell(jpg);
                cell.Colspan = _totalColumn;
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.ExtraParagraphSpace = 5;
                table.AddCell(cell);
                table.CompleteRow();

            }

            //report header






            font = FontFactory.GetFont("Arial", 11f,1, BaseColor.BLACK);
            cell = new PdfPCell(new Phrase(s_level +", Class : "+s_programme+", Year : "+acadyear+", Session : "+dts.Year, font));
            cell.Colspan = _totalColumn;
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);
            table.CompleteRow();



            font = FontFactory.GetFont("Arial", 13f,4, BaseColor.BLACK);
            cell = new PdfPCell(new Phrase("STUDENT ID : "+ uname, font));
            //cell.Colspan = _totalColumn;
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            font = FontFactory.GetFont("Arial", 11f,BaseColor.BLACK);
            cell = new PdfPCell(new Phrase("Signature", font));
            //cell.Colspan = _totalColumn;
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);


            table.CompleteRow();


            font = FontFactory.GetFont("Arial", 11f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = _totalColumn;
            cell.Border = 0;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = -5;
            table.AddCell(cell);

            table.CompleteRow();

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase("Subjects", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor=BaseColor.GRAY;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            table.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell = new PdfPCell(new Phrase("Major 1.____________________Major 2.____________________Major 3.____________________", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            table.CompleteRow();


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell = new PdfPCell(new Phrase("Minor 1._______________Skill Development 1._______________Co-Curricular 1._______________", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            table.CompleteRow();


            font = FontFactory.GetFont("Arial", 11f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = _totalColumn;
            cell.Border= 0; 
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE; 
            cell.ExtraParagraphSpace = -5;
            table.AddCell(cell);

            table.CompleteRow();






            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE); 
            cell = new PdfPCell(new Phrase("University Information", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.GRAY;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);



            

            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell = new PdfPCell(new Phrase("Registration No/Enrollment No ", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_unirno, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Registration Date", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(d+"/"+m+"/"+y, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Admission Category", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_admcat, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);

            table.CompleteRow();

            #endregion





        }


        private void ReportBody1()
        {

            #region Table header

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Border = 0;    
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = -5;
            table.AddCell(cell);
            table.CompleteRow();


            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell = new PdfPCell(new Phrase("Personal Information", font));
            cell.Colspan = _totalColumn;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.GRAY;
            cell.ExtraParagraphSpace = 5;
            table.AddCell(cell);





            table.CompleteRow();

            #endregion


            #region Table Body
            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell = new PdfPCell(new Phrase("Name Of Student", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_name, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Father's Name", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_father, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Mother's Name", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_mother, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Gaurdian's Name", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_gaurdian, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Date of Birth", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            Console.WriteLine(s_dob);
            cell = new PdfPCell(new Phrase(s_dob, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Nationality", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_nation, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Gender", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_gender, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("Category", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_category, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();




            cell = new PdfPCell(new Phrase("Sub Category", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_subucat, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Permanent Address", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_address+" "+s_town + " " + s_tehsil + " " + s_post + " " + s_thana + " " + s_district + " " + s_state + " " + s_pin, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Participated in Sports", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_sport, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Spouse/Son/Doughter of Permananent employee of CCS"+"\n"+"University Or its affilated Colleges", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_spouse, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("NCC", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_ncc, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Scouts/Guides", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_scout, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();



            cell = new PdfPCell(new Phrase("Hostel Required", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_hostel, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();

            cell = new PdfPCell(new Phrase("Email Id", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_email, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            cell = new PdfPCell(new Phrase("WhatsApp No", font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.BorderWidthBottom = 1; 
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);


            cell = new PdfPCell(new Phrase(s_whatsapp, font));
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.BackgroundColor = BaseColor.WHITE;
            cell.BorderWidthBottom = 1;
            cell.ExtraParagraphSpace = 4;
            table.AddCell(cell);

            table.CompleteRow();


            #endregion





        }



        private void ReportHeader1()
        {

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.Colspan = _totalColumn1;
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.Border = 0;
            cell1.ExtraParagraphSpace = -5;
            table1.AddCell(cell1);
            table1.CompleteRow();


        }


        private void ReportBody2()
        {


            #region Table1 header
            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.Colspan = _totalColumn1;
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.Border = 0;
            cell1.ExtraParagraphSpace = -100;
            table1.AddCell(cell1);
            table1.CompleteRow();

            #endregion


            #region Table1 Body

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);

            cell1 = new PdfPCell(new Phrase("Acadmic Information ", font));
            cell1.Colspan = _totalColumn1; 
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.GRAY;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);
            table1.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("Examination Passed", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("Year", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("Marks Obtained/"+"\n"+"Max Marks", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("DIV", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("%", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("Group", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("School/"+"\n"+"College", font));           
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            cell1 = new PdfPCell(new Phrase("Board/"+"\n"+"University", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();





            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("10th", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(tenyear, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(tenmarksobt, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(tendiv, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(tenpercent, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(tengroup, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(tenschool, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

           font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase(tenboard, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("12th", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twyear, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twmarksobt, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twdiv, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twpercent, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twgroup, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twschool, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(twboard, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("BA/BSc/BCom/BCA/BEd", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(ugyear, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(ugmarksobt, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(ugdiv, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(ugpercent, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(uggroup, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(ugschool, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase(ugboard, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("MA/MSc/MCom", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pgyear, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pgmarksobt, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pgdiv, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pgpercent, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pggroup, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pgschool, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(pgboard, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();




            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("Others", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);


            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();





            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = -5;
            table1.AddCell(cell1);

            table1.CompleteRow();


            cell1 = new PdfPCell(new Phrase("Whether you were punished for any offence / Unfair means committed by you in the previously attended or the present Institution. If yes, give details................", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 10;
            table1.AddCell(cell1);

            table1.CompleteRow();

            cell1 = new PdfPCell(new Phrase(punish, font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.BorderWidthRight = 0;
            cell1.BorderWidthTop = 0;
            cell1.BorderWidthLeft = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 2;
            table1.AddCell(cell1);

            table1.CompleteRow();


            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan =6;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 10;
            table1.AddCell(cell1);


            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan=2;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 10;
            table1.AddCell(cell1);

            table1.CompleteRow();



            //note section starts from here

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell1 = new PdfPCell(new Phrase("UNDERTAKINGS ", font));
            cell1.Colspan = _totalColumn1;
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.BackgroundColor = BaseColor.GRAY;
            cell1.ExtraParagraphSpace =5;
            table1.AddCell(cell1);
            table1.CompleteRow();

            cell1 = new PdfPCell(new Phrase(" ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace= -15;   
            table1.AddCell(cell1);

            table1.CompleteRow();

            font = FontFactory.GetFont("Arial",10f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase("• I shall always obey in letter and spirit the rules and regulations formulated by the University and the College and "+ "\n  shall be personally responsible for obeying the same.", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);

            table1.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase("• That I shall not indulge in any activity that comes under indiscipline or shall be involved in any action that has"+"\n   been declared against the conduct rules.", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);

            table1.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase("• That at no stage I shall be involved in ragging and shall also cooperate in reporting any such matter to authorities "+"\n   if I come to know about this.", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);

            table1.CompleteRow();

            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase("• That I shall ensure that I am regular and punctual in my classes and attempt to complete 100% attendance but not "+"\n   less than 75% under any circumstance.", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);

            table1.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase("• That I am at present not a student of any other College/University and shall not be appearing at "+"\n   any other examination leading to a degree. ", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);

            table1.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell1 = new PdfPCell(new Phrase("I have read the above points carefully and shall be responsible for following them. I hereby declare that the "+"\ninformation given in this application form is true to best of my knowledge and belief. In case any information is "+"\nfound untrue, the University/College can cancel my Admission, for that no claim for refund of fee would be raised by "+"\nminor challenge in any court of law.", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan = _totalColumn1;
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 5;
            table1.AddCell(cell1);

            table1.CompleteRow();

            //note section ends here 



            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);


            cell1 = new PdfPCell(new Phrase(" ",font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Border = 0;
            cell1.Colspan= _totalColumn1;   
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 6;
            table1.AddCell(cell1);

            table1.CompleteRow();




            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);


            cell1 = new PdfPCell(new Phrase("______________________"+"\nSignature Of Parent"+"\nDate:", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Colspan =6;  
            cell1.Border = 0;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 6;
            table1.AddCell(cell1);



           




            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);

            cell1 = new PdfPCell(new Phrase("______________________" + "\nSignature Of Student" + "\nDate:", font));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell1.Border = 0;
            cell1.Colspan = 2;
            cell1.BackgroundColor = BaseColor.WHITE;
            cell1.ExtraParagraphSpace = 6;
            table1.AddCell(cell1);

            table1.CompleteRow();

            #endregion

        }



        private void ReportHeader3()
        {
            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell2 = new PdfPCell(new Phrase("", font));
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.Border = 0;
            cell2.ExtraParagraphSpace = 5;
            table2.AddCell(cell2);
            table2.CompleteRow();

        }

        private void ReportBody3()
        {
            #region Table2 header
            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell2 = new PdfPCell(new Phrase("", font));
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            table2.AddCell(cell2);
            table2.CompleteRow();
            #endregion

            #region Table2 body

            font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            cell2 = new PdfPCell(new Phrase("Document Checklist", font));
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.GRAY;
            cell2.ExtraParagraphSpace = 5;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("1. University Reg. Form", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            var filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\square.png");
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(filepath);
            jpg.ScaleToFit(11f,11f);
            jpg.SpacingBefore = 5;

            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);


            




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("2. Offer Letter", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("3. 10th Marksheet ", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);





            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("4. 10th Certificate", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);

            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("5. 12th Marksheet", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("6. 12th Certificate", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);





            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("7. UG/PG Marksheet", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("8. Migration", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);


            table2.CompleteRow();






            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("9. T.C ", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);


            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);







            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("10. Character Certificate ", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("11. Caste Certificate", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);





            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("12. Aadhaar Card", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);

            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("13. Domicile Certificate", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("14. Weightage Certificate\r\n(if any)\r\n", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);





            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("15. Bank Pass Book", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("16. Admit Card", font));
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            cell2 = new PdfPCell(jpg);
            cell2.Border = 0;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_CENTER;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);


            table2.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("              Note:", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("                      •  No other person is allowed to sign on behalf of the applicant.", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("                      •  The applicant is required to enclose self-attested photocopies of every relevant "+"\n                         information related to academic record, age, reserved category, weightage(s) etc.", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 10;
            table2.AddCell(cell2);
            table2.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f, 1,BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               For Office Use Only", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 5;
            table2.AddCell(cell2);
            table2.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f,BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               Fee Receipt No. ____________________ Date _________________ ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = 6;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("                                 ______________________"+"\n                                  Signature Of Clerk", font));
            cell2.Border = 0;
            cell2.Colspan = 2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 11f, 1, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               For Admission Committee:", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 5;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               Merit _______________   Category __________________ Weightage ___________________", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 10;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               Remark if any: _______________________________________________________________", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 10;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               ___________________________________________________________________________", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 10;
            table2.AddCell(cell2);
            table2.CompleteRow();

            font = FontFactory.GetFont("Arial", 11f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("               ___________________________________________________________________________", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 25;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("                    ______________________"+ "\n                    Signature Of Principal", font));
            cell2.Border = 0;
            cell2.Colspan = 3;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);


            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("    ______________________" + "\n    Signature Of Admission In-charge", font));
            cell2.Border = 0;
            cell2.Colspan =3;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);



            font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase("    ______________________" + "\n    Signature Of Checker", font));
            cell2.Border = 0;
            cell2.Colspan = 3;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);


            table2.CompleteRow();








            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();





            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();






            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();




            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();





            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();






            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();


            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();



            font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            cell2 = new PdfPCell(new Phrase(" ", font));
            cell2.Border = 0;
            cell2.Colspan = _totalColumn2;
            cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            cell2.BackgroundColor = BaseColor.WHITE;
            cell2.ExtraParagraphSpace = 3;
            table2.AddCell(cell2);
            table2.CompleteRow();




            //font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            //cell2 = new PdfPCell(new Phrase(" ", font));
            //cell2.Border = 0;
            //cell2.Colspan = _totalColumn2;
            //cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell2.BackgroundColor = BaseColor.WHITE;
            //cell2.ExtraParagraphSpace = 3;
            //table2.AddCell(cell2);
            //table2.CompleteRow();



            //font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
            //cell2 = new PdfPCell(new Phrase(" ", font));
            //cell2.Border = 0;
            //cell2.Colspan = _totalColumn2;
            //cell2.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell2.BackgroundColor = BaseColor.WHITE;
            //cell2.ExtraParagraphSpace = 3;
            //table2.AddCell(cell2);
            //table2.CompleteRow();




            #endregion
        }







        private void ReportHeader4()
        {
            //font = FontFactory.GetFont("Arial", 16f, BaseColor.WHITE);
            //cell4 = new PdfPCell(new Phrase(" ", font));
            //cell4.Colspan = 5;
            //cell4.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell4.BackgroundColor = BaseColor.WHITE;
            //cell4.Border = 0;
            //cell4.ExtraParagraphSpace = 5;
            //table4.AddCell(cell4);
            //table4.CompleteRow();
        }

        private void ReportBody4()
        {

            //if (s_programme != "BA(Aided)" && s_programme != "Bsc" && s_programme != "MA(Sanskrit)" && s_programme != "MSc(Physics)")
            //{

                #region Table4 header

                #endregion


                #region Table4 body



                font = FontFactory.GetFont("Arial", 9f, BaseColor.RED);
                cell4 = new PdfPCell(new Phrase("College's Copy", font));
                cell4.BorderWidthBottom = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLUE);
                cell4 = new PdfPCell(new Phrase("Students's Copy", font));
                cell4.BorderWidthBottom = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.MAGENTA);
                cell4 = new PdfPCell(new Phrase("Bank's Copy", font));
                cell4.BorderWidthBottom = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("HDFC Bank Limited", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("HDFC Bank Limited", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("HDFC Bank Limited", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("DPBS PG College, Anupshahar", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("DPBS PG College, Anupshahar", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("DPBS PG College, Anupshahar", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Fee payment (Admission)", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Fee payment (Admission)", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Fee payment (Admission)", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                //echallan



                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Challan No : " + "C" + uname, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Challan No : " + "C" + uname, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Challan No : " + "C" + uname, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);


                table4.CompleteRow();

                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Form/Reg/Enroll. No : " + s_unirno, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Form/Reg/Enroll. No : " + s_unirno, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Form/Reg/Enroll. No : " + s_unirno, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 10;
                table4.AddCell(cell4);

                table4.CompleteRow();



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Name of Student : " + s_name, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Name of Student : " + s_name, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Name of Student : " + s_name, font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();





                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Course:", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Course:", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Course:", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);




                table4.CompleteRow();





                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Session:           2024-25", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Session:", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Session:", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);




                table4.CompleteRow();






                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Head        Amount        Credit to\n\n" + "Fee                                50100526580318\n\n" + "Other\n", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Head        Amount        Credit to\n\n" + "Fee                               50100526580318\n\n" + "Other\n", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 7f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Head        Amount        Credit to\n\n" + "Fee                                50100526580318\n\n" + "Other\n", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);




                table4.CompleteRow();







                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Amount in words______________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Amount in words______________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Amount in words_______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("____________________________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();







                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("2000X:  _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();







                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("500X:    _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();





                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("200X:    _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();





                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("100X:    _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();

                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" 50X:     _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" 20X:     _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" 10X:     _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" 5X:       _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("COINS:    _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" TOTAL:    _______________", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 2;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();







                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("            Signature of Students/Remitter", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("            Signature of Students/Remitter", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);








                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, 1, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("    Signature of Students/Remitter", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();




                font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("            For Receiving Branch use only", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("            For Receiving Branch use only", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("    For Receiving Branch use only", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                //cell4.ExtraParagraphSpace = 5;
                table4.AddCell(cell4);

                table4.CompleteRow();






                font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("      Date        Journal Number", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("      Date        Journal Number", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("      Date        Journal Number", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);

                table4.CompleteRow();







                font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Seal/Date               Authorized Signatory", font));

                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 10f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Seal/Date               Authorized Signatory", font));

                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);



                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase(" ", font));
                cell4.BorderWidthBottom = 0;
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_LEFT;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);


                font = FontFactory.GetFont("Arial", 9f, BaseColor.BLACK);
                cell4 = new PdfPCell(new Phrase("Seal/Date      Authorized Signatory", font));
                cell4.BorderWidthTop = 0;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                cell4.BackgroundColor = BaseColor.WHITE;
                cell4.ExtraParagraphSpace = 20;
                table4.AddCell(cell4);

                table4.CompleteRow();

                #endregion
            //}
        }


        private void ReportHeader5()
        {
           
        }

        private void ReportBody5()
        {

            #region Table3 body
        

            #endregion



        }



    }

}
