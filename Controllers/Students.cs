using Libms.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Libms.Controllers
{
    public class Students : Controller
    {

        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        //string conn = "Data Source=localhost\\sqlexpress;Initial Catalog=db_a9eacf_library;Integrated Security=True";
        public IActionResult Index()
        {
            return View();
        }
         

        public IActionResult AdmissionStatus()
        {
            string error = Request.Query["error"];  
            ViewBag.Error = error;  
            return View();
        }


        [HttpPost]
        public IActionResult AdmissionStatus(string enrollno)
        {
            if(string.IsNullOrEmpty(enrollno))
            {
                return RedirectToAction("AdmissionStatus","Students", new {error  = "Please Enter Student ID" });
            }



            SqlConnection connection = new SqlConnection(conn); 

            connection.Open();

            string query = "select * from regmaster where registrationid = @registrationid";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@registrationid", enrollno);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {

                ViewBag.programme = reader.GetString(2);
                ViewBag.acadyear = reader.GetString(3); 
                ViewBag.name = reader.GetString(7);
                ViewBag.parent = reader.GetString(8);
                ViewBag.dob = reader.GetString(11);
                ViewBag.address = reader.GetString(16);
                ViewBag.phone = reader.GetString(30);
                DateTime dt = (DateTime)reader.GetValue(82);
                ViewBag.year = dt.Year;  
                ViewBag.enrollno = reader.GetString(83);
                ViewBag.details = "true";

            }

            connection.Close();

            Console.WriteLine(enrollno);

            return View();
        }


        public IActionResult Booklist()
        {


            var bsublist = new List<Courses>();
            var Booklist = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();


            string getbookclass = "select distinct bsubject from bookmaster";

            SqlCommand comm = new SqlCommand(getbookclass,connection);

            SqlDataReader dataReader = comm.ExecuteReader();    

            while(dataReader.Read()) {

                Courses courses = new Courses();
                courses.CName = dataReader.GetString(0);
                bsublist.Add(courses);

                ViewData["bsublist"] = bsublist;

            
            }
            dataReader.Close();





            string query = "Select Top 100 bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark,bcategory from BookMaster";

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
                mybooks.Bcname = reader.GetString(23);
                Booklist.Add(mybooks);
                ViewData["Booklist"] = Booklist;

            }

                return View();
        }
         

        [HttpPost]
        public IActionResult Booklist(string searchparam)
        {


            var bsublist = new List<Courses>();
            var Booklist = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();


            string getbookclass = "select distinct bsubject from bookmaster";

            SqlCommand comm = new SqlCommand(getbookclass, connection);

            SqlDataReader dataReader = comm.ExecuteReader();

            while (dataReader.Read())
            {

                Courses courses = new Courses();
                courses.CName = dataReader.GetString(0);
                bsublist.Add(courses);

                ViewData["bsublist"] = bsublist;


            }
            dataReader.Close();





            string query = "Select  bid , isbn,acessno,btype,bname,bauthor,pubyear,edno,nop,bprice,pdate,btitle,bpubname,bqty,bsubtitle,bsauthor,bsource,billno,bcolno,bshelfno,blang,qrcode,remark,bcategory from BookMaster where bsubject=@bsubject";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@bsubject",searchparam );
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
                mybooks.Bcname = reader.GetString(23);
                Booklist.Add(mybooks);
                ViewData["Booklist"] = Booklist;

            }

            return View();
        }



    }
}
