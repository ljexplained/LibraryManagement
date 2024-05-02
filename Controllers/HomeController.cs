using iTextSharp.xmp.impl;
using Libms.Models;
using Libms.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Org.BouncyCastle.Asn1.Microsoft;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Xml.Linq;

 
namespace Libms.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //string conn = "Data Source=desktop-6lqd0uj\\sqlexpress;Integrated Security=True";
        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult UploadBooks()
        {
            return View();  
        }



      

        [HttpPost]
        public async Task<IActionResult> UploadBooks(IFormFile file)
        {

            using (var stream = new MemoryStream())
            {

                string ISBN = "";
                string Acessno = "";
                string Btype = "";
                string Bname = "";
                string Bauthor = "";
                string Pubyear = "";
                string Edno = "";
                string Nop = "";
                string Bprice = "";
                string Btitle = "";
                string Bpubname = "";
                int Bqty = 0;
                string Bsubtitle = "";
                string Bsauthor = "";
                string Bsource = "";
                string Billno = "";
                string Bcolno = "";
                string Bshelf = "";
                string Blang = "";
                string Qrcode = "";
                string Bremark = "";
                int Biqty = 0;
                int Baqty = 0;
                string dt = "01/01/1973";              
                DateTime pdate = DateTime.Parse(dt);
                string Bvolume_No = "";
                string bSubject = "";
                string bcategory = "";

                SqlConnection connection = new SqlConnection(conn);
                connection.Open();




                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {




                    ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                    var rowcount = sheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {

                        //string query = "";

                        string query = "Insert Into BookMaster (isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark,biqty,baqty,Volume_No,bSubject,Bcategory)" +
        "values(@isbn,@acessno,@btype,@bname,@bauthor,@pubyear,@edno,@nop,@bprice,@pdate,@btitle,@bpubname,@bqty,@bsubtitle,@bsauthor,@bsource,@billno,@bcolno,@bshelfno,@blang,@qrcode,@remark,@biqty,@baqty,@Volume_No,@bSubject,@Bcategory)";

                        SqlCommand command = new SqlCommand(query, connection);

                        if (sheet.Cells[row, 1].Value != null)
                        {

                            if (string.IsNullOrEmpty(sheet.Cells[row, 1].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@isbn", ISBN);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@isbn", sheet.Cells[row, 1].Value.ToString());
                            }

                        }

                        else
                        {
                            command.Parameters.AddWithValue("@isbn", ISBN);
                        }





                        if (sheet.Cells[row, 2].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 2].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@acessno", Acessno);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@acessno", sheet.Cells[row, 2].Value.ToString());
                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@acessno", Acessno);

                        }


                        if (sheet.Cells[row, 3].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 3].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@btype", Btype);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@btype", sheet.Cells[row, 3].Value.ToString());
                            }

                        }

                        else
                        {
                            command.Parameters.AddWithValue("@btype", Btype);

                        }



                        if (sheet.Cells[row, 4].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 4].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@bname", Bname);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@bname", sheet.Cells[row, 4].Value.ToString());
                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bname", Bname);

                        }




                        if (sheet.Cells[row, 5].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 5].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@bauthor", Bauthor);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@bauthor", sheet.Cells[row, 5].Value.ToString());
                            }

                        }

                        else
                        {
                            command.Parameters.AddWithValue("@bauthor", Bauthor);
                        }





                        if (sheet.Cells[row, 6].Value != null)
                        {

                            if (string.IsNullOrEmpty(sheet.Cells[row, 6].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@pubyear", Pubyear);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@pubyear", sheet.Cells[row, 6].Value.ToString());
                            }


                        }
                        else
                        {
                            command.Parameters.AddWithValue("@pubyear", Pubyear);
                        }


                        if (sheet.Cells[row, 7].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 7].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@edno", Edno);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@edno", sheet.Cells[row, 7].Value.ToString());
                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@edno", Edno);

                        }



                        if (sheet.Cells[row, 8].Value != null)
                        {

                            if (string.IsNullOrEmpty(sheet.Cells[row, 8].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@nop", Nop);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@nop", sheet.Cells[row, 8].Value.ToString());
                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@nop", Nop);

                        }


                        if (sheet.Cells[row, 9].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 9].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@bprice", Bprice);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@bprice", sheet.Cells[row, 9].Value.ToString());
                            }


                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bprice", Bprice);

                        }


                       

                        if (sheet.Cells[row, 10].Value != null)
                        {


                            if (string.IsNullOrEmpty(sheet.Cells[row, 10].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@pdate", pdate);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@pdate", sheet.Cells[row, 10].Value);
                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@pdate", pdate);
                        }




                        //Console.WriteLine(pdate);

                        if (sheet.Cells[row, 11].Value != null)
                        {

                            if (string.IsNullOrEmpty(sheet.Cells[row, 11].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@btitle", Btitle);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@btitle", sheet.Cells[row, 11].Value.ToString());
                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@btitle", Btitle);
                        }



                        if (sheet.Cells[row, 12].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 12].Value.ToString()))
                            {
                                command.Parameters.AddWithValue("@bpubname", Bpubname);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@bpubname", sheet.Cells[row, 12].Value.ToString());
                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bpubname", Bpubname);
                        }


                        if (sheet.Cells[row, 13].Value != null)
                        {

                            if (string.IsNullOrEmpty(sheet.Cells[row, 13].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bqty", Bqty);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bqty", int.Parse(sheet.Cells[row, 13].Value.ToString()));

                            }
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@bqty", Bqty);
                        }



                        if (sheet.Cells[row, 14].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 14].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bsubtitle", Bsubtitle);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bsubtitle", sheet.Cells[row, 14].Value.ToString());

                            }


                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bsubtitle", Bsubtitle);
                        }




                        if (sheet.Cells[row, 15].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 15].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bsauthor", Bsauthor);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bsauthor", sheet.Cells[row, 15].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bsauthor", Bsauthor);
                        }


                        if (sheet.Cells[row, 16].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 16].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bsource", Bsource);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bsource", sheet.Cells[row, 16].Value.ToString());

                            }


                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bsource", Bsource);

                        }



                        if (sheet.Cells[row, 17].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 17].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@billno", Billno);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@billno", sheet.Cells[row, 17].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@billno", Billno);
                        }



                        if (sheet.Cells[row, 18].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 18].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bcolno", Bcolno);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bcolno", sheet.Cells[row, 18].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bcolno", Bcolno);
                        }



                        if (sheet.Cells[row, 19].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 19].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bshelfno", Bshelf);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bshelfno", (string)sheet.Cells[row, 19].Value);

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bshelfno", Bshelf);
                        }




                        if (sheet.Cells[row, 20].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 20].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@blang", Blang);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@blang", sheet.Cells[row, 20].Value.ToString());

                            }
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@blang", Blang);
                        }



                        if (sheet.Cells[row, 21].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 21].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@qrcode", Qrcode);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@qrcode", sheet.Cells[row, 21].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@qrcode", Qrcode);

                        }




                        if (sheet.Cells[row, 22].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 22].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@remark", Bremark);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@remark", sheet.Cells[row, 22].Value.ToString());

                            }
                        }
                        else
                        {

                            command.Parameters.AddWithValue("@remark", Bremark);
                        }






                        if (sheet.Cells[row, 23].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 23].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@biqty", Biqty);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@biqty", int.Parse(sheet.Cells[row, 23].Value.ToString()));

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@biqty", Biqty);
                        }


                        if (sheet.Cells[row, 24].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 24].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@baqty", Baqty);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@baqty", int.Parse(sheet.Cells[row, 24].Value.ToString()));

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@baqty", Baqty);
                        }




                        if (sheet.Cells[row, 25].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 25].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@Volume_No", Bvolume_No);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@Volume_No", sheet.Cells[row, 25].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Volume_No", Bvolume_No);
                        }



                        if (sheet.Cells[row, 26].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 26].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@bSubject", bSubject);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@bSubject", sheet.Cells[row, 26].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@bSubject", bSubject);
                        }


                        if (sheet.Cells[row, 27].Value != null)
                        {
                            if (string.IsNullOrEmpty(sheet.Cells[row, 27].Value.ToString()))
                            {

                                command.Parameters.AddWithValue("@Bcategory", bcategory);

                            }

                            else
                            {

                                command.Parameters.AddWithValue("@Bcategory", sheet.Cells[row, 27].Value.ToString());

                            }

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Bcategory", bcategory);
                        }





                        command.ExecuteNonQuery();


                    }


                }
                connection.Close();
            }

            Console.WriteLine("inserted all");

            return RedirectToAction("BookMaster","Home");
        }





        /******************** Issued Book Report Start*********************/

        public IActionResult IssuedBook_Report()
        {

            IssuedBookReport issuedbookReport = new IssuedBookReport();
           // List<Mybooks> mybooks = new List<Mybooks>();
            byte[] abytes = issuedbookReport.PrepareIssuedBookReport(GetIssuedBook());
            return File(abytes, "application/pdf");

        }





        public List<Mybooks> GetIssuedBook()
        {

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select  BM.acessno, BM.BName, BM.BAuthor, BM.edno, BM.bprice,BM.blang, Convert(varchar(30),BIM.BIDate,34),Convert(varchar(30),BIM.bexdate,34),MM.MName  from BookIssueMaster BIM, BookMaster BM, MemberMaster MM where BIM.BId = BM.BId and BIM.bstatus = 0 and BIM.MId = MM.MId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Mybooks> mybooks = new List<Mybooks>();

            while (reader.Read())
            {

                Mybooks mybook = new Mybooks();

                mybook.Bacessno = reader.GetString(0);
                mybook.Bname = reader.GetString(1);
                mybook.Bauthor = reader.GetString(2);
                mybook.Bedno = reader.GetString(3);
                mybook.Bprice = reader.GetString(4);
               // mybook.Bpubname = reader.GetString(6);
               // mybook.Bqty = (Int32)reader.GetValue(7);
               // mybook.Bbillno = reader.GetString(8);
               // mybook.Bshelfno = reader.GetString(9);
                mybook.Blang = reader.GetString(5);
                mybook.isdate = reader.GetString(6);
                mybook.rtdate = reader.GetString(7);
                mybook.mname = reader.GetString(8);


                mybooks.Add(mybook);

            }


            return mybooks;


        }


        /******************** Issued Book Report End*********************/



        /************************* College Report start*************************************/
        public IActionResult College_Report()
        {

            CollegeReport studentReport = new CollegeReport();
            //List<College> college = new List<College>();
            byte[] abytes = studentReport.PrepareReport(GetCollege());
            return File(abytes, "application/pdf");

        }





        public List<College> GetCollege()
        {


            
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from CollegeMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<College> colleges = new List<College>();

            while(reader.Read())
            {

                College college = new College();

                college.ColName = reader.GetString(1);
                college.Coladdr = reader.GetString(2);
                college.Conpername = reader.GetString(3);
                college.Conpermobie = reader.GetString(4);  
                college.Coperemail = reader.GetString(5);   
                college.Colmobile = reader.GetString(6);    
                college.Colremark = reader.GetString(7);
                colleges.Add(college);

            }

           
            return colleges;  


        }




        public ActionResult ExportToExcel()
        {

           
            return View();

        }


      



        /************************* College Report End*************************************/



        /************************* Book Category Report start*************************************/
        public IActionResult Book_Category_Report()
        {

            BookCategoryReport studentReport = new BookCategoryReport();
            //List<College> college = new List<College>();
            byte[] abytes = studentReport.PrepareBCReport(GetBookCategory());
            return File(abytes, "application/pdf");

        }





        public List<BookCategory> GetBookCategory()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from BookCategoryMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<BookCategory> bookCategories = new List<BookCategory>();

            while (reader.Read())
            {

                BookCategory bookcategory = new BookCategory();

                bookcategory.Bcname = reader.GetString(1);
                bookcategory.Bcremark = reader.GetString(2);
               bookCategories.Add(bookcategory);    

            }


            return bookCategories;


        }



        /************************* Book Category Report End*************************************/



        /*************************Session Report start*************************************/
        public IActionResult Session_Report()
        {

            SessionReport sessionreport = new SessionReport();
           // List<My_session> mysession = new List<My_session>();
            byte[] abytes = sessionreport.PrepareSessionReport(GetSession());
            return File(abytes, "application/pdf");

        }





        public List<My_session> GetSession()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from SessionMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<My_session> mysessions = new List<My_session>();

            while (reader.Read())
            {

                My_session mysession = new My_session();

                mysession.SName = reader.GetString(1);

                mysession.Sremark = reader.GetString(2);
                mysessions.Add(mysession);

            }


            return mysessions;


        }



        /************************* Session Report  End*************************************/


        /*************************Section Report start*************************************/
        public IActionResult Section_Report()
        {

            SectionReoprt sectionreport = new SectionReoprt();
            // List<My_session> mysession = new List<My_session>();
            byte[] abytes = sectionreport.PrepareSectionReport(GetSection());
            return File(abytes, "application/pdf");

        }





        public List<My_section> GetSection()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from SectionMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<My_section> mysections = new List<My_section>();

            while (reader.Read())
            {

                My_section mysection = new My_section();


                mysection.CName = reader.GetString(1);

                mysection.SName = reader.GetString(2);

                mysection.Sremark = reader.GetString(3);
                mysections.Add(mysection);

            }


            return mysections;


        }



        /************************* Section Report  End*************************************/





        /*************************Member Category Report start*************************************/
        public IActionResult Member_Category_Report()
        {

            MemberCategoryReport membercategoryreport = new MemberCategoryReport();
            // List<My_session> mysession = new List<My_session>();
            byte[] abytes = membercategoryreport.PrepareMemberCategoryReport(GetMemberCategory());
            return File(abytes, "application/pdf");

        }





        public List<Member_type> GetMemberCategory()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from MemberTypeMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Member_type> membercategories = new List<Member_type>();

            while (reader.Read())
            {

                Member_type membercategory = new Member_type();

                membercategory.Mttype = reader.GetString(1);

                membercategory.Mtremark = reader.GetString(2);
                membercategories.Add(membercategory);

            }


            return membercategories;


        }



        /************************* Member Category Report  End*************************************/



        /*************************Class Report start*************************************/
        public IActionResult Class_Report()
        {

            ClassReport classreport = new ClassReport();
            // List<My_session> mysession = new List<My_session>();
            byte[] abytes = classreport.PrepareClassReport(GetClass());
            return File(abytes, "application/pdf");

        }





        public List<My_class> GetClass()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from ClassMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<My_class> myclasses = new List<My_class>();

            while (reader.Read())
            {

                My_class myclass = new My_class();

                myclass.CName = reader.GetString(1);

                myclass.Cremark = reader.GetString(2);
                myclasses.Add(myclass);

            }


            return myclasses;


        }



        /************************* Class Report  End*************************************/


        /*************************Book Report start*************************************/
        public IActionResult Book_Report()
        {

            BookReport bookreport = new BookReport();
            // List<My_session> mysession = new List<My_session>();
            byte[] abytes = bookreport.PrepareBookReport(GetBook());
            return File(abytes, "application/pdf");

        }





        public List<Mybooks> GetBook()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select acessno,bname,bauthor,edno,nop,bprice,bpubname,bqty,billno,bshelfno,blang from BookMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Mybooks> mybooks = new List<Mybooks>();

            while (reader.Read())
            {

                Mybooks mybook = new Mybooks();

                mybook.Bacessno = reader.GetString(0);
                mybook.Bname = reader.GetString(1);
                mybook.Bauthor = reader.GetString(2);
                mybook.Bedno = reader.GetString(3);
                mybook.Bnop = reader.GetString(4);
                mybook.Bprice = reader.GetString(5);
                mybook.Bpubname = reader.GetString(6);
                mybook.Bqty = (Int32)reader.GetValue(7);
                mybook.Bbillno = reader.GetString(8);
                mybook.Bshelfno = reader.GetString(9);
                mybook.Blang= reader.GetString(10);
               


                mybooks.Add(mybook);

            }


            return mybooks;


        }



        /************************* Book Report  End*************************************/



        /************************Member Report start*************************************/
        public IActionResult Member_Report()
        {

            MemberReport memberreport = new MemberReport();
            // List<My_session> mysession = new List<My_session>();
            byte[] abytes = memberreport.PrepareMemberReport(GetMember());
            return File(abytes, "application/pdf");

        }





        public List<My_member> GetMember()
        {



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select * from MemberMaster";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<My_member> mymembers = new List<My_member>();

            while (reader.Read())
            {

                My_member mymember = new My_member();

                mymember.Mname = reader.GetString(1);

                mymember.Mtype = reader.GetString(2);


                mymember.Mgen = reader.GetString(3);

                mymember.Maddr = reader.GetString(4);



                mymember.Mclass = reader.GetString(5);

                mymember.Memail = reader.GetString(6);



                mymember.Mmob = reader.GetString(7);

                mymember.Myear = reader.GetString(8);


                mymember.Msection = reader.GetString(9);


                mymembers.Add(mymember);

            }


            return mymembers;


        }



        /************************* Member Report  End************************************/

        [Authorize(Roles = "admin,user")]
        public IActionResult Index()
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "Select Count(*) from BookMaster";
            SqlCommand command = new SqlCommand(query,connection);

            int TotalBooks = (Int32)command.ExecuteScalar();

            if (TotalBooks>0)
            {
                ViewBag.TotalBooks = TotalBooks;    
            }

            string query1 = "Select Count(*) from bookissuemaster where bstatus = 0";
            SqlCommand command1 = new SqlCommand(query1, connection);

            int  issuedbooks = (Int32)command1.ExecuteScalar();



            if (issuedbooks > 0)
            {
                ViewBag.booksin = TotalBooks-issuedbooks;
                ViewBag.issuedbooks = issuedbooks;  
            }
            else
            {
                ViewBag.booksin = TotalBooks;
            }

            string query2 = "Select Count(*) from membermaster";
            SqlCommand command2 = new SqlCommand(query2, connection);

            int totalmembers = (Int32)command2.ExecuteScalar();

            if (totalmembers > 0)
            {
                ViewBag.totalmembers = totalmembers;
            }
           
            connection.Close();
            return View();
        }



        public IActionResult GenerateQr()
        {
            string qrid = Request.Query["qrid"];

            QrCode studentReport = new QrCode();
            byte[] abytes = studentReport.PrepareReport(qrid);
            return File(abytes, "application/pdf");


        }








        /************************* College Master  Start*************************************/
        [Authorize(Roles = "admin")]
        public IActionResult CollegeMaster()
        {
            var colleges = new List<College>();
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Select CId ,CName,CAddress,CContact,CPerson,CEmail,CMob from CollegeMaster";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                College college = new College();
                college.Id = (Int32)reader.GetValue(0);
                college.ColName = reader.GetString(1);
                college.Coladdr = reader.GetString(2);
                college.Colmobile = reader.GetString(3);
                college.Conpername = reader.GetString(4);
                college.Coperemail = reader.GetString(5);
                college.Conpermobie = reader.GetString(6);

                colleges.Add(college);

                ViewData["colleges"] = colleges;

            }

            return View();
        }








        [HttpPost]
        public IActionResult AddCollege(string colname, string coladdr, string conpername, string cremark, string conpermobile, string coperemail, string colmobile)
        {



            //Console.WriteLine(colname);
            //Console.WriteLine(coladdr);
            //Console.WriteLine(conpername);
            //Console.WriteLine(cremark);
            //Console.WriteLine(conpermobile);
            //Console.WriteLine(coperemail);
            //Console.WriteLine(colmobile);


            if(string.IsNullOrEmpty(cremark))

            {
                cremark = "";
            }



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Insert Into CollegeMaster (CName,CAddress,CPerson,CMob,CEmail,CContact,Remark) values(@CName,@CAddress,@CPerson,@CMob,@CEmail,@CContact,@Remark)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@CName", colname);
            command.Parameters.AddWithValue("@CAddress", coladdr);
            command.Parameters.AddWithValue("@CPerson", conpername);
            command.Parameters.AddWithValue("@CMob", conpermobile);
            command.Parameters.AddWithValue("@CEmail", coperemail);
            command.Parameters.AddWithValue("@CContact", colmobile);
            command.Parameters.AddWithValue("@Remark", cremark);
            command.ExecuteNonQuery();
            sqlConnection.Close();


            return RedirectToAction("CollegeMaster", "Home");
        }














        public IActionResult EditCollege()
        {
            string editid = Request.Query["editid"];
            var colleges = new List<College>();
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Select CId ,CName,CAddress,CContact,CPerson,CEmail,CMob,Remark from CollegeMaster where CId = @id";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@id",editid);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                College college = new College();
                college.Id = (Int32)reader.GetValue(0);
                college.ColName = reader.GetString(1);
                college.Coladdr = reader.GetString(2);
                college.Colmobile = reader.GetString(3);
                college.Conpername = reader.GetString(4);
                college.Coperemail = reader.GetString(5);
                college.Conpermobie = reader.GetString(6);
                college.Colremark = reader.GetString(7);    
                colleges.Add(college);

                ViewData["colleges"] = colleges;

            }
            return View();
        }



        public IActionResult UpdateCollege()
        {
            return View();
        }


        [HttpPost]
        public IActionResult UpdateCollege(int id,string colname, string coladdr, string conpername, string cremark, string conpermobile, string coperemail, string colmobile)
        {


           /* Console.WriteLine(id);
            Console.WriteLine(colname);
            Console.WriteLine(coladdr);
            Console.WriteLine(conpername);
            Console.WriteLine(cremark);
            Console.WriteLine(conpermobile);
            Console.WriteLine(coperemail);
            Console.WriteLine(colmobile);*/

            if(string.IsNullOrEmpty(cremark))

            {
                cremark = "";
            }



            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Update CollegeMaster Set  CName = @colname,CAddress=@coladdr,CPerson=@conpername,Remark=@cremark,CMob=@conpermobile,CEmail=@coperemail,CContact=@colmobile  Where CId = @id";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@colname", colname);
            command.Parameters.AddWithValue("@coladdr", coladdr);
            command.Parameters.AddWithValue("@conpername", conpername);
            command.Parameters.AddWithValue("@cremark", cremark);
            command.Parameters.AddWithValue("@conpermobile", conpermobile);
            command.Parameters.AddWithValue("@coperemail", coperemail);
            command.Parameters.AddWithValue("@colmobile", colmobile);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();  
            sqlConnection.Close();


            return RedirectToAction("CollegeMaster", "Home");
        }



        /*************************************************College Matser  End ****************************************************************************/



        /********************************************************* Session Matser  Start *****************************************************************/
        [Authorize(Roles = "admin")]
        public IActionResult SessionMaster()
        {

            var mysessions = new List<My_session>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select SId , SName , Remark from SessionMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();  
            while (reader.Read()) { 
            
                My_session my_Session = new My_session();
                my_Session.Id = (Int32)reader.GetValue(0);
              
                my_Session.SName = reader.GetString(1);
                my_Session.Sremark = reader.GetString(2);
                mysessions.Add(my_Session);
                ViewData["mysessions"] = mysessions;    
            
            }

            reader.Close();

            connection.Close();

            return View();
        }


        [HttpPost]
        public IActionResult Addsession(string Sname,string Sremark)
        {


            if(string.IsNullOrEmpty(Sremark))
            {
                Sremark = "";
            }


            Console.WriteLine(Sname+" "+Sremark);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Insert Into SessionMaster(SName,Remark) values(@SName,@Remark)";

            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@SName",Sname);
            command.Parameters.AddWithValue("@Remark", Sremark);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("SessionMaster","Home");
        }




       
        public IActionResult EditSession()
        {

            var mysessions = new List<My_session>();

            string editid = Request.Query["editid"]; 

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "select SId,  SName, Remark from SessionMaster where SId = @editid";

            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@editid",editid);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) { 
            

                My_session session = new My_session();
                session.Id = (Int32)reader.GetValue(0);
                session.SName = reader.GetString(1);
                session.Sremark = reader.GetString(2);
                mysessions.Add(session);
                ViewData["mysessions"] = mysessions;


            }

           

            reader.Close();
            

            connection.Close();

            return View();
        }



        public IActionResult UpdateSession()
        {
            return View();
        }






        [HttpPost]
        public IActionResult UpdateSession( string SId, string Sname, string Sremark)
        {

            if (string.IsNullOrEmpty(Sremark))
            {
                Sremark = "";
            }

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Update SessionMaster Set SName = @Sname, Remark = @Sremark  Where SId = @SId";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Sname", Sname);
            command.Parameters.AddWithValue("@Sremark", Sremark);
            command.Parameters.AddWithValue("@SId", SId);
            command.ExecuteNonQuery();
            sqlConnection.Close();


            return RedirectToAction("SessionMaster", "Home");

        }


        /************************************************************** Session Matser  End  ******************************************************************************/











        /************************************************************** Class Matser start ******************************************************************************/





        [Authorize(Roles = "admin")]
        public IActionResult ClassMaster()
        {

            var myclasses = new List<My_class>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select CId , CName , Remark from ClassMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_class my_class = new My_class();
                my_class.Id = (Int32)reader.GetValue(0);

                my_class.CName = reader.GetString(1);
                my_class.Cremark = reader.GetString(2);
                myclasses.Add(my_class);
                ViewData["myclasses"] = myclasses;
                
            }

            reader.Close();

            connection.Close();

            return View();
        }


        [HttpPost]
        public IActionResult AddClass(string Cname, string Cremark)
        {
            if (string.IsNullOrEmpty(Cremark))
            {
                Cremark = "";
            }

            Console.WriteLine(Cname + " " + Cremark);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Insert Into ClassMaster (CName,Remark) values(@CName,@Remark)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CName", Cname);
            command.Parameters.AddWithValue("@Remark", Cremark);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("ClassMaster", "Home");
        }





        public IActionResult EditClass()
        {

            var myclasses = new List<My_class>();

            string editid = Request.Query["editid"];

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "select CId,  CName, Remark from ClassMaster where CId = @editid";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@editid", editid);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                My_class myclass = new My_class();
                myclass.Id = (Int32)reader.GetValue(0);
                myclass.CName = reader.GetString(1);
                myclass.Cremark = reader.GetString(2);
                myclasses.Add(myclass);
                ViewData["myclasses"] = myclasses;


            }

           

            reader.Close();


            connection.Close();

            return View();
        }



        public IActionResult UpdateClass()
        {
            return View();
        }






        [HttpPost]
        public IActionResult UpdateClass(string CId, string Cname, string Cremark)
        {

            if (string.IsNullOrEmpty(Cremark))
            {
                Cremark = "";
            }

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Update ClassMaster Set CName = @Cname, Remark = @Cremark  Where CId = @CId";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Cname", Cname);
            command.Parameters.AddWithValue("@Cremark", Cremark);
            command.Parameters.AddWithValue("@CId", CId);
            command.ExecuteNonQuery();
            sqlConnection.Close();


            return RedirectToAction("ClassMaster", "Home");

        }








        /************************************************************** Class Matser End ******************************************************************************/




        /************************************************************** Section Matser Start  ******************************************************************************/



        [Authorize(Roles = "admin")]
        public IActionResult SectionMaster()
        {

            var mysections = new List<My_section>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select SId , CName , Sname, Remark from SectionMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_section my_section = new My_section();
                my_section.Id = (Int32)reader.GetValue(0);

                my_section.CName = reader.GetString(1);
                my_section.SName = reader.GetString(2); 
                my_section.Sremark = reader.GetString(3);
                mysections.Add(my_section);
                ViewData["mysections"] = mysections;

            }

            reader.Close();

            var myclasses = new List<My_class>();

            string get_Class_query = "Select * from ClassMaster";
            SqlCommand _command = new SqlCommand(get_Class_query, connection);
            SqlDataReader _reader = _command.ExecuteReader();
            while (_reader.Read())
            {

                My_class my_class = new My_class();
               
                my_class.CName = _reader.GetString(1);
                myclasses.Add(my_class);
                ViewData["myclasses"] = myclasses;

            }

            _reader.Close();
            connection.Close();
            return View();
        }


        [HttpPost]
        public IActionResult AddSection(string Cname,string Sname, string Sremark)
        {

            if (string.IsNullOrEmpty(Sremark))
            {
                Sremark = "";
            }

            Console.WriteLine(Cname);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Insert Into SectionMaster (CName,SName,Remark) values(@CName,@SName,@Remark)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CName", Cname);
            command.Parameters.AddWithValue("@SName", Sname);
            command.Parameters.AddWithValue("@Remark", Sremark);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("SectionMaster", "Home");
        }





        public IActionResult EditSection()
        {

            var mysections = new List<My_section>();

            string editid = Request.Query["editid"];

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "select SId, CName, SName, Remark from SectionMaster where SId = @editid";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@editid", editid);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                My_section mysection = new My_section();
                mysection.Id = (Int32)reader.GetValue(0);
                mysection.CName = reader.GetString(1);
                mysection.SName = reader.GetString(2);
                mysection.Sremark = reader.GetString(3);
                mysections.Add(mysection);
                ViewData["mysections"] = mysections;


            }



            reader.Close();


            connection.Close();

            return View();
        }



        public IActionResult UpdateSection()
        {
            return View();
        }






        [HttpPost]
        public IActionResult UpdateSection(string SId,string Cname ,string Sname, string Sremark)
        {

            if (string.IsNullOrEmpty(Sremark))
            {
                Sremark = "";
            }

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Update SectionMaster Set CName = @Cname,SName= @SName, Remark = @Sremark  Where SId = @SId";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Cname", Cname);
            command.Parameters.AddWithValue("@Sname", Sname);
            command.Parameters.AddWithValue("@Sremark", Sremark);
            command.Parameters.AddWithValue("@SId", SId);
            command.ExecuteNonQuery();
            sqlConnection.Close();


            return RedirectToAction("SectionMaster", "Home");

        }





        /************************************************************** Section Matser  Start ******************************************************************************/





        /************************************************************** Book Category Matser  Start ******************************************************************************/



        [Authorize(Roles = "admin")]
        public IActionResult BookCategoryMaster()
        {

            var bookcategories = new List<BookCategory>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select BCId , CName , Remark from BookCategoryMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                BookCategory my_class = new BookCategory();
                my_class.Id = (Int32)reader.GetValue(0);

                my_class.Bcname = reader.GetString(1);
                my_class.Bcremark = reader.GetString(2);
                bookcategories.Add(my_class);
                ViewData["bookcategories"] = bookcategories;

            }

            reader.Close();

            connection.Close();

            return View();
        }


        [HttpPost]
        public IActionResult  AddBookCategory(string bcname, string bcremark)
        {

            if (string.IsNullOrEmpty(bcremark))
            {
                bcremark = "";
            }

            Console.WriteLine(bcname + " " + bcremark);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Insert Into BookCategoryMaster (CName,Remark) values(@CName,@Remark)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CName", bcname);
            command.Parameters.AddWithValue("@Remark", bcremark);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("BookCategoryMaster", "Home");
        }




        
        public IActionResult EditBookCategory()
        {

            var bookcategories = new List<BookCategory>();

            string editid = Request.Query["editid"];

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select BCId , CName , Remark from BookCategoryMaster Where BCId = @BCId";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@BCId",editid);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                BookCategory my_class = new BookCategory();
                my_class.Id = (Int32)reader.GetValue(0);

                my_class.Bcname = reader.GetString(1);
                my_class.Bcremark = reader.GetString(2);
                bookcategories.Add(my_class);
                ViewData["bookcategories"] = bookcategories;

            }



            reader.Close();


            connection.Close();

            return View();
        }



        public IActionResult UpdateBookCategory()
        {
            return View();
        }






        [HttpPost]
        public IActionResult UpdateBookCategory(string bcid, string bcname, string bcremark)
        {

            if (string.IsNullOrEmpty(bcremark))
            {
                bcremark = "";
            }

            Console.WriteLine(bcname + " " + bcremark);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Update BookCategoryMaster  set CName=@CName,Remark=@Remark where BCId=@bcid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CName", bcname);
            command.Parameters.AddWithValue("@Remark", bcremark);
            command.Parameters.AddWithValue("@bcid", bcid);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("BookCategoryMaster", "Home");
        }

















        /************************************************************** Book Category Matser  End ******************************************************************************/





        /************************************************************** Book Matser  Start ******************************************************************************/
        [Authorize(Roles = "admin")]
        public IActionResult BookMaster()
        {

            var books = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select Top 100  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster";

            SqlCommand command = new SqlCommand(query,connection);
            SqlDataReader reader = command.ExecuteReader(); 

            while(reader.Read())
            {
                Mybooks mybooks = new Mybooks();
                mybooks.Id = (Int32)reader.GetValue(0);
                mybooks.Isbn = reader.GetString(1);
                mybooks.Bacessno = reader.GetString(2);
                mybooks.Btype = reader.GetString(3);
                mybooks.Bname = reader.GetString(4);
                mybooks.Bauthor = reader.GetString(5);
                mybooks.Bpubyear = reader.GetString(6);
                mybooks.Bedno = reader.GetString(7);
                mybooks.Bnop = reader.GetString(8);
                mybooks.Bprice = reader.GetString(9);
                mybooks.Bpdate = (DateTime)reader.GetValue(10);
                mybooks.Btitle = reader.GetString(11);
                mybooks.Bpubname = reader.GetString(12);
                mybooks.Bqty = (Int32)reader.GetValue(13);
                mybooks.Bsubtitle = reader.GetString(14);
                mybooks.Bsauthor = reader.GetString(15);
                mybooks.Bsource = reader.GetString(16);
                mybooks.Bbillno = reader.GetString(17);
                mybooks.Bcollno = reader.GetString(18);
                mybooks.Bshelfno = reader.GetString(19);
                mybooks.Blang = reader.GetString(20);
                mybooks.qrcode = reader.GetString(21);
                mybooks.bRemark = reader.GetString(22);
                books.Add(mybooks);
                ViewData["books"] = books;


            }

            reader.Close();


            string query1 = "select Cname from BookCategoryMaster";

            SqlCommand command1 = new SqlCommand(query1,connection);

            SqlDataReader reader1 = command1.ExecuteReader();

            var bcategory = new List<BookCategory>();

            while(reader1.Read())
            {
                BookCategory bookcategory = new BookCategory(); 
                bookcategory.Bcname = reader1.GetString(0);
                bcategory.Add(bookcategory);
                ViewData["bcategory"] = bcategory;

               

            }

           
            //foreach(var item in bcategory)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Bcname);
            //}

            reader1.Close();

            connection.Close();

            



            return View();
        }
        [HttpPost] 
        public IActionResult BookMaster(string searchel, int type)
        {
            string query = "";
            int f = 0;
            if (string.IsNullOrEmpty(searchel))
            {
                 query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster";
            }
            else if(type == 1)
            {
                 query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster where  bid = @bid";
                f = 1;
            }

            else if(type == 2)
            {
                query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster where  acessno = @acessno";
                f = 2;

            }


            else if (type == 3)
            {
                query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster where  bname = @bname";
                f = 3;

            }

            var books = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            //string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster where  acessno = @acessno";

            SqlCommand command = new SqlCommand(query, connection);
            if(f==1)
            {
                command.Parameters.AddWithValue("@bid", searchel);
                
            }

            if (f == 2)
            {
               
                command.Parameters.AddWithValue("@acessno", searchel);
                

            }

            if (f == 3)
            {
               
                command.Parameters.AddWithValue("@bname", searchel);

            }

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Mybooks mybooks = new Mybooks();
                mybooks.Id = (Int32)reader.GetValue(0);
                mybooks.Isbn = reader.GetString(1);
                mybooks.Bacessno = reader.GetString(2);
                mybooks.Btype = reader.GetString(3);
                mybooks.Bname = reader.GetString(4);
                mybooks.Bauthor = reader.GetString(5);
                mybooks.Bpubyear = reader.GetString(6);
                mybooks.Bedno = reader.GetString(7);
                mybooks.Bnop = reader.GetString(8);
                mybooks.Bprice = reader.GetString(9);
                mybooks.Bpdate = (DateTime)reader.GetValue(10);
                mybooks.Btitle = reader.GetString(11);
                mybooks.Bpubname = reader.GetString(12);
                mybooks.Bqty = (Int32)reader.GetValue(13);
                mybooks.Bsubtitle = reader.GetString(14);
                mybooks.Bsauthor = reader.GetString(15);
                mybooks.Bsource = reader.GetString(16);
                mybooks.Bbillno = reader.GetString(17);
                mybooks.Bcollno = reader.GetString(18);
                mybooks.Bshelfno = reader.GetString(19);
                mybooks.Blang = reader.GetString(20);
                mybooks.qrcode = reader.GetString(21);
                mybooks.bRemark = reader.GetString(22);
                books.Add(mybooks);
                ViewData["books"] = books;


            }

            reader.Close();
            connection.Close();

            return View();
        }

        [HttpPost]
        public IActionResult AddBook(string Isbn,string Bacessno,string Btype,string Bname,string Bcategory,string Bauthor 
            
           ,string Bpubyear,string Bedno,string Bnop, string Bprice, DateTime Bpdate,string Btitle,string Bpubname,string bVolume_No
            , int Bqty, string Bsubtitle,string Bsauthor,string Bsource,string bSubject ,string Bbillno, string Bcollno, string Bshelfno,
            
            string Blang,string qrcode, string bRemark)

        {


            if (string.IsNullOrEmpty(bRemark))
            {
                bRemark = "";
            }


            if (string.IsNullOrEmpty(Isbn))
            {
                Isbn = "";
            }



            if (string.IsNullOrEmpty(Btype))
            {
                Btype = "";
            }



            if (string.IsNullOrEmpty(Bname))
            {
                Bname = "";
            }


            if (string.IsNullOrEmpty(Bauthor))
            {
                Bauthor = "";
            }


            if (string.IsNullOrEmpty(Bpubyear))
            {
                Bpubyear = "";
            }

            if (string.IsNullOrEmpty(Bedno))
            {
                Bedno = "";
            }


            if (string.IsNullOrEmpty(Bnop))
            {
                Bnop = "";
            }

            if (string.IsNullOrEmpty(Bprice))
            {
                Bprice = "";
            }

            if (string.IsNullOrEmpty(Btitle))
            {
                Btitle = "";
            }

            if (string.IsNullOrEmpty(Bpubname))
            {
                Bpubname = "";
            }

            if (string.IsNullOrEmpty(bVolume_No))
            {
                bVolume_No = "";
            }

            if (string.IsNullOrEmpty(Bqty.ToString()))
            {
                Bqty = 1;
            }

            if (string.IsNullOrEmpty(Bsubtitle))
            {
                Bsubtitle = "";
            }



            if (string.IsNullOrEmpty(Bsauthor))
            {
                Bsauthor = "";
            }

            if (string.IsNullOrEmpty(Bsource))
            {
                Bsource = "";
            }




            if (string.IsNullOrEmpty(bSubject))
            {
                bSubject = "";
            }


            if (string.IsNullOrEmpty(Bbillno))
            {
                Bbillno = "";
            }

            if (string.IsNullOrEmpty(Bcollno))
            {
                Bcollno = "";
            }

            if (string.IsNullOrEmpty(Bshelfno))
            {
                Bshelfno = "";
            }


            if (string.IsNullOrEmpty(Blang))
            {
                Blang = "";
            }


            if (string.IsNullOrEmpty(qrcode))
            {
                qrcode = "";
            }


            if (string.IsNullOrEmpty(Bcategory))
            {
                Bcategory = "";
            }





            Console.WriteLine(Bpdate);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Insert Into BookMaster (isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark,biqty,baqty,Volume_No,bSubject,Bcategory)" +
                "values(@isbn,@acessno,@btype,@bname,@bauthor,@pubyear,@edno,@nop,@bprice,@pdate,@btitle,@bpubname,@bqty,@bsubtitle,@bsauthor,@bsource,@billno,@bcolno,@bshelfno,@blang,@qrcode,@remark,@biqty,@baqty,@Volume_No,@bSubject,@Bcategory)";

            SqlCommand command = new SqlCommand(query, connection);

            Bpdate = Bpdate.Date;
            
            command.Parameters.AddWithValue("@isbn",Isbn);
            command.Parameters.AddWithValue("@acessno",Bacessno);
            command.Parameters.AddWithValue("@btype",Btype);
            command.Parameters.AddWithValue("@bname",Bname);
            command.Parameters.AddWithValue("@bauthor",Bauthor);
            command.Parameters.AddWithValue("@pubyear",Bpubyear);
            command.Parameters.AddWithValue("@edno",Bedno);
            command.Parameters.AddWithValue("@nop",Bnop);
            command.Parameters.AddWithValue("@bprice",Bprice);
            command.Parameters.AddWithValue("@pdate",Bpdate);
            command.Parameters.AddWithValue("@btitle",Btitle);
            command.Parameters.AddWithValue("@bpubname",Bpubname);
            command.Parameters.AddWithValue("@bqty",Bqty);
            command.Parameters.AddWithValue("@bsubtitle",Bsubtitle);
            command.Parameters.AddWithValue("@bsauthor",Bsauthor);
            command.Parameters.AddWithValue("@bsource",Bsource);
            command.Parameters.AddWithValue("@billno",Bbillno);
            command.Parameters.AddWithValue("@bcolno",Bcollno);
            command.Parameters.AddWithValue("@bshelfno",Bshelfno);
            command.Parameters.AddWithValue("@blang",Blang);
            command.Parameters.AddWithValue("@qrcode",qrcode);
            command.Parameters.AddWithValue("@remark",bRemark);
            command.Parameters.AddWithValue("@biqty", 0);
            command.Parameters.AddWithValue("@baqty", Bqty);
            command.Parameters.AddWithValue("@Volume_No",bVolume_No);
            command.Parameters.AddWithValue("@bSubject", bSubject);
            command.Parameters.AddWithValue("@Bcategory", Bcategory);
            command.ExecuteNonQuery();

            connection.Close();

            

            return RedirectToAction("BookMaster", "Home");
        }


        public IActionResult EditBook()
        {

            string editid = Request.Query["editid"];

            var books = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark,volume_no,bSubject,Bcategory from BookMaster where bid = @bid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@bid",editid);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Mybooks mybooks = new Mybooks();
                mybooks.Id = (Int32)reader.GetValue(0);
                mybooks.Isbn = reader.GetString(1);
                mybooks.Bacessno = reader.GetString(2);
                mybooks.Btype = reader.GetString(3);
                mybooks.Bname = reader.GetString(4);
                mybooks.Bauthor = reader.GetString(5);
                mybooks.Bpubyear = reader.GetString(6); 
                mybooks.Bedno = reader.GetString(7);
                mybooks.Bnop = reader.GetString(8);
                mybooks.Bprice = reader.GetString(9);
                DateTime bpdate = (DateTime)reader.GetValue(10);
                ViewBag.day = bpdate.Day;
                ViewBag.month = bpdate.Month;
                ViewBag.year = bpdate.Year;
                mybooks.Btitle = reader.GetString(11);
                mybooks.Bpubname = reader.GetString(12);
                mybooks.Bqty = (Int32)reader.GetValue(13);
                mybooks.Bsubtitle = reader.GetString(14);
                mybooks.Bsauthor = reader.GetString(15);
                mybooks.Bsource = reader.GetString(16);
                mybooks.Bbillno = reader.GetString(17);
                mybooks.Bcollno = reader.GetString(18);
                mybooks.Bshelfno = reader.GetString(19);
                mybooks.Blang = reader.GetString(20);
                mybooks.qrcode = reader.GetString(21);
                mybooks.bRemark = reader.GetString(22);
                mybooks.Bvolume_no = reader.GetString(23);
                mybooks.bSubject = reader.GetString(24);
                mybooks.Bcname = reader.GetString(25);
                books.Add(mybooks);
                ViewData["books"] = books;


            }

            reader.Close();

            string query1 = "select Cname from BookCategoryMaster";

            SqlCommand command1 = new SqlCommand(query1, connection);

            SqlDataReader reader1 = command1.ExecuteReader();

            var bcategory = new List<BookCategory>();

            while (reader1.Read())
            {
                BookCategory bookcategory = new BookCategory();
                bookcategory.Bcname = reader1.GetString(0);
                bcategory.Add(bookcategory);
                ViewData["bcategory"] = bcategory;



            }


            //foreach(var item in bcategory)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Bcname);
            //}

            reader1.Close();





            connection.Close();









            return View();
        }



        [HttpPost]
        public IActionResult UpdateBook(string bid ,string Isbn, string Bacessno, string Btype, string Bname, string Bauthor

           , string Bpubyear, string Bedno, string Bnop, string Bprice,string bpdate,string Bcategory, string Bpubname, string bVolume_No
            , int Bqty, string Bsubtitle, string Bsauthor,string bSubject, string Bsource, string Bbillno, string Bcollno, string Bshelfno,

            string Blang, string qrcode, string bRemark)

        {


            string dt = "01/01/1973";
            DateTime Bpdate = DateTime.Parse(dt);

            if (string.IsNullOrEmpty(bpdate))
            {
                Bpdate = DateTime.Parse(dt);
            }
            else
            {
                Bpdate = DateTime.Parse(bpdate);
            }



            if (string.IsNullOrEmpty(bRemark))
            {
                bRemark = "";
            }

            if (string.IsNullOrEmpty(Bacessno))
            {
                Bacessno = "";
            }




            if (string.IsNullOrEmpty(Isbn))
            {
                Isbn = "";
            }



            if (string.IsNullOrEmpty(Btype))
            {
                Btype = "";
            }



            if (string.IsNullOrEmpty(Bname))
            {
                Bname = "";
            }


            if (string.IsNullOrEmpty(Bauthor))
            {
                Bauthor = "";
            }


            if (string.IsNullOrEmpty(Bpubyear))
            {
                Bpubyear = "";
            }

            if (string.IsNullOrEmpty(Bedno))
            {
                Bedno = "";
            }


            if (string.IsNullOrEmpty(Bnop))
            {
                Bnop = "";
            }

            if (string.IsNullOrEmpty(Bprice))
            {
                Bprice = "";
            }

            if (string.IsNullOrEmpty(Bcategory))
            {
                Bcategory = "";
            }

            if (string.IsNullOrEmpty(Bpubname))
            {
                Bpubname = "";
            }

            if (string.IsNullOrEmpty(bVolume_No))
            {
                bVolume_No = "";
            }

            if (string.IsNullOrEmpty(Bqty.ToString()))
            {
                Bqty = 1;
            }

            if (string.IsNullOrEmpty(Bsubtitle))
            {
                Bsubtitle = "";
            }



            if (string.IsNullOrEmpty(Bsauthor))
            {
                Bsauthor = "";
            }

            if (string.IsNullOrEmpty(Bsource))
            {
                Bsource = "";
            }




            if (string.IsNullOrEmpty(bSubject))
            {
                bSubject = "";
            }


            if (string.IsNullOrEmpty(Bbillno))
            {
                Bbillno = "";
            }

            if (string.IsNullOrEmpty(Bcollno))
            {
                Bcollno = "";
            }

            if (string.IsNullOrEmpty(Bshelfno))
            {
                Bshelfno = "";
            }


            if (string.IsNullOrEmpty(Blang))
            {
                Blang = "";
            }

            if (string.IsNullOrEmpty(qrcode))
            {
                qrcode = "";
            }




            //Console.WriteLine(Bpdate);

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Update  BookMaster set isbn=@isbn,acessno=@acessno,btype=@btype,bname=@bname,bauthor=@bauthor,pubyear=@pubyear,edno=@edno,nop=@nop,bprice=@bprice,pdate=@pdate,bcategory=@bcategory,bpubname=@bpubname,bqty=@bqty,bsubtitle=@bsubtitle,bsauthor=@bsauthor,bsource=@bsource,billno=@billno,bcolno=@bcolno,bshelfno=@bshelfno,blang=@blang,qrcode=@qrcode,remark=@remark,Volume_No=@Volume_No,bSubject=@bSubject Where bid = @bid";
               

            SqlCommand command = new SqlCommand(query, connection);

           // Bpdate = Bpdate.Date;

            command.Parameters.AddWithValue("@isbn", Isbn);
            command.Parameters.AddWithValue("@acessno", Bacessno);
            command.Parameters.AddWithValue("@btype", Btype);
            command.Parameters.AddWithValue("@bname", Bname);
            command.Parameters.AddWithValue("@bauthor", Bauthor);
            command.Parameters.AddWithValue("@pubyear", Bpubyear);
            command.Parameters.AddWithValue("@edno", Bedno);
            command.Parameters.AddWithValue("@nop", Bnop);
            command.Parameters.AddWithValue("@bprice", Bprice);
            command.Parameters.AddWithValue("@pdate", Bpdate); 
            command.Parameters.AddWithValue("@bpubname", Bpubname);
            command.Parameters.AddWithValue("@bqty", Bqty);
            command.Parameters.AddWithValue("@bsubtitle", Bsubtitle);
            command.Parameters.AddWithValue("@bsauthor", Bsauthor);
            command.Parameters.AddWithValue("@bsource", Bsource);
            command.Parameters.AddWithValue("@billno", Bbillno);
            command.Parameters.AddWithValue("@bcolno", Bcollno);
            command.Parameters.AddWithValue("@bshelfno", Bshelfno);
            command.Parameters.AddWithValue("@blang", Blang);
            command.Parameters.AddWithValue("@qrcode", qrcode);
            command.Parameters.AddWithValue("@remark", bRemark);
            command.Parameters.AddWithValue("@bid", bid);
            command.Parameters.AddWithValue("@Volume_No",bVolume_No);
            command.Parameters.AddWithValue("@bSubject", bSubject);
            command.Parameters.AddWithValue("@bcategory", Bcategory);




         command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("BookMaster", "Home");
        }









        /************************************************************** Member Matser  Start ******************************************************************************/







        /************************************************************** Member Type Matser  Start ******************************************************************************/





        [Authorize(Roles = "admin")]
        public IActionResult MemberTypeMaster()
        {

          

            string error1  = Request.Query["error1"];
            ViewBag.Error1 = error1;    


            var membertypes = new List<Member_type>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select MTId , MType , Remark from MemberTypeMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                Member_type member_type = new Member_type();
                member_type.Id = (Int32)reader.GetValue(0);

                member_type.Mttype = reader.GetString(1);
                member_type.Mtremark = reader.GetString(2);
                membertypes.Add(member_type);
                ViewData["membertypes"] = membertypes;

            }

            reader.Close();

            connection.Close();

            return View();
        }


        [HttpPost]
        public IActionResult AddMemberType(string MType, string Mremark)
        {


            if(string.IsNullOrEmpty(Mremark))
            {

                Mremark = "";

            }


            if(string.IsNullOrEmpty(MType))
            {
                string msg = "please enter something";
                //Console.WriteLine(MType + "empty Or null");
                return RedirectToAction("MemberTypeMaster", "Home", new { error1 = msg});
            }

          





            else
            {
                SqlConnection connection = new SqlConnection(conn);

                connection.Open();

                string query = "Insert Into MemberTypeMaster (MType,Remark) values(@MType,@Remark)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MType", MType);
                command.Parameters.AddWithValue("@Remark", Mremark);

                command.ExecuteNonQuery();

                connection.Close();

                return RedirectToAction("MemberTypeMaster", "Home");
            }
           
        }





        public IActionResult EditMemberType()
        {

           

            string editid = Request.Query["editid"];

            var membertypes = new List<Member_type>();

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select MTId , MType , Remark from MemberTypeMaster Where mtid=@mtid";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@mtid",editid);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                Member_type member_type = new Member_type();
                member_type.Id = (Int32)reader.GetValue(0);

                member_type.Mttype = reader.GetString(1);
                member_type.Mtremark = reader.GetString(2);
                membertypes.Add(member_type);
                ViewData["membertypes"] = membertypes;

            }

            reader.Close();

            connection.Close();

            return View();
        }



        public IActionResult UpdateMemberType()
        {
            return View();
        }






        [HttpPost]
        public IActionResult UpdateMemberType(string MTId, string MType, string Mremark)
        {

            if (string.IsNullOrEmpty(Mremark))
            {
                Mremark = "";
            }

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Update MemberTypeMaster set  MType = @MType, Remark = @Remark where MTId = @MTId";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@MType", MType);
            command.Parameters.AddWithValue("@Remark", Mremark);
            command.Parameters.AddWithValue("@MTId", MTId);
            command.ExecuteNonQuery();
            sqlConnection.Close();


            return RedirectToAction("MemberTypeMaster", "Home");

        }




        /************************************************************** Member Type Matser  End ******************************************************************************/

        /************************************************************** Member Matser  Start ******************************************************************************/




        [Authorize(Roles = "admin")]
        public IActionResult MemberMaster()
        {

            string message = Request.Query["error"];
            ViewBag.msg = message;

            string success = Request.Query["success"];
            ViewBag.sms = success;

            var mymembers = new List<My_member>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select MId,MName,MType,MGen,MAddress,MClass,MEmail,MMob,MYear,MSection, Remark from MemberMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_member my_member = new My_member();
                my_member.Id = (Int32)reader.GetValue(0);

                my_member.Mname = reader.GetString(1);
                my_member.Mtype = reader.GetString(2);

                my_member.Mgen = reader.GetString(3);
                my_member.Maddr = reader.GetString(4);


                 
                my_member.Mclass = reader.GetString(5);
                my_member.Memail = reader.GetString(6);

                my_member.Mmob = reader.GetString(7);
                my_member.Myear = reader.GetString(8);

                

                my_member.Msection = reader.GetString(9);

                my_member.Mremark = reader.GetString(10);



                mymembers.Add(my_member);
                ViewData["mymembers"] = mymembers;

            }

            reader.Close();







            var membertypes = new List<Member_type>();
            

            string query1 = "Select MTId , MType , Remark from MemberTypeMaster";
            SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
            SqlDataReader reader1 = sqlCommand1.ExecuteReader();
            while (reader1.Read())
            {

                Member_type member_type = new Member_type();
                member_type.Id = (Int32)reader1.GetValue(0);

                member_type.Mttype = reader1.GetString(1);
                member_type.Mtremark = reader1.GetString(2);
                membertypes.Add(member_type);
                ViewData["membertypes"] = membertypes;

            }

            reader1.Close();




            var myclasses = new List<My_class>();


            string query2 = "Select CName from ClassMaster";
            SqlCommand sqlCommand2 = new SqlCommand(query2, connection);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            while (reader2.Read())
            {

                My_class myclass  = new My_class();
                //member_type.Id = (Int32)reader1.GetValue(0);

                myclass.CName = reader2.GetString(0);
                myclasses.Add(myclass);
                ViewData["myclasses"] = myclasses;

            }

            reader2.Close();



            var mysections = new List<My_section>();


            string query3 = "Select SName from SectionMaster";
            SqlCommand sqlCommand3 = new SqlCommand(query3, connection);
            SqlDataReader reader3 = sqlCommand3.ExecuteReader();
            while (reader3.Read())
            {

                My_section mysection = new My_section();
                //member_type.Id = (Int32)reader1.GetValue(0);

                mysection.SName = reader3.GetString(0);
                mysections.Add(mysection);
                ViewData["mysections"] = mysections;

            }

            reader3.Close();




            connection.Close();

            return View();

        }


        [HttpPost]
        public IActionResult AddMember(string mname, string mtype, string mgen,string maddr,string mclass, string memberid, string memail , string mmob,string myear,string msection, string mpassword ,string mremark)
        {

            if (string.IsNullOrEmpty(mremark))
            {
                mremark = "";
            }



            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query1 = "Select Count(*) from MemberMaster Where MemberID = @MemberID";
            SqlCommand command1 = new SqlCommand(query1, connection);


            command1.Parameters.AddWithValue("@MemberID", memberid);
            int count = (Int32)command1.ExecuteScalar();


            if (count > 0)
            {

                return RedirectToAction("MemberMaster", "Home", new { error = "Member Already Exists"});

            }
            else
            {
                string query = "Insert Into MemberMaster (memberid , mpassword,mname,mtype,mgen,maddress,mclass,memail,mmob,myear,msection,remark) values(@memberid,@mpassword,@mname,@mtype,@mgen,@maddress,@mclass,@memail,@mmob,@myear,@msection,@remark)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@memberid", memberid);
                command.Parameters.AddWithValue("@mpassword", mpassword);
                command.Parameters.AddWithValue("@mname", mname);
                command.Parameters.AddWithValue("@mtype", mtype);
                command.Parameters.AddWithValue("@mgen", mgen);
                command.Parameters.AddWithValue("@maddress", maddr);
                command.Parameters.AddWithValue("@mclass", mclass);
                command.Parameters.AddWithValue("@memail", memail);
                command.Parameters.AddWithValue("@mmob", mmob);
                command.Parameters.AddWithValue("@myear", myear);
                command.Parameters.AddWithValue("@msection", msection);
                command.Parameters.AddWithValue("@remark", mremark);

                command.ExecuteNonQuery();
                connection.Close();

                return RedirectToAction("MemberMaster", "Home", new { success = "Member Added Successfully" });

            }

            


        }





        public IActionResult EditMember()
        {

           

            string editid = Request.Query["editid"];



            var mymembers = new List<My_member>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select MId,MName,MType,MGen,MAddress,MClass,MEmail,MMob,MYear,MSection, Remark from MemberMaster Where mid=@mid";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@mid",editid);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_member my_member = new My_member();
                my_member.Id = (Int32)reader.GetValue(0);

                my_member.Mname = reader.GetString(1);
                my_member.Mtype = reader.GetString(2);

                my_member.Mgen = reader.GetString(3);
                my_member.Maddr = reader.GetString(4);



                my_member.Mclass = reader.GetString(5);
                my_member.Memail = reader.GetString(6);

                my_member.Mmob = reader.GetString(7);
                my_member.Myear = reader.GetString(8);



                my_member.Msection = reader.GetString(9);

                my_member.Mremark = reader.GetString(10);



                mymembers.Add(my_member);
                ViewData["mymembers"] = mymembers;

            }



            reader.Close();


            connection.Close();

            return View();
        }



        public IActionResult UpdateMember()
        {
            return View();
        }






        [HttpPost]
        public IActionResult UpdateMember(string mid, string mname, string mtype, string mgen, string maddr, string mclass, string memail, string mmob, string myear, string msection, string mremark)
        {

            if (string.IsNullOrEmpty(mremark))
            {
                mremark = "";
            }

            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Update MemberMaster set  mname = @mname,mtype=@mtype,mgen=@mgen,maddress=@maddress,mclass=@mclass,memail=@memail,mmob=@mmob,myear=@myear,msection=@msection,remark=@remark where mid = @mid";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.AddWithValue("@mname", mname);
            command.Parameters.AddWithValue("@mtype", mtype);
            command.Parameters.AddWithValue("@mgen", mgen);
            command.Parameters.AddWithValue("@maddress", maddr);
            command.Parameters.AddWithValue("@mclass", mclass);
            command.Parameters.AddWithValue("@memail", memail);
            command.Parameters.AddWithValue("@mmob", mmob);
            command.Parameters.AddWithValue("@myear", myear);
            command.Parameters.AddWithValue("@msection", msection);
            command.Parameters.AddWithValue("@remark", mremark);
            command.Parameters.AddWithValue("@mid", mid);
            command.ExecuteNonQuery();
            sqlConnection.Close();


            return RedirectToAction("MemberMaster", "Home");

        }









        /************************************************************** Member Matser  End ******************************************************************************/


        /************************************************************** Department Matser Start ******************************************************************************/


        public IActionResult DepartmentMaster()
        {


            return View();

        }


        public IActionResult AddDepartment()
        {

            return View();

        }




        public IActionResult UpdateDepartment()
        {

            return View();

        }


        /************************************************************** Department Matser  End ******************************************************************************/












        public IActionResult FineMaster()
        {
            return View();
        }




        [Authorize(Roles = "admin")]
        public IActionResult CollegeReport()
        {

            var colleges = new List<College>();
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "Select CId ,CName,CAddress,CContact,CPerson,CEmail,CMob from CollegeMaster";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                College college = new College();
                college.Id = (Int32)reader.GetValue(0);
                college.ColName = reader.GetString(1);
                college.Coladdr = reader.GetString(2);
                college.Colmobile = reader.GetString(3);
                college.Conpername = reader.GetString(4);
                college.Coperemail = reader.GetString(5);
                college.Conpermobie = reader.GetString(6);

                colleges.Add(college);

                ViewData["colleges"] = colleges;

            }

            return View();
        }



        [Authorize(Roles = "admin")]
        public IActionResult SessionReport()
        {
            var mysessions = new List<My_session>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select SId , SName , Remark from SessionMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_session my_Session = new My_session();
                my_Session.Id = (Int32)reader.GetValue(0);

                my_Session.SName = reader.GetString(1);
                my_Session.Sremark = reader.GetString(2);
                mysessions.Add(my_Session);
                ViewData["mysessions"] = mysessions;

            }

            reader.Close();

            connection.Close();



            return View();

        }


        [Authorize(Roles = "admin")]
        public IActionResult SectionReport()
        {

            var mysections = new List<My_section>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select SId , CName , Sname, Remark from SectionMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_section my_section = new My_section();
                my_section.Id = (Int32)reader.GetValue(0);

                my_section.CName = reader.GetString(1);
                my_section.SName = reader.GetString(2);
                my_section.Sremark = reader.GetString(3);
                mysections.Add(my_section);
                ViewData["mysections"] = mysections;

            }

            reader.Close();

            connection.Close();
            return View();

        }



        [Authorize(Roles = "admin")]
        public IActionResult ClassReport()
        {

            var myclasses = new List<My_class>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select CId , CName , Remark from ClassMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_class my_class = new My_class();
                my_class.Id = (Int32)reader.GetValue(0);

                my_class.CName = reader.GetString(1);
                my_class.Cremark = reader.GetString(2);
                myclasses.Add(my_class);
                ViewData["myclasses"] = myclasses;

            }

            reader.Close();

            connection.Close();


            return View();

        }


        [Authorize(Roles = "admin")]

        public IActionResult MemberReport()
        {

            var mymembers = new List<My_member>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select MId,MName,MType,MGen,MAddress,MClass,MEmail,MMob,MYear,MSection, Remark from MemberMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                My_member my_member = new My_member();
                my_member.Id = (Int32)reader.GetValue(0);

                my_member.Mname = reader.GetString(1);
                my_member.Mtype = reader.GetString(2);

                my_member.Mgen = reader.GetString(3);
                my_member.Maddr = reader.GetString(4);



                my_member.Mclass = reader.GetString(5);
                my_member.Memail = reader.GetString(6);

                my_member.Mmob = reader.GetString(7);
                my_member.Myear = reader.GetString(8);



                my_member.Msection = reader.GetString(9);

                my_member.Mremark = reader.GetString(10);



                mymembers.Add(my_member);
                ViewData["mymembers"] = mymembers;

            }

            reader.Close();




            return View();

        }

        [Authorize(Roles = "admin")]
        public IActionResult MemberTypeReport()
        {
            var membertypes = new List<Member_type>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select MTId , MType , Remark from MemberTypeMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                Member_type member_type = new Member_type();
                member_type.Id = (Int32)reader.GetValue(0);

                member_type.Mttype = reader.GetString(1);
                member_type.Mtremark = reader.GetString(2);
                membertypes.Add(member_type);
                ViewData["membertypes"] = membertypes;

            }

            reader.Close();

            connection.Close();

            return View();

        }



        [Authorize(Roles = "admin")]
        public IActionResult BookReport()
        {
            var books = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Mybooks mybooks = new Mybooks();
                mybooks.Id = (Int32)reader.GetValue(0);
                mybooks.Isbn = reader.GetString(1);
                mybooks.Bacessno = reader.GetString(2);
                mybooks.Btype = reader.GetString(3);
                mybooks.Bname = reader.GetString(4);
                mybooks.Bauthor = reader.GetString(5);
                mybooks.Bpubyear = reader.GetString(6);
                mybooks.Bedno = reader.GetString(7);
                mybooks.Bnop = reader.GetString(8);
                mybooks.Bprice = reader.GetString(9);
                mybooks.Bpdate = (DateTime)reader.GetValue(10);
                mybooks.Btitle = reader.GetString(11);
                mybooks.Bpubname = reader.GetString(12);
                mybooks.Bqty = (Int32)reader.GetValue(13);
                mybooks.Bsubtitle = reader.GetString(14);
                mybooks.Bsauthor = reader.GetString(15);
                mybooks.Bsource = reader.GetString(16);
                mybooks.Bbillno = reader.GetString(17);
                mybooks.Bcollno = reader.GetString(18);
                mybooks.Bshelfno = reader.GetString(19);
                mybooks.Blang = reader.GetString(20);
                mybooks.qrcode = reader.GetString(21);
                mybooks.bRemark = reader.GetString(22);
                books.Add(mybooks);
                ViewData["books"] = books;


            }

            reader.Close();
            connection.Close();

            return View();

        }



        [Authorize(Roles = "admin")]
        public IActionResult BookCategoryReport()
        {

            var bookcategories = new List<BookCategory>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "Select BCId , CName , Remark from BookCategoryMaster";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

                BookCategory my_class = new BookCategory();
                my_class.Id = (Int32)reader.GetValue(0);

                my_class.Bcname = reader.GetString(1);
                my_class.Bcremark = reader.GetString(2);
                bookcategories.Add(my_class);
                ViewData["bookcategories"] = bookcategories;

            }

            reader.Close();

            connection.Close();

            return View();

        }



        public IActionResult FineReport()
        {


            return View();

        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        ///////////////////////////////////////////////////////transaction start here////////////////////////////////////////////

        [Authorize(Roles = "admin")]
        public IActionResult IssueBook()
        {

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            var BookCookie = Request.Cookies["IssueBooks"];

            var MemberCookie = Request.Cookies["IssueMembers"];


           


            if (MemberCookie == null || MemberCookie.Length == 0)
            {


                Console.WriteLine("nothing in Members");

            }

            else
            {



                var mymembers = new List<My_member>();
               
                var memberids = MemberCookie.Split('-');

                for (int i = 0; i < memberids.Length; i++)
                {




                    string query1 = "Select MId,MName,MType,MGen,MAddress,MClass,MEmail,MMob,MYear,MSection, Remark from MemberMaster where MId=@MId";
                    SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
                    sqlCommand1.Parameters.AddWithValue("@MId", memberids[i]);
                    SqlDataReader reader1 = sqlCommand1.ExecuteReader();

                    while (reader1.Read())
                    {

                        My_member my_member = new My_member();
                        my_member.Id = (Int32)reader1.GetValue(0);

                        my_member.Mname = reader1.GetString(1);
                        my_member.Mtype = reader1.GetString(2);

                        my_member.Mgen = reader1.GetString(3);
                        my_member.Maddr = reader1.GetString(4);



                        my_member.Mclass = reader1.GetString(5);
                        my_member.Memail = reader1.GetString(6);

                        my_member.Mmob = reader1.GetString(7);
                        my_member.Myear = reader1.GetString(8);



                        my_member.Msection = reader1.GetString(9);

                        my_member.Mremark = reader1.GetString(10);



                        mymembers.Add(my_member);
                        ViewData["mymembers"] = mymembers;

                    }

                    reader1.Close();

                   




                }

            }

            if (BookCookie == null || BookCookie.Length == 0)
            {


                Console.WriteLine("nothing in Books");

            }

            else
            {
                //Console.WriteLine(Request.Cookies["IssueBooks"]);


                var books = new List<Mybooks>();
                //Dictionary<int, int> frequency = new Dictionary<int, int>();
                var bookids = BookCookie.Split('-');
               // List<string> pIDs = productsids.Select(x => int.Parse(x)).ToList();

                for (int i = 0; i < bookids.Length; i++)
                {
                 
                    Console.WriteLine(bookids[i]);
                   

                    string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster Where bid = @isbn";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@isbn", bookids[i]);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Mybooks mybooks = new Mybooks();
                        mybooks.Id = (Int32)reader.GetValue(0);
                        mybooks.Isbn = reader.GetString(1);
                        mybooks.Bacessno = reader.GetString(2);
                        mybooks.Btype = reader.GetString(3);
                        mybooks.Bname = reader.GetString(4);
                        mybooks.Bauthor = reader.GetString(5);
                        mybooks.Bpubyear = reader.GetString(6);
                        mybooks.Bedno = reader.GetString(7);
                        mybooks.Bnop = reader.GetString(8);
                        mybooks.Bprice = reader.GetString(9);
                        mybooks.Bpdate = (DateTime)reader.GetValue(10);
                        mybooks.Btitle = reader.GetString(11);
                        mybooks.Bpubname = reader.GetString(12);
                        mybooks.Bqty = (Int32)reader.GetValue(13);
                        mybooks.Bsubtitle = reader.GetString(14);
                        mybooks.Bsauthor = reader.GetString(15);
                        mybooks.Bsource = reader.GetString(16);
                        mybooks.Bbillno = reader.GetString(17);
                        mybooks.Bcollno = reader.GetString(18);
                        mybooks.Bshelfno = reader.GetString(19);
                        mybooks.Blang = reader.GetString(20);
                        mybooks.qrcode = reader.GetString(21);
                        mybooks.bRemark = reader.GetString(22);
                        books.Add(mybooks);
                        ViewData["books"] = books;


                    }

                    reader.Close();






                }
            }

            connection.Close();

            return View();
        }



        public IActionResult AddIssueBook()
       {

            var BookCookie = Request.Cookies["IssueBooks"];

            string memberid = Request.Query["memid"];

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select mname from membermaster where mid = @mid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@mid",memberid);

            string membername = (string)command.ExecuteScalar();
            ViewBag.membername = membername;
           


            if (BookCookie == null || BookCookie.Length == 0)
            {


                //Console.WriteLine("nothing in Books");
                return RedirectToAction("IssueBook", "Home");

            }
            else
            {
                var books = new List<Mybooks>();
                var bookids = BookCookie.Split('-');
                var bkid = "";
                for (int i = 0; i < bookids.Length; i++)
                {



                    //string query1 = "Select  bid from  BookMaster Where AcessNo = @isbn";
                    //SqlCommand command1 = new SqlCommand(query1, connection);
                    //command1.Parameters.AddWithValue("@isbn", bookids[i]);
                    //bkid = (Int32)command1.ExecuteScalar();

                    bkid = bookids[i];
                   

                    // Console.WriteLine("relative id"+bkid); 

                    string query2 = "Select bname,acessno,bprice from bookmaster where bid = @isbn";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@isbn", bookids[i]);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {

                        Mybooks book = new Mybooks();

                        book.Bname = reader2.GetString(0);
                        book.Bacessno = reader2.GetString(1);
                        book.Bprice = reader2.GetString(2);

                        books.Add(book);

                        ViewData["books"] = books;


                    }
                    reader2.Close();

                }

               Console.WriteLine("quantity of books issued"+bookids.Length);

                string query3 = "Select Convert(varchar(30),bidate,34),bissuedby,Convert(varchar(30),brtdate,34) from bookissuemaster where bid = @bid";
                SqlCommand command3 = new SqlCommand(query3,connection);
                command3.Parameters.AddWithValue("@bid",bkid);

               SqlDataReader reader3 = command3.ExecuteReader();
                while(reader3.Read())
                {


                    ViewBag.bidate = reader3.GetValue(0);
                    ViewBag.bissuedby = reader3.GetValue(1);
                    ViewBag.brtdate = reader3.GetValue(2);

                }

                reader3.Close();

            }







            connection.Close();
            return View();


        }


        [HttpPost]
        public IActionResult AddIssueBook(DateTime Bexdate, string Issuedby, string Biremark)
        {
            //Console.WriteLine(mid);
            string memid = "";

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            if (string.IsNullOrEmpty(Biremark))
            {
                Biremark = "";
            }


       
                Bexdate = Bexdate.Date;
                DateTime Issueddt = DateTime.Now;
                Issueddt = Issueddt.Date;


            var BookCookie = Request.Cookies["IssueBooks"];

            var MemberCookie = Request.Cookies["IssueMembers"];

            if (MemberCookie == null || MemberCookie.Length == 0)
            {

                // Console.WriteLine("nothing in Members");

                return RedirectToAction("IssueBook","Home");


            }
            else
            {
                var memberids = MemberCookie.Split('-');

                string miid = memberids[0];
                memid = miid;

                if (BookCookie == null || BookCookie.Length == 0)
                {


                    //Console.WriteLine("nothing in Books");
                    return RedirectToAction("IssueBook", "Home");

                }
                else
                {



                   
            
                    var bookids = BookCookie.Split('-');
                   

                    for (int i = 0; i < bookids.Length; i++)
                    {



                        //string query = "Select  bid from  BookMaster Where AcessNo = @isbn";
                        //SqlCommand command = new SqlCommand(query, connection);
                        //command.Parameters.AddWithValue("@isbn", bookids[i]);
                        //int bkid = (Int32)command.ExecuteScalar();
                        var bkid = bookids[i];
                        // Console.WriteLine("relative id"+bkid); 

                        string query1 = "Insert into BookIssueMaster(bid,mid,bqty,bidate,bexdate,brtdate,bstatus,remark,bissuedby) values(@bid,@mid,@bqty,@bidate,@bexdate,@brtdate,@bstatus,@remark,@bissuedby)";
                        SqlCommand command1 = new SqlCommand(query1, connection);
                        command1.Parameters.AddWithValue("@bid",bkid);
                        command1.Parameters.AddWithValue("@mid", miid);
                        command1.Parameters.AddWithValue("@bqty",1);
                        command1.Parameters.AddWithValue("@bidate",Issueddt);
                        command1.Parameters.AddWithValue("@bexdate",Bexdate);
                        command1.Parameters.AddWithValue("@brtdate",Bexdate);
                        command1.Parameters.AddWithValue("@bstatus",0);
                        command1.Parameters.AddWithValue("@remark",Biremark);
                        command1.Parameters.AddWithValue("@bissuedby",Issuedby);

                        command1.ExecuteNonQuery();

                        int biqty = 0;
                        int baqty = 0;
                        string query2 = "select biqty, baqty from BookMaster where bid = @bid";

                        SqlCommand command2 = new SqlCommand(query2,connection);

                        command2.Parameters.AddWithValue("@bid",bkid);

                        SqlDataReader reader = command2.ExecuteReader();

                        while (reader.Read())
                        {

                            biqty = (int)reader.GetValue(0);
                            baqty = (int)reader.GetValue(1);

                        }



                        reader.Close();


                        string query3 = "update bookmaster set biqty=@biqty, baqty=@baqty where bid = @bid";

                        SqlCommand command3 = new SqlCommand(query3, connection);

                        command3.Parameters.AddWithValue("@biqty",biqty+1);
                        command3.Parameters.AddWithValue("@baqty", baqty-1);
                        command3.Parameters.AddWithValue("@bid",bkid);

                        command3.ExecuteNonQuery();




                    }



                    }

            }

            


                connection.Close();

            return RedirectToAction("AddIssueBook", "Home" ,new { memid = memid});
            

          
        }

        [Authorize(Roles = "admin")]
        public IActionResult ReturnBook()
        {

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            var BookCookie = Request.Cookies["ReturnBooks"];

            var MemberCookie = Request.Cookies["ReturnMembers"];





            if (MemberCookie == null || MemberCookie.Length == 0)
            {


                Console.WriteLine("nothing in Members");

            }

            else
            {



                var mymembers = new List<My_member>();

                var memberids = MemberCookie.Split('-');

                for (int i = 0; i < memberids.Length; i++)
                {




                    string query1 = "Select MId,MName,MType,MGen,MAddress,MClass,MEmail,MMob,MYear,MSection, Remark from MemberMaster where MId=@MId";
                    SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
                    sqlCommand1.Parameters.AddWithValue("@MId", memberids[i]);
                    SqlDataReader reader1 = sqlCommand1.ExecuteReader();

                    while (reader1.Read())
                    {

                        My_member my_member = new My_member();
                        my_member.Id = (Int32)reader1.GetValue(0);

                        my_member.Mname = reader1.GetString(1);
                        my_member.Mtype = reader1.GetString(2);

                        my_member.Mgen = reader1.GetString(3);
                        my_member.Maddr = reader1.GetString(4);



                        my_member.Mclass = reader1.GetString(5);
                        my_member.Memail = reader1.GetString(6);

                        my_member.Mmob = reader1.GetString(7);
                        my_member.Myear = reader1.GetString(8);



                        my_member.Msection = reader1.GetString(9);

                        my_member.Mremark = reader1.GetString(10);



                        mymembers.Add(my_member);
                        ViewData["mymembers"] = mymembers;

                    }

                    reader1.Close();






                }

            }

            if (BookCookie == null || BookCookie.Length == 0)
            {


                Console.WriteLine("nothing in Books");

            }

            else
            {
                //Console.WriteLine(Request.Cookies["IssueBooks"]);


                var books = new List<Mybooks>();
                //Dictionary<int, int> frequency = new Dictionary<int, int>();
                var bookids = BookCookie.Split('-');
                // List<string> pIDs = productsids.Select(x => int.Parse(x)).ToList();

                for (int i = 0; i < bookids.Length; i++)
                {

                    Console.WriteLine(bookids[i]);


                    string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster Where bid = @isbn";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@isbn", bookids[i]);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Mybooks mybooks = new Mybooks();
                        mybooks.Id = (Int32)reader.GetValue(0);
                        mybooks.Isbn = reader.GetString(1);
                        mybooks.Bacessno = reader.GetString(2);
                        mybooks.Btype = reader.GetString(3);
                        mybooks.Bname = reader.GetString(4);
                        mybooks.Bauthor = reader.GetString(5);
                        mybooks.Bpubyear = reader.GetString(6);
                        mybooks.Bedno = reader.GetString(7);
                        mybooks.Bnop = reader.GetString(8);
                        mybooks.Bprice = reader.GetString(9);
                        mybooks.Bpdate = (DateTime)reader.GetValue(10);
                        mybooks.Btitle = reader.GetString(11);
                        mybooks.Bpubname = reader.GetString(12);
                        mybooks.Bqty = (Int32)reader.GetValue(13);
                        mybooks.Bsubtitle = reader.GetString(14);
                        mybooks.Bsauthor = reader.GetString(15);
                        mybooks.Bsource = reader.GetString(16);
                        mybooks.Bbillno = reader.GetString(17);
                        mybooks.Bcollno = reader.GetString(18);
                        mybooks.Bshelfno = reader.GetString(19);
                        mybooks.Blang = reader.GetString(20);
                        mybooks.qrcode = reader.GetString(21);
                        mybooks.bRemark = reader.GetString(22);
                        books.Add(mybooks);
                        ViewData["books"] = books;


                    }

                    reader.Close();






                }
            }

            connection.Close();

            return View();
        }



        public IActionResult AddReturnBook()
        {

            var BookCookie = Request.Cookies["ReturnBooks"];

            string memberid = Request.Query["memid"];

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select mname from membermaster where mid = @mid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@mid", memberid);

            string membername = (string)command.ExecuteScalar();
            ViewBag.membername = membername;



            if (BookCookie == null || BookCookie.Length == 0)
            {


                //Console.WriteLine("nothing in Books");
                return RedirectToAction("ReturnBook", "Home");

            }
            else
            {
                var books = new List<Mybooks>();
                var bookids = BookCookie.Split('-');
                var bkid = "";
                for (int i = 0; i < bookids.Length; i++)
                {



                    //string query1 = "Select  bid from  BookMaster Where AcessNo = @isbn";
                    //SqlCommand command1 = new SqlCommand(query1, connection);
                    //command1.Parameters.AddWithValue("@isbn", bookids[i]);
                    //bkid = (Int32)command1.ExecuteScalar();

                    bkid = bookids[i];

                    // Console.WriteLine("relative id"+bkid); 

                    string query2 = "Select bname,acessno,bprice from bookmaster where bid = @bid";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@bid", bkid);
                    SqlDataReader reader = command2.ExecuteReader();
                    while (reader.Read())
                    {

                        Mybooks book = new Mybooks();

                        book.Bname = reader.GetString(0);
                        book.Bacessno = reader.GetString(1);
                        book.Bprice = reader.GetString(2);

                        books.Add(book);

                        ViewData["books"] = books;


                    }
                    reader.Close();

                }



                string query3 = "Select Convert(varchar(30),bidate,34),bissuedby,Convert(varchar(30),brtdate,34) from bookissuemaster where bid = @bid";
                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@bid", bkid);

                SqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {


                    ViewBag.bidate = reader3.GetValue(0);
                    ViewBag.bissuedby = reader3.GetValue(1);
                    ViewBag.brtdate = reader3.GetValue(2);

                }

                reader3.Close();

            }







            connection.Close();
            return View();


        }








        [HttpPost]
        public IActionResult AddReturnBook(string Biremark)
        {
            //Console.WriteLine(mid);
            string memid = "";

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            if (string.IsNullOrEmpty(Biremark))
            {
                Biremark = "";
            }



           
            DateTime Brtdate = DateTime.Now;
            Brtdate = Brtdate.Date;


            var BookCookie = Request.Cookies["ReturnBooks"];

            var MemberCookie = Request.Cookies["ReturnMembers"];

            if (MemberCookie == null || MemberCookie.Length == 0)
            {

                // Console.WriteLine("nothing in Members");

                return RedirectToAction("ReturnBook", "Home");


            }
            else
            {
                var memberids = MemberCookie.Split('-');

                string miid = memberids[0];
                memid = miid;

                if (BookCookie == null || BookCookie.Length == 0)
                {


                    //Console.WriteLine("nothing in Books");
                    return RedirectToAction("ReturnBook", "Home");

                }
                else
                {





                    var bookids = BookCookie.Split('-');


                    for (int i = 0; i < bookids.Length; i++)
                    {



                        //string query = "Select  bid from  BookMaster Where AcessNo = @isbn";
                        //SqlCommand command = new SqlCommand(query, connection);
                        //command.Parameters.AddWithValue("@isbn", bookids[i]);
                        //int bkid = (Int32)command.ExecuteScalar();

                        var bkid = bookids[i];

                        //Console.WriteLine("relative id" + bkid);

                        string query1 = "Update BookIssueMaster set brtdate = @brtdate, bstatus=@bstatus,remark = @remark where bid=@bid and mid=@mid and bstatus=@bstatus1";
                        SqlCommand command1 = new SqlCommand(query1, connection);
                        command1.Parameters.AddWithValue("@brtdate",Brtdate);
                        command1.Parameters.AddWithValue("@bstatus", 1);
                        command1.Parameters.AddWithValue("@remark", Biremark);
                        command1.Parameters.AddWithValue("@bid", bkid);
                        command1.Parameters.AddWithValue("@mid", memid);
                        command1.Parameters.AddWithValue("@bstatus1", 0);
                        command1.ExecuteNonQuery();



                        int biqty = 0;
                        int baqty = 0;
                        string query2 = "select biqty, baqty from BookMaster where bid = @bid";

                        SqlCommand command2 = new SqlCommand(query2, connection);

                        command2.Parameters.AddWithValue("@bid", bkid);

                        SqlDataReader reader = command2.ExecuteReader();

                        while (reader.Read())
                        {

                            biqty = (int)reader.GetValue(0);
                            baqty = (int)reader.GetValue(1);

                        }



                        reader.Close();


                        string query3 = "update bookmaster set biqty=@biqty, baqty=@baqty where bid = @bid";

                        SqlCommand command3 = new SqlCommand(query3, connection);

                        command3.Parameters.AddWithValue("@biqty", biqty - 1);
                        command3.Parameters.AddWithValue("@baqty", baqty + 1);
                        command3.Parameters.AddWithValue("@bid", bkid);

                        command3.ExecuteNonQuery();




                    }



                }

            }




            connection.Close();

            return RedirectToAction("AddReturnBook", "Home", new { memid = memid});



        }


        [Authorize(Roles = "admin")]
        public IActionResult Re_IssueBook()
        {

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            var BookCookie = Request.Cookies["ReIssueBooks"];

            var MemberCookie = Request.Cookies["ReIssueMembers"];





            if (MemberCookie == null || MemberCookie.Length == 0)
            {


                Console.WriteLine("nothing in Members");

            }

            else
            {



                var mymembers = new List<My_member>();

                var memberids = MemberCookie.Split('-');

                for (int i = 0; i < memberids.Length; i++)
                {




                    string query1 = "Select MId,MName,MType,MGen,MAddress,MClass,MEmail,MMob,MYear,MSection, Remark from MemberMaster where MId=@MId";
                    SqlCommand sqlCommand1 = new SqlCommand(query1, connection);
                    sqlCommand1.Parameters.AddWithValue("@MId", memberids[i]);
                    SqlDataReader reader1 = sqlCommand1.ExecuteReader();

                    while (reader1.Read())
                    {

                        My_member my_member = new My_member();
                        my_member.Id = (Int32)reader1.GetValue(0);

                        my_member.Mname = reader1.GetString(1);
                        my_member.Mtype = reader1.GetString(2);

                        my_member.Mgen = reader1.GetString(3);
                        my_member.Maddr = reader1.GetString(4);



                        my_member.Mclass = reader1.GetString(5);
                        my_member.Memail = reader1.GetString(6);

                        my_member.Mmob = reader1.GetString(7);
                        my_member.Myear = reader1.GetString(8);



                        my_member.Msection = reader1.GetString(9);

                        my_member.Mremark = reader1.GetString(10);



                        mymembers.Add(my_member);
                        ViewData["mymembers"] = mymembers;

                    }

                    reader1.Close();






                }

            }

            if (BookCookie == null || BookCookie.Length == 0)
            {


                Console.WriteLine("nothing in Books");

            }

            else
            {
                //Console.WriteLine(Request.Cookies["IssueBooks"]);


                var books = new List<Mybooks>();
                //Dictionary<int, int> frequency = new Dictionary<int, int>();
                var bookids = BookCookie.Split('-');
                // List<string> pIDs = productsids.Select(x => int.Parse(x)).ToList();

                for (int i = 0; i < bookids.Length; i++)
                {

                    Console.WriteLine(bookids[i]);


                    string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster Where bid = @isbn";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@isbn", bookids[i]);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Mybooks mybooks = new Mybooks();
                        mybooks.Id = (Int32)reader.GetValue(0);
                        mybooks.Isbn = reader.GetString(1);
                        mybooks.Bacessno = reader.GetString(2);
                        mybooks.Btype = reader.GetString(3);
                        mybooks.Bname = reader.GetString(4);
                        mybooks.Bauthor = reader.GetString(5);
                        mybooks.Bpubyear = reader.GetString(6);
                        mybooks.Bedno = reader.GetString(7);
                        mybooks.Bnop = reader.GetString(8);
                        mybooks.Bprice = reader.GetString(9);
                        mybooks.Bpdate = (DateTime)reader.GetValue(10);
                        mybooks.Btitle = reader.GetString(11);
                        mybooks.Bpubname = reader.GetString(12);
                        mybooks.Bqty = (Int32)reader.GetValue(13);
                        mybooks.Bsubtitle = reader.GetString(14);
                        mybooks.Bsauthor = reader.GetString(15);
                        mybooks.Bsource = reader.GetString(16);
                        mybooks.Bbillno = reader.GetString(17);
                        mybooks.Bcollno = reader.GetString(18);
                        mybooks.Bshelfno = reader.GetString(19);
                        mybooks.Blang = reader.GetString(20);
                        mybooks.qrcode = reader.GetString(21);
                        mybooks.bRemark = reader.GetString(22);
                        books.Add(mybooks);
                        ViewData["books"] = books;


                    }

                    reader.Close();






                }
            }

            connection.Close();

            return View();
        }



        public IActionResult AddRe_IssueBook()
        {

            var BookCookie = Request.Cookies["ReIssueBooks"];

            string memberid = Request.Query["memid"];

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select mname from membermaster where mid = @mid";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@mid", memberid);

            string membername = (string)command.ExecuteScalar();
            ViewBag.membername = membername;



            if (BookCookie == null || BookCookie.Length == 0)
            {


                //Console.WriteLine("nothing in Books");
                return RedirectToAction("Re_IssueBook", "Home");

            }
            else
            {
                var books = new List<Mybooks>();
                var bookids = BookCookie.Split('-');
                var bkid = "";
                for (int i = 0; i < bookids.Length; i++)
                {



                    //string query1 = "Select  bid from  BookMaster Where AcessNo = @isbn";
                    //SqlCommand command1 = new SqlCommand(query1, connection);
                    //command1.Parameters.AddWithValue("@isbn", bookids[i]);
                    //bkid = (Int32)command1.ExecuteScalar();


                    bkid = bookids[i];

                    // Console.WriteLine("relative id"+bkid); 

                    string query2 = "Select bname,acessno,bprice from bookmaster where bid = @isbn";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@isbn", bookids[i]);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {

                        Mybooks book = new Mybooks();

                        book.Bname = reader2.GetString(0);
                        book.Bacessno = reader2.GetString(1);
                        book.Bprice = reader2.GetString(2);

                        books.Add(book);

                        ViewData["books"] = books;


                    }
                    reader2.Close();

                }

                Console.WriteLine("quantity of books issued" + bookids.Length);

                string query3 = "Select Convert(varchar(30),bidate,34),bissuedby,Convert(varchar(30),brtdate,34) from bookissuemaster where bid = @bid";
                SqlCommand command3 = new SqlCommand(query3, connection);
                command3.Parameters.AddWithValue("@bid", bkid);

                SqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {


                    ViewBag.bidate = reader3.GetValue(0);
                    ViewBag.bissuedby = reader3.GetValue(1);
                    ViewBag.brtdate = reader3.GetValue(2);

                }

                reader3.Close();

            }







            connection.Close();
            return View();


        }

        [HttpPost]
        public IActionResult AddRe_IssueBook(DateTime bexdate, string bissuedby, string Biremark)
        {
            //Console.WriteLine(mid);
            string memid = "";

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            if (string.IsNullOrEmpty(Biremark))
            {
                Biremark = "";
            }




            DateTime Brtdate = DateTime.Now;
            Brtdate = Brtdate.Date;


            var BookCookie = Request.Cookies["ReIssueBooks"];

            var MemberCookie = Request.Cookies["ReIssueMembers"];

            if (MemberCookie == null || MemberCookie.Length == 0)
            {

                // Console.WriteLine("nothing in Members");

                return RedirectToAction("Re_IssueBook", "Home");


            }
            else
            {
                var memberids = MemberCookie.Split('-');

                string miid = memberids[0];
                memid = miid;

                if (BookCookie == null || BookCookie.Length == 0)
                {


                    //Console.WriteLine("nothing in Books");
                    return RedirectToAction("Re_IssueBook", "Home");

                }
                else
                {





                    var bookids = BookCookie.Split('-');


                    for (int i = 0; i < bookids.Length; i++)
                    {



                        //string query = "Select  bid from  BookMaster Where AcessNo = @isbn";
                        //SqlCommand command = new SqlCommand(query, connection);
                        //command.Parameters.AddWithValue("@isbn", bookids[i]);
                        //int bkid = (Int32)command.ExecuteScalar();

                        var bkid = bookids[i];

                        //Console.WriteLine("relative id" + bkid);

                        string query1 = "Update BookIssueMaster set brtdate = @brtdate, bstatus=@bstatus,remark = @remark where bid=@bid and mid=@mid and bstatus=@bstatus1";
                        SqlCommand command1 = new SqlCommand(query1, connection);
                        command1.Parameters.AddWithValue("@brtdate", Brtdate);
                        command1.Parameters.AddWithValue("@bstatus", 1);
                        command1.Parameters.AddWithValue("@remark", Biremark);
                        command1.Parameters.AddWithValue("@bid", bkid);
                        command1.Parameters.AddWithValue("@mid", memid);
                        command1.Parameters.AddWithValue("@bstatus1", 0);
                        command1.ExecuteNonQuery();



                    }


                    for (int i = 0; i < bookids.Length; i++)
                    {

                        DateTime Issueddt = DateTime.Now;
                        Issueddt = Issueddt.Date;


                        //string query2 = "Select  bid from  BookMaster Where AcessNo = @isbn";
                        //SqlCommand command2 = new SqlCommand(query2, connection);
                        //command2.Parameters.AddWithValue("@isbn", bookids[i]);
                        //int bkid = (Int32)command2.ExecuteScalar();

                        var bkid = bookids[i];

                        // Console.WriteLine("relative id"+bkid); 

                        string query3 = "Insert into BookIssueMaster(bid,mid,bqty,bidate,bexdate,brtdate,bstatus,remark,bissuedby) values(@bid,@mid,@bqty,@bidate,@bexdate,@brtdate,@bstatus,@remark,@bissuedby)";
                        SqlCommand command3 = new SqlCommand(query3, connection);
                        command3.Parameters.AddWithValue("@bid", bkid);
                        command3.Parameters.AddWithValue("@mid", miid);
                        command3.Parameters.AddWithValue("@bqty", 1);
                        command3.Parameters.AddWithValue("@bidate", Issueddt);
                        command3.Parameters.AddWithValue("@bexdate", bexdate);
                        command3.Parameters.AddWithValue("@brtdate", bexdate);
                        command3.Parameters.AddWithValue("@bstatus", 0);
                        command3.Parameters.AddWithValue("@remark", Biremark);
                        command3.Parameters.AddWithValue("@bissuedby", bissuedby);

                        command3.ExecuteNonQuery();



                    }



                }

            }




            connection.Close();

            return RedirectToAction("AddRe_IssueBook", "Home", new { memid = memid });

            //return View("Index","Home");


        }

        [Authorize(Roles = "admin")]
        public IActionResult IssuedBooks()
        {
            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select  BM.acessno, BM.BName, BM.BAuthor, BM.edno, BM.bprice,BM.blang, Convert(varchar(30),BIM.BIDate,34),Convert(varchar(30),BIM.bexdate,34),MM.MName  from BookIssueMaster BIM, BookMaster BM, MemberMaster MM where BIM.BId = BM.BId and BIM.bstatus = 0 and BIM.MId = MM.MId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Mybooks> issuedbooks = new List<Mybooks>();

            while (reader.Read())
            {

                Mybooks issuedbook = new Mybooks();

                issuedbook.Bacessno = reader.GetString(0);
                issuedbook.Bname = reader.GetString(1);
                issuedbook.Bauthor = reader.GetString(2);
                issuedbook.Bedno = reader.GetString(3);
                issuedbook.Bprice = reader.GetString(4);
                // mybook.Bpubname = reader.GetString(6);
                // mybook.Bqty = (Int32)reader.GetValue(7);
                // mybook.Bbillno = reader.GetString(8);
                // mybook.Bshelfno = reader.GetString(9);
                issuedbook.Blang = reader.GetString(5);
                issuedbook.isdate = reader.GetString(6);
                issuedbook.rtdate = reader.GetString(7);
                issuedbook.mname = reader.GetString(8);
                issuedbooks.Add(issuedbook);
                ViewData["issuedbooks"] = issuedbooks;

            }

            reader.Close();
            
            sqlConnection.Close();      


            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult IssuedBooksReport()
        {


            SqlConnection sqlConnection = new SqlConnection(conn);
            sqlConnection.Open();
            string query = "select BM.bid,  BM.acessno, BM.BName, BM.BAuthor, BM.edno, BM.bprice,BM.blang, Convert(varchar(30),BIM.BIDate,34),Convert(varchar(30),BIM.bexdate,34),MM.MName  from BookIssueMaster BIM, BookMaster BM, MemberMaster MM where BIM.BId = BM.BId and BIM.bstatus = 0 and BIM.MId = MM.MId";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Mybooks> issuedbooks = new List<Mybooks>();

            while (reader.Read())
            {

                Mybooks issuedbook = new Mybooks();
                issuedbook.Id = (Int32)reader.GetValue(0);
                issuedbook.Bacessno = reader.GetString(1);
                issuedbook.Bname = reader.GetString(2);
                issuedbook.Bauthor = reader.GetString(3);
                issuedbook.Bedno = reader.GetString(4);
                issuedbook.Bprice = reader.GetString(5);
                // mybook.Bpubname = reader.GetString(6);
                // mybook.Bqty = (Int32)reader.GetValue(7);
                // mybook.Bbillno = reader.GetString(8);
                // mybook.Bshelfno = reader.GetString(9);
                issuedbook.Blang = reader.GetString(6);
                issuedbook.isdate = reader.GetString(7);
                issuedbook.rtdate = reader.GetString(8);
                issuedbook.mname = reader.GetString(9);
                issuedbooks.Add(issuedbook);
                ViewData["issuedbooks"] = issuedbooks;

            }

            reader.Close();

            sqlConnection.Close();


            return View();



        }








        [Authorize(Roles = "admin")]
        public IActionResult RuleMaster()
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string rquery = "select rid, class,section,fine,noofrenew,department,session,delayfine,loanperiod,noi,regards,renewperiod from rulemaster";
            SqlCommand rcommand = new SqlCommand(rquery, connection);
            var rules = new List<Rules>();
            SqlDataReader rreader = rcommand.ExecuteReader();
           while (rreader.Read()) {
            

                Rules rule = new Rules();
                rule.rid = (Int32)rreader.GetValue(0);
                rule.rclass = rreader.GetString(1);
                rule.rsection = rreader.GetString(2);
                rule.rlbfine = rreader.GetString(3);
                rule.nofrenew = (Int32)rreader.GetValue(4);
                rule.rdepart = rreader.GetString(5);
                rule.rsession = rreader.GetString(6);
                rule.delayfine = (float)(double)rreader.GetValue(7);
                rule.loanperiod = (Int32)rreader.GetValue(8);
                rule.nofissue = (Int32)rreader.GetValue(9);
                rule.regards = rreader.GetString(10);
                rule.renewperiod = (Int32)rreader.GetValue(11);
               
                rules.Add(rule);

                ViewData["rules"] = rules;


            }

            rreader.Close();

            string cquery = "select Cname from classmaster";
            SqlCommand ccommand = new SqlCommand(cquery,connection);
            var myclasses = new List<My_class>();
            SqlDataReader creader = ccommand.ExecuteReader();
            while (creader.Read())
            {
                My_class myclass = new My_class();
                myclass.CName = creader.GetString(0);
                myclasses.Add(myclass);
                ViewData["myclasses"] = myclasses;    

            }
            creader.Close();




            string squery = "select sname from sectionmaster";
            SqlCommand scommand = new SqlCommand(squery, connection);
            var mysections = new List<My_section>();
            SqlDataReader sreader = scommand.ExecuteReader();
            while (sreader.Read())
            {
                My_section mysection = new My_section();
                mysection.SName = sreader.GetString(0);
                mysections.Add(mysection);
                ViewData["mysections"] = mysections;

            }


            sreader.Close();

            string dquery = "select DepName from departmentmaster";
            SqlCommand dcommand = new SqlCommand(dquery, connection);
            var departments = new List<Departments>();
            SqlDataReader dreader = dcommand.ExecuteReader();
            while (dreader.Read())
            {
                Departments department = new Departments();
                department.departname = dreader.GetString(0);
                departments.Add(department);
                ViewData["departments"] = departments;

            }


            dreader.Close();

            string sequery = "select Sname from sessionmaster";
            SqlCommand secommand = new SqlCommand(sequery, connection);
            var sessions = new List<My_session>();
            SqlDataReader sereader = secommand.ExecuteReader();
            while (sereader.Read())
            {
                My_session session = new My_session();
                session.SName = sereader.GetString(0);
                sessions.Add(session);
                ViewData["sessions"] = sessions;

            }


            sereader.Close();







            connection.Close();

            return View();
        }

        [HttpPost]
        public IActionResult AddRule(string rclass,string rsection,string rlbfine,int norreq,string rdept,string rsession,float rdelayfine,int rloanperiod,int rnoi,string rregard,int rrenewdays,string rremark)
        {

            if(string.IsNullOrEmpty(rremark))
            {
                rremark = "";
            }

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "insert into RuleMaster(class,section,fine,noofrenew,department,session,delayfine,loanperiod,noi,regards,renewperiod,remark) values(@class,@section,@fine,@noofrenew,@department,@session,@delayfine,@loanperiod,@noi,@regards,@renewperiod,@remark)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@class",rclass);
            command.Parameters.AddWithValue("@section",rsection);
            command.Parameters.AddWithValue("@fine",rlbfine);
            command.Parameters.AddWithValue("@noofrenew",norreq);
            command.Parameters.AddWithValue("@department",rdept);
            command.Parameters.AddWithValue("@session",rsession);
            command.Parameters.AddWithValue("@delayfine",rdelayfine);
            command.Parameters.AddWithValue("@loanperiod",rloanperiod);
            command.Parameters.AddWithValue("@noi",rnoi);
            command.Parameters.AddWithValue("@regards",rregard);
            command.Parameters.AddWithValue("@renewperiod",rrenewdays);
            command.Parameters.AddWithValue("@remark",rremark);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("RuleMaster","Home");

        }

        public IActionResult EditRule()
        {

            string editid = Request.Query["editid"];

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string rquery = "select rid,class,section,fine,noofrenew,department,session,delayfine,loanperiod,noi,regards,renewperiod,remark from rulemaster where rid = @rid";
            SqlCommand rcommand = new SqlCommand(rquery, connection);
            rcommand.Parameters.AddWithValue("@rid",editid);
            var rules = new List<Rules>();
            SqlDataReader rreader = rcommand.ExecuteReader();
            while (rreader.Read())
            {

                Rules rule = new Rules();
                rule.rid = (Int32)rreader.GetValue(0);
                rule.rclass = rreader.GetString(1);
                rule.rsection = rreader.GetString(2);
                rule.rlbfine = rreader.GetString(3);
                rule.nofrenew = (Int32)rreader.GetValue(4);
                rule.rdepart = rreader.GetString(5);
                rule.rsession = rreader.GetString(6);
                rule.delayfine = (float)(double)rreader.GetValue(7);
                rule.loanperiod = (Int32)rreader.GetValue(8);
                rule.nofissue = (Int32)rreader.GetValue(9);
                rule.regards = rreader.GetString(10);
                rule.renewperiod = (Int32)rreader.GetValue(11);
                rule.rremark = rreader.GetString(12);


                rules.Add(rule);

                ViewData["rules"] = rules;


            }

            rreader.Close();

            string cquery = "select Cname from classmaster";
            SqlCommand ccommand = new SqlCommand(cquery, connection);
            var myclasses = new List<My_class>();
            SqlDataReader creader = ccommand.ExecuteReader();
            while (creader.Read())
            {
                My_class myclass = new My_class();
                myclass.CName = creader.GetString(0);
                myclasses.Add(myclass);
                ViewData["myclasses"] = myclasses;

            }
            creader.Close();




            string squery = "select sname from sectionmaster";
            SqlCommand scommand = new SqlCommand(squery, connection);
            var mysections = new List<My_section>();
            SqlDataReader sreader = scommand.ExecuteReader();
            while (sreader.Read())
            {
                My_section mysection = new My_section();
                mysection.SName = sreader.GetString(0);
                mysections.Add(mysection);
                ViewData["mysections"] = mysections;

            }


            sreader.Close();

            string dquery = "select DepName from departmentmaster";
            SqlCommand dcommand = new SqlCommand(dquery, connection);
            var departments = new List<Departments>();
            SqlDataReader dreader = dcommand.ExecuteReader();
            while (dreader.Read())
            {
                Departments department = new Departments();
                department.departname = dreader.GetString(0);
                departments.Add(department);
                ViewData["departments"] = departments;

            }


            dreader.Close();

            string sequery = "select Sname from sessionmaster";
            SqlCommand secommand = new SqlCommand(sequery, connection);
            var sessions = new List<My_session>();
            SqlDataReader sereader = secommand.ExecuteReader();
            while (sereader.Read())
            {
                My_session session = new My_session();
                session.SName = sereader.GetString(0);
                sessions.Add(session);
                ViewData["sessions"] = sessions;

            }


            sereader.Close();

            connection.Close();

            return View();
        }



        [HttpPost]
        public IActionResult UpdateRule(int rid, string rclass, string rsection, string rlbfine, int norreq, string rdept, string rsession, float rdelayfine, int rloanperiod, int rnoi, string rregard, int rrenewdays, string rremark)
        {

            if (string.IsNullOrEmpty(rremark))
            {
                rremark = "";
            }

            Console.WriteLine(rid+rclass+rsection+rlbfine);





            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "update RuleMaster set class=@class,section=@section,fine=@fine,noofrenew=@noofrenew,department=@department,session=@session,delayfine=@delayfine,loanperiod=@loanperiod,noi=@noi,regards=@regards,renewperiod=@renewperiod,remark=@remark where rid=@rid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@class", rclass);
            command.Parameters.AddWithValue("@section", rsection);
            command.Parameters.AddWithValue("@fine", rlbfine);
            command.Parameters.AddWithValue("@noofrenew", norreq);
            command.Parameters.AddWithValue("@department", rdept);
            command.Parameters.AddWithValue("@session", rsession);
            command.Parameters.AddWithValue("@delayfine", rdelayfine);
            command.Parameters.AddWithValue("@loanperiod", rloanperiod);
            command.Parameters.AddWithValue("@noi", rnoi);
            command.Parameters.AddWithValue("@regards", rregard);
            command.Parameters.AddWithValue("@renewperiod", rrenewdays);
            command.Parameters.AddWithValue("@remark", rremark);
            command.Parameters.AddWithValue("@rid",rid);

            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("RuleMaster", "Home");

        }

        public IActionResult Bookinfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Bookinfo(string searchel)
        {


              if (string.IsNullOrEmpty(searchel))
            {
                return View();
            }
              else
            {


                var books = new List<Mybooks>();
                SqlConnection connection = new SqlConnection(conn);

                connection.Open();

                string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice, CONVERT(VARCHAR(10), pdate, 103),btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark from BookMaster where bid = @bid";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@bid",searchel);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mybooks mybooks = new Mybooks();
                    mybooks.Id = (Int32)reader.GetValue(0);
                    mybooks.Isbn = reader.GetString(1);
                    mybooks.Bacessno = reader.GetString(2);
                    mybooks.Btype = reader.GetString(3);
                    mybooks.Bname = reader.GetString(4);
                    mybooks.Bauthor = reader.GetString(5);
                    mybooks.Bpubyear = reader.GetString(6);
                    mybooks.Bedno = reader.GetString(7);
                    mybooks.Bnop = reader.GetString(8);
                    mybooks.Bprice = reader.GetString(9);
                    mybooks.purdate = reader.GetString(10);
                    mybooks.Btitle = reader.GetString(11);
                    mybooks.Bpubname = reader.GetString(12);
                    mybooks.Bqty = (Int32)reader.GetValue(13);
                    mybooks.Bsubtitle = reader.GetString(14);
                    mybooks.Bsauthor = reader.GetString(15);
                    mybooks.Bsource = reader.GetString(16);
                    mybooks.Bbillno = reader.GetString(17);
                    mybooks.Bcollno = reader.GetString(18);
                    mybooks.Bshelfno = reader.GetString(19);
                    mybooks.Blang = reader.GetString(20);
                    mybooks.qrcode = reader.GetString(21);
                    mybooks.bRemark = reader.GetString(22);
                    books.Add(mybooks);
                    ViewData["books"] = books;


                }

                reader.Close();
                connection.Close();


                return View();

            }


            
        }



        public IActionResult NewStudentAdmission()
        {
            return View();  
        }










        ///////////////////////////////////////////////////////transaction end here////////////////////////////////////////////


    }
}