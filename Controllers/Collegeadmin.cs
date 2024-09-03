using Libms.Models;
using Libms.Sessions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using static QRCoder.PayloadGenerator;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Org.BouncyCastle.Asn1.X509;
using Libms.Report;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Libms.Controllers 
{
    public class Collegeadmin : Controller
    {


        //string conn = "Data Source=localhost\\sqlexpress;Initial Catalog=db_a9eacf_library;Integrated Security=True";
        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";

        private IAccountServices _accountService;
        private readonly IHostingEnvironment _environment;

        public Collegeadmin(IAccountServices accountService, IHostingEnvironment environment)
        {
            //_logger = logger;
            // _environment = environment;
            _accountService = accountService;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult Admissiondash()
        {

            var Students = new List<students>();
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from VWREGFCNT";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            int totals = 0;


            while (reader.Read()) {

                students Student = new students();
                Student.course = reader.GetString(1);

                Student.genm = (Int32)reader.GetValue(2);
                Student.genf = (Int32)reader.GetValue(3);
                Student.geno = (Int32)reader.GetValue(4);

                Student.obcm = (Int32)reader.GetValue(5);
                Student.obcf = (Int32)reader.GetValue(6);
                Student.obco = (Int32)reader.GetValue(7);

                Student.scm = (Int32)reader.GetValue(8);
                Student.scf = (Int32)reader.GetValue(9);
                Student.sco = (Int32)reader.GetValue(10);

                Student.stm = (Int32)reader.GetValue(11);
                Student.stf = (Int32)reader.GetValue(12);
                Student.sto = (Int32)reader.GetValue(13);

                Student.ewm = (Int32)reader.GetValue(20);
                Student.ewf = (Int32)reader.GetValue(21);
                Student.ewo = (Int32)reader.GetValue(22);

                Student.minm_m = (Int32)reader.GetValue(14);
                Student.minm_f = (Int32)reader.GetValue(15);
                Student.minm_o = (Int32)reader.GetValue(16);

                Student.mins_m = (Int32)reader.GetValue(17);
                Student.minos_f = (Int32)reader.GetValue(18);
                Student.minos_o = (Int32)reader.GetValue(19);

               

                Student.minj_m = (Int32)reader.GetValue(23);
                Student.minj_f = (Int32)reader.GetValue(24);
                Student.minj_o = (Int32)reader.GetValue(25);

                Student.total = (Int32)reader.GetValue(2) + (Int32)reader.GetValue(3) + (Int32)reader.GetValue(4) + (Int32)reader.GetValue(5) + (Int32)reader.GetValue(6) +
                                 (Int32)reader.GetValue(7) + (Int32)reader.GetValue(8) + (Int32)reader.GetValue(9) + (Int32)reader.GetValue(10) + (Int32)reader.GetValue(11) + (Int32)reader.GetValue(12) + (Int32)reader.GetValue(13) + (Int32)reader.GetValue(14) + (Int32)reader.GetValue(15) + (Int32)reader.GetValue(16) + (Int32)reader.GetValue(17) + (Int32)reader.GetValue(18) + (Int32)reader.GetValue(19) + (Int32)reader.GetValue(20) + (Int32)reader.GetValue(21) + (Int32)reader.GetValue(22) + (Int32)reader.GetValue(23) + (Int32)reader.GetValue(24) + (Int32)reader.GetValue(25);
                int  total = (Int32)reader.GetValue(2) + (Int32)reader.GetValue(3) + (Int32)reader.GetValue(4) + (Int32)reader.GetValue(5) + (Int32)reader.GetValue(6) +
                                 (Int32)reader.GetValue(7) + (Int32)reader.GetValue(8) + (Int32)reader.GetValue(9) + (Int32)reader.GetValue(10) + (Int32)reader.GetValue(11) + (Int32)reader.GetValue(12) + (Int32)reader.GetValue(13) + (Int32)reader.GetValue(14) + (Int32)reader.GetValue(15) + (Int32)reader.GetValue(16) + (Int32)reader.GetValue(17) + (Int32)reader.GetValue(18) + (Int32)reader.GetValue(19) + (Int32)reader.GetValue(20) + (Int32)reader.GetValue(21) + (Int32)reader.GetValue(22) + (Int32)reader.GetValue(23) + (Int32)reader.GetValue(24) + (Int32)reader.GetValue(25);

                totals = total + totals;
                ViewBag.totals = totals;    
                Students.Add(Student); 

                ViewData["Students"] = Students; 

            }
            connection.Close();
            return View();
        }


        public IActionResult Librarydash()
        {
            var books = new List<Mybooks>();
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "select count(*) as counts,bcategory from BookMaster  group by bcategory;";

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




        public IActionResult Admissionlogin()
        {
            string username = HttpContext.Session.GetString("username");

            if(username!=null)
            {
                return RedirectToAction("Admissionlist", "Collegeadmin");
            }
            else
            {
                return View();
            }
                
           
        }

        [HttpPost]
        public IActionResult LoginFromAdmissionlogin(string usernm, string passwd)
        {

             if (string.IsNullOrEmpty(usernm)) {

                usernm = "";
            
            }

            if (string.IsNullOrEmpty(passwd))
            {

                passwd = "";

            }

            


            var account = _accountService.Login(usernm, passwd);

            if (account != null)
            {
                string uname = account.Username;
                string utype = account.Usertype;
                string folder = "";
                string url = "";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usernm));
                claims.Add(new Claim(ClaimTypes.Name, usernm));
                if (utype == "coladmin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "coladmin"));

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);


                    folder = "Collegeadmin";
                    url = "Admissionlist";

                }

                else
                {
                    folder = "Collegeadmin";
                    url = "Admissionlogin";
                }



               



                return RedirectToAction(url, folder);



            }
            else
            {
                Console.WriteLine("invalid login attempt");
                ViewBag.Message = "Invalid login";
                return RedirectToAction("Admissionlogin","Collegeadmin");
            }
        }


        [Authorize(Roles = "coladmin")]
        public IActionResult Admissionlist()
        {
            string memberid = Request.Query["memberid"];
            ViewBag.memberid = memberid;
            var Students = new List<students>();
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from VWREGFCNT";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            int totals = 0;


            while (reader.Read())
            {

                students Student = new students(); 

                Student.total = (Int32)reader.GetValue(2) + (Int32)reader.GetValue(3) + (Int32)reader.GetValue(4) + (Int32)reader.GetValue(5) + (Int32)reader.GetValue(6) +
                                 (Int32)reader.GetValue(7) + (Int32)reader.GetValue(8) + (Int32)reader.GetValue(9) + (Int32)reader.GetValue(10) + (Int32)reader.GetValue(11) + (Int32)reader.GetValue(12) + (Int32)reader.GetValue(13) + (Int32)reader.GetValue(14) + (Int32)reader.GetValue(15) + (Int32)reader.GetValue(16) + (Int32)reader.GetValue(17) + (Int32)reader.GetValue(18) + (Int32)reader.GetValue(19) + (Int32)reader.GetValue(20) + (Int32)reader.GetValue(21) + (Int32)reader.GetValue(22) + (Int32)reader.GetValue(23) + (Int32)reader.GetValue(24) + (Int32)reader.GetValue(25);
                int total = (Int32)reader.GetValue(2) + (Int32)reader.GetValue(3) + (Int32)reader.GetValue(4) + (Int32)reader.GetValue(5) + (Int32)reader.GetValue(6) +
                                 (Int32)reader.GetValue(7) + (Int32)reader.GetValue(8) + (Int32)reader.GetValue(9) + (Int32)reader.GetValue(10) + (Int32)reader.GetValue(11) + (Int32)reader.GetValue(12) + (Int32)reader.GetValue(13) + (Int32)reader.GetValue(14) + (Int32)reader.GetValue(15) + (Int32)reader.GetValue(16) + (Int32)reader.GetValue(17) + (Int32)reader.GetValue(18) + (Int32)reader.GetValue(19) + (Int32)reader.GetValue(20) + (Int32)reader.GetValue(21) + (Int32)reader.GetValue(22) + (Int32)reader.GetValue(23) + (Int32)reader.GetValue(24) + (Int32)reader.GetValue(25);

                totals = total + totals;
                ViewBag.totals = totals;
      

            }

            reader.Close(); 


            var Stlist = new List<Studentslist>();
            string query1 = "Select  * from regmaster";
            SqlCommand command1 = new SqlCommand(query1, connection);
            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {

                Studentslist Stlist1 = new Studentslist();
                Stlist1.Id = (Int32)reader1.GetValue(0);   
                Stlist1.Class = reader1.GetString(2);
                Stlist1.enroll= reader1.GetString(4);
                Stlist1.Sname= reader1.GetString(7);
                Stlist1.gender = reader1.GetString(13);  
                Stlist1.Whatsappno = reader1.GetString(30);
                Stlist1.regid = reader1.GetString(83);
                Stlist1.rstatus = reader1.GetString(84);
                Stlist.Add(Stlist1);
                ViewData["Stlist"] = Stlist;


            }

            reader1.Close();

            connection.Close();
            return View();
        }


        [HttpPost]
        public IActionResult GetAdmission(string regno)
        {

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            var Studentinfos = new List<Studentinfo>();
            string query = "select rid,rlevel,course,acadyear,uniregno,admcategory,merit,name,fatname," +
                "gauname,mothname,dob,nationality,gender,categ,scateg," +
                "address,town,tehsil,post,thana,district," +
                "state,pin,partinsport,spouse,ncc,scout,hostel," +
                "emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark," +
                "tendiv,tenper,tengroup,tenschool,tenboard," +
                "twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard," +
                "punish,registrationid from regmaster where rid = @rid";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@rid", regno);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

               Studentinfo studentinfo = new Studentinfo();

                studentinfo.Id = (Int32)reader.GetValue(0);

                studentinfo.Admcat = reader.GetString(5);
                studentinfo.Merit = reader.GetString(6);
                studentinfo.Sname = reader.GetString(7);
                studentinfo.Fatname = reader.GetString(8);
                studentinfo.Gauname = reader.GetString(9);
                studentinfo.Mothname = reader.GetString(10);
                studentinfo.Sdob = reader.GetString(11);
                studentinfo.Snation = reader.GetString(12);
                studentinfo.Sgender = reader.GetString(13);
                studentinfo.Categ = reader.GetString(14);
                studentinfo.Scateg = reader.GetString(15);
                studentinfo.Address = reader.GetString(16);
                studentinfo.Town = reader.GetString(17);
                studentinfo.Tehsil = reader.GetString(18);
                studentinfo.Post = reader.GetString(19);
                studentinfo.Thana = reader.GetString(20);
                studentinfo.District = reader.GetString(21);
                studentinfo.State = reader.GetString(22);
                studentinfo.Pin = reader.GetString(23);
                studentinfo.Partinsport = reader.GetString(24);

                studentinfo.Spouse = reader.GetString(25);
                studentinfo.Ncc = reader.GetString(26);
                studentinfo.Scout = reader.GetString(27);
                studentinfo.Hostel = reader.GetString(28);
                studentinfo.Emailid = reader.GetString(29);
                studentinfo.Whatsapp = reader.GetString(30);
                studentinfo.Tenyear = reader.GetString(31);
                studentinfo.Tenmarks = reader.GetString(32);
                studentinfo.Tenmax = reader.GetString(33);
                studentinfo.Tendiv = reader.GetString(34);
                studentinfo.Tenper = reader.GetString(35);
                studentinfo.Tengroup = reader.GetString(36);
                studentinfo.Tenschool = reader.GetString(37);
                studentinfo.Tenboard = reader.GetString(38);
                studentinfo.Twyear = reader.GetString(39);
                studentinfo.Twmarks = reader.GetString(40);
                studentinfo.Twmax = reader.GetString(41);
                studentinfo.Twdiv = reader.GetString(42);
                studentinfo.Twper = reader.GetString(43);
                studentinfo.Twgroup = reader.GetString(44);

                studentinfo.Twschool = reader.GetString(45);
                studentinfo.Twboard = reader.GetString(46);
                studentinfo.Ugyear = reader.GetString(47);
                studentinfo.Ugmarks = reader.GetString(48);
                studentinfo.Ugmax = reader.GetString(49);
                studentinfo.Ugdiv = reader.GetString(50);
                studentinfo.Ugper = reader.GetString(51);
                studentinfo.Uggroup = reader.GetString(52);
                studentinfo.Ugschool = reader.GetString(53);
                studentinfo.Ugboard = reader.GetString(54);
                 
                studentinfo.Pgyear = reader.GetString(55);
                studentinfo.Pgmarks = reader.GetString(56);
                studentinfo.Pgmax = reader.GetString(57);
                studentinfo.Pgdiv = reader.GetString(58);
                studentinfo.Pgper = reader.GetString(59);
                studentinfo.Pggroup = reader.GetString(60);
                studentinfo.Pgschool = reader.GetString(61);
                studentinfo.Pgboard = reader.GetString(62);
                studentinfo.Punish = reader.GetString(63);
                studentinfo.Regid = reader.GetString(64);

                Studentinfos.Add(studentinfo);

                ViewData["Studentinfos"] = Studentinfos; 

               
            }

            reader.Close();
            connection.Close();

            return PartialView("_StudentPartial");
             
        }



    


        [HttpPost]
        public IActionResult UpdateStudent(string regid,string sname, string fatname , string gauname ,string mothname, string dob,string nation,string gender
            ,string categ, string scateg, string addr, string town, string tehsil, string post,string thana, string district,string state, string pin,
            string sports, string spouse, string ncc
            , string scout, string hostel, string email, string whnumber,


              string tenyear, string tenmarks, string tenmax, string tendiv, string tenper, string tengroup,
        string tenschool, string tenboard, string twyear, string twmarks, string twmax, string twdiv,string twper
            , string twschool, string twgroup, string twscool, string twboard,

         string ugyear, string ugmarks, string ugmax, string ugdiv, string ugper, string uggroup,
        string ugschool, string ugboard, string pgyear, string pgmarks, string pgmax, string pgdiv
            , string pgper, string pggroup, string pgschool, string pgboard)
        {

            if(string.IsNullOrEmpty(sname))
            {
                sname = "";
            }


            if (string.IsNullOrEmpty(fatname))
            {
                fatname = "";
            }


            if (string.IsNullOrEmpty(gauname))
            {
                gauname = "";
            }


            if (string.IsNullOrEmpty(mothname))
            {
                mothname = "";
            }


            if (string.IsNullOrEmpty(dob))
            {
                dob = "";
            }
            if (string.IsNullOrEmpty(nation))
            {
                nation = "";
            }
            if (string.IsNullOrEmpty(gender))
            {
                gender = "";
            }
            if (string.IsNullOrEmpty(categ))
            {
                categ = "";
            }
            if (string.IsNullOrEmpty(scateg))
            {
                scateg = "";
            }

            if (string.IsNullOrEmpty(addr))
            {
                addr = "";
            }



            if (string.IsNullOrEmpty(town))
            {
                town = "";
            }


            if (string.IsNullOrEmpty(tehsil))
            {
                tehsil = "";
            }


            if (string.IsNullOrEmpty(post))
            {
                post = "";
            }


            if (string.IsNullOrEmpty(thana))
            {
                thana = "";
            }


            if (string.IsNullOrEmpty(district))
            {
                district = "";
            }

            if (string.IsNullOrEmpty(state))
            {
                state = "";
            }


            if (string.IsNullOrEmpty(pin))
            {
                pin = "";
            }



            if (string.IsNullOrEmpty(sports))
            {
                sports = "";
            }

            if (string.IsNullOrEmpty(spouse))
            {
                spouse = "";
            }

            if (string.IsNullOrEmpty(ncc))
            {
                ncc = "";
            }
            if (string.IsNullOrEmpty(scout))
            {
                scout = "";
            }


            if (string.IsNullOrEmpty(hostel))
            {
                hostel = "";
            }

            if (string.IsNullOrEmpty(email))
            {
                email = "";
            }

            if (string.IsNullOrEmpty(whnumber))
            {
                whnumber = "";
            }



            //---------------------------- academic values---------------------------//

            if (string.IsNullOrEmpty(tenyear))
            {
                tenyear = "";
            }

            if (string.IsNullOrEmpty(tenmarks))
            {
                tenmarks = "";
            }

            if (string.IsNullOrEmpty(tenmax))
            {
                tenmax = "";
            }
            if (string.IsNullOrEmpty(tendiv))
            {
                tendiv= "";
            }


            if (string.IsNullOrEmpty(tenper))
            {
                tenper = "";
            }


            if (string.IsNullOrEmpty(tengroup))
            {
                tengroup = "";
            }


            if (string.IsNullOrEmpty(tenschool))
            {
                tenschool = "";
            }


            if (string.IsNullOrEmpty(tenboard))
            {
                tenboard = "";
            }




            if (string.IsNullOrEmpty(twyear))
            {
                twyear = "";
            }

            if (string.IsNullOrEmpty(twmarks))
            {
                twmarks = "";
            }

            if (string.IsNullOrEmpty(twmax))
            {
                twmax = "";
            }
            if (string.IsNullOrEmpty(twdiv))
            {
                twdiv = "";
            }


            if (string.IsNullOrEmpty(twper))
            {
                twper = "";
            }


            if (string.IsNullOrEmpty(twgroup))
            {
                twgroup = "";
            }


            if (string.IsNullOrEmpty(twschool))
            {
                twschool = "";
            }


            if (string.IsNullOrEmpty(twboard))
            {
                twboard = "";
            }



            if (string.IsNullOrEmpty(ugyear))
            {
                ugyear = "";
            }

            if (string.IsNullOrEmpty(ugmarks))
            {
                ugmarks = "";
            }

            if (string.IsNullOrEmpty(ugmax))
            {
                ugmax = "";
            }
            if (string.IsNullOrEmpty(ugdiv))
            {
                ugdiv = "";
            }


            if (string.IsNullOrEmpty(ugper))
            {
                ugper = "";
            }


            if (string.IsNullOrEmpty(uggroup))
            {
                uggroup = "";
            }


            if (string.IsNullOrEmpty(ugschool))
            {
                ugschool = "";
            }



            if (string.IsNullOrEmpty(ugboard))
            {
                ugboard = "";
            }





            if (string.IsNullOrEmpty(pgyear))
            {
                pgyear = "";
            }

            if (string.IsNullOrEmpty(pgmarks))
            {
                pgmarks = "";
            }

            if (string.IsNullOrEmpty(pgmax))
            {
                pgmax = "";
            }
            if (string.IsNullOrEmpty(pgdiv))
            {
                pgdiv = "";
            }


            if (string.IsNullOrEmpty(pgper))
            {
                pgper = "";
            }


            if (string.IsNullOrEmpty(pggroup))
            {
                pggroup = "";
            }


            if (string.IsNullOrEmpty(pgschool))
            {
                pgschool = "";
            }



            if (string.IsNullOrEmpty(pgboard))
            {
                pgboard = "";
            }

            Console.WriteLine(addr);

            Console.WriteLine(sname);

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "Update  Regmaster set name = @name, fatname=@fatname,gauname=@gauname," +
                "mothname=@mothname,dob=@dob,nationality=@nationality,gender=@gender,categ=@categ,scateg=@scateg," +
                 "address = @address, town = @town, tehsil = @tehsil," +
                "post=@post,thana=@thana,district=@district,state=@state,pin=@pin,"+
                " partinsport = @partinsport, spouse=@css,ncc=@ncc,scout=@scout,hostel=@hostel,emailid=@emailid,whatsapp=@whatsapp,"+


                "tenyear = @tenyear, tenmarksobt = @tenmarksobt, tenmaxmark = @tenmaxmark," +
                "tendiv=@tendiv,tenper=@tenper,tengroup=@tengroup,tenschool=@tenschool,tenboard=@tenboard ," +
                "twyear = @twyear, twmarksobt = @twmarksobt, twmaxmark = @twmaxmark," +
                "twdiv=@twdiv,twper=@twper,twgroup=@twgroup,twschool=@twschool,twboard=@twboard,"+


                "ugyear = @ugyear, ugmarksobt = @ugmarksobt, ugmaxmark = @ugmaxmark," +
                "ugdiv=@ugdiv,ugper=@ugper,uggroup=@uggroup,ugschool=@ugschool,ugboard=@ugboard ," +
                "pgyear = @pgyear, pgmarksobt = @pgmarksobt, pgmaxmark = @pgmaxmark," +
                "pgdiv=@pgdiv,pgper=@pgper,pggroup=@pggroup,pgschool=@pgschool,pgboard=@pgboard"+

                " where registrationid = @registrationid";

            SqlCommand comm = new SqlCommand(query, connection);
            comm.Parameters.AddWithValue("@name", sname);
            comm.Parameters.AddWithValue("@fatname", fatname);

            comm.Parameters.AddWithValue("@gauname", gauname);

            comm.Parameters.AddWithValue("@mothname", mothname);

            comm.Parameters.AddWithValue("@dob", dob);

            comm.Parameters.AddWithValue("@nationality", nation);

            comm.Parameters.AddWithValue("@gender", gender);

            comm.Parameters.AddWithValue("@categ", categ);

            comm.Parameters.AddWithValue("@scateg", scateg);

            comm.Parameters.AddWithValue("@address", addr);

            comm.Parameters.AddWithValue("@town", town);

            comm.Parameters.AddWithValue("@tehsil", tehsil);

            comm.Parameters.AddWithValue("@post", post);

            comm.Parameters.AddWithValue("@thana", thana);

            comm.Parameters.AddWithValue("@district", district);

            comm.Parameters.AddWithValue("@state", state);

            comm.Parameters.AddWithValue("@pin", pin);


            comm.Parameters.AddWithValue("@partinsport", sports);

            comm.Parameters.AddWithValue("@css", spouse);

            comm.Parameters.AddWithValue("@ncc", ncc);

            comm.Parameters.AddWithValue("@scout", scout);

            comm.Parameters.AddWithValue("@hostel", hostel);

            comm.Parameters.AddWithValue("@emailid", email);

            comm.Parameters.AddWithValue("@whatsapp", whnumber);

            // 10th 12th



            comm.Parameters.AddWithValue("@tenyear", tenyear);
            comm.Parameters.AddWithValue("@tenmarksobt", tenmarks);
            comm.Parameters.AddWithValue("@tenmaxmark", tenmax);
            comm.Parameters.AddWithValue("@tendiv", tendiv);
            comm.Parameters.AddWithValue("@tenper", tenper);
            comm.Parameters.AddWithValue("@tengroup", tengroup);
            comm.Parameters.AddWithValue("@tenschool", tenschool);
            comm.Parameters.AddWithValue("@tenboard", tenboard);

            comm.Parameters.AddWithValue("@twyear", twyear);
            comm.Parameters.AddWithValue("@twmarksobt", twmarks);
            comm.Parameters.AddWithValue("@twmaxmark", twmax);
            comm.Parameters.AddWithValue("@twdiv", twdiv);
            comm.Parameters.AddWithValue("@twper", twper);
            comm.Parameters.AddWithValue("@twgroup", twgroup);
            comm.Parameters.AddWithValue("@twschool", twschool);
            comm.Parameters.AddWithValue("@twboard", twboard);




            //ug pg//

            comm.Parameters.AddWithValue("@ugyear", ugyear);
            comm.Parameters.AddWithValue("@ugmarksobt", ugmarks);
            comm.Parameters.AddWithValue("@ugmaxmark", ugmax);
            comm.Parameters.AddWithValue("@ugdiv", ugdiv);
            comm.Parameters.AddWithValue("@ugper", ugper);
            comm.Parameters.AddWithValue("@uggroup", uggroup);
            comm.Parameters.AddWithValue("@ugschool", ugschool);
            comm.Parameters.AddWithValue("@ugboard", ugboard);

            comm.Parameters.AddWithValue("@pgyear", pgyear);
            comm.Parameters.AddWithValue("@pgmarksobt", pgmarks);
            comm.Parameters.AddWithValue("@pgmaxmark", pgmax);
            comm.Parameters.AddWithValue("@pgdiv", pgdiv);
            comm.Parameters.AddWithValue("@pgper", pgper);
            comm.Parameters.AddWithValue("@pggroup", pggroup);
            comm.Parameters.AddWithValue("@pgschool", pgschool);
            comm.Parameters.AddWithValue("@pgboard", pgboard);
            //comm.Parameters.AddWithValue("@punish", offence);
           



            comm.Parameters.AddWithValue("@registrationid", regid);

            comm.ExecuteNonQuery();

            connection.Close();





            return RedirectToAction("Admissionlist", "collegeadmin");

        }

        [HttpPost]
        public IActionResult UploadFiles(string itemid)
        {
            Console.WriteLine(itemid);
            ViewBag.itemid = itemid;    
            return PartialView("_UploadDocPartial", "collegeadmin");
        }


        public IActionResult UpdateStudentDocs(string stid)
        {
            Console.WriteLine(stid);
            
            return RedirectToAction("Admissionlist", "collegeadmin");
        }


        public IActionResult ChangeStatus()
        {

            string id = Request.Query["id"];

            string rstatus = Request.Query["rstatus"];

            Console.WriteLine(id);

            Console.WriteLine(rstatus); 

            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            string query = "update regmaster set rstatus = @rstatus where rid = @rid";

            SqlCommand command = new SqlCommand(query,connection);

            if(rstatus=="0")
            {
                command.Parameters.AddWithValue("@rstatus", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@rstatus", "0");
            }

            command.Parameters.AddWithValue("@rid", id);

            command.ExecuteNonQuery();

            string Vclass = "";
            string Vname = "";
            string Vgender = "";
            string Vaddr = "";
            string Vphone = "";
            string Vemailid = "";
            string Vregno = "";
           

            string fetchrecord = "select course, name, gender,Address, town,post,district , state , pin, whatsapp, emailid, registrationid   from regmaster where rid = @rid";
            SqlCommand command1 = new SqlCommand(fetchrecord,connection);

            command1.Parameters.AddWithValue("@rid", id);

            SqlDataReader dataReader = command1.ExecuteReader();

            while (dataReader.Read())
            {
                Vclass = dataReader.GetString(0);
                Vname  = dataReader.GetString(1); 

                Vgender = dataReader.GetString(2);

                Vaddr = dataReader.GetString(3)+","+dataReader.GetString(4)+","+ dataReader.GetString(5)+","+dataReader.GetString(6)+","+dataReader.GetString(7)+","+dataReader.GetString(8);

                Vphone = dataReader.GetString(9);
                
                Vemailid = dataReader.GetString(10);
                
                Vregno = dataReader.GetString(11);  

            }

            dataReader.Close();


            string newquery1 = "select count(*) from membermaster where memberid = @memberid";



            SqlCommand command3 =  new SqlCommand(newquery1,connection);

            command3.Parameters.AddWithValue("@memberid",Vregno);

            int count = (Int32)command3.ExecuteScalar();

            if (count > 0)
            {
                return RedirectToAction("Admissionlist", "Collegeadmin", new { success = "Student already  added", memberid = Vregno });
            }

            else
            {
                string newquery = "Insert Into MemberMaster (memberid , mpassword,mname,mtype,mgen,maddress,mclass,memail,mmob,myear,msection,remark)" +
                           "values(@memberid,@mpassword,@mname,@mtype,@mgen,@maddress,@mclass,@memail,@mmob,@myear,@msection,@remark)" + "select SCOPE_IDENTITY();";

                SqlCommand command2 = new SqlCommand(newquery, connection);
                command2.Parameters.AddWithValue("@memberid", Vregno);
                command2.Parameters.AddWithValue("@mpassword", Vregno);
                command2.Parameters.AddWithValue("@mname", Vname);
                command2.Parameters.AddWithValue("@mtype", "Student");
                command2.Parameters.AddWithValue("@mgen", Vgender);
                command2.Parameters.AddWithValue("@maddress", Vaddr);
                command2.Parameters.AddWithValue("@mclass", Vclass);
                command2.Parameters.AddWithValue("@memail", Vemailid);
                command2.Parameters.AddWithValue("@mmob", Vphone);
                command2.Parameters.AddWithValue("@myear", "");
                command2.Parameters.AddWithValue("@msection", "");
                command2.Parameters.AddWithValue("@remark", "");
                int igetlastid = Convert.ToInt32(command2.ExecuteScalar());
                ViewBag.OrderId = igetlastid;

                connection.Close();

                return RedirectToAction("Admissionlist", "Collegeadmin", new { success = "Student added to library", memberid = igetlastid });
            }
           
           
        }


        public IActionResult Admission_Report()
        {

            AdmissionReport admissionReport = new AdmissionReport(_environment);
            byte[] abytes = admissionReport.PrepareAdmissionReport();
            return File(abytes, "application/pdf");

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.SignOutAsync();
            return RedirectToAction("Admissionlogin", "Collegeadmin");
        }

    }
}
