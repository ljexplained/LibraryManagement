using Libms.Models;
using Libms.Sessions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Razorpay.Api;
using System.Runtime.CompilerServices;
using static QRCoder.PayloadGenerator;
using System.Security.Principal;
using Org.BouncyCastle.Asn1.X509;
using System;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Http;

namespace Libms.Controllers
{

     
    public class Admission : Controller
    {

        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        //string conn = "Data Source=localhost\\sqlexpress;Initial Catalog=db_a9eacf_library;Integrated Security=True";
        private IAccountServices _accountService;

        private readonly IHostingEnvironment _environment;

        public Admission(IAccountServices accountService, IHostingEnvironment environment)
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


        public IActionResult Instructions()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Instructions(string data)
        {

            return RedirectToAction("SelectCourses","Admission");
        }


        [HttpPost]
        public IActionResult LoginStudent(string studentid,string nopermit)
        {

            if (string.IsNullOrEmpty(studentid))
            {

                studentid = "";
            }
           

            var account = _accountService.Login(studentid, studentid);

            if (account != null)
            {
                string uname = account.Username;
                string utype = account.Usertype;
                string folder = "";

                string url = "";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, studentid));
                claims.Add(new Claim(ClaimTypes.Name, studentid));
                if (utype == "student")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "student"));
                    folder = "Admission";
                    url = "PersonalDetails";

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);
                    HttpContext.Session.SetString("permit",nopermit);


                }

                else
                {
                    folder = "Admission";
                    url = "SelectCourses";
                }

                return RedirectToAction(url, folder);



            }
            else
            {
                Console.WriteLine("invalid login attempt");
                ViewBag.Message = "Invalid login";
                return RedirectToAction("SelectCourses", "Admission");
            }

        }
       
        public IActionResult SelectCourses()
        {


            return View();
        }




        [Authorize(Roles = "student")]
        public IActionResult  PersonalDetails()
        {
            string uname = HttpContext.Session.GetString("username");
            string permit = HttpContext.Session.GetString("permit");
            ViewBag.uname = uname;
            ViewBag.permit = permit;    
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select name, fatname, gauname,mothname,dob,nationality," +
                "gender,categ,scateg from regmaster where registrationid = @uname";
            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@uname", uname);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {

                ViewBag.name = reader.GetString(0);
                ViewBag.fatname = reader.GetString(1);
                ViewBag.gauname = reader.GetString(2);
                ViewBag.mothname = reader.GetString(3);
                ViewBag.dob = reader.GetString(4);
                ViewBag.nation = reader.GetString(5);
                ViewBag.gender = reader.GetString(6);
                ViewBag.categ = reader.GetString(7);
                ViewBag.scateg = reader.GetString(8);

            }

            connection.Close();
            return View();
        }


        [HttpPost]
        public IActionResult UpdatePersonalDetails(string candidate,string fathername,string gaurdian
            ,string mothername,string dob,string nation, string gender,string Castecategory,string Subcategory)
        {


            if(string.IsNullOrEmpty(candidate))
            {
                candidate = "";
            }

            if (string.IsNullOrEmpty(fathername))
            {
                fathername = "";
            }
            if (string.IsNullOrEmpty(gaurdian))
            {
                gaurdian = "";
            }

            if (string.IsNullOrEmpty(mothername))
            {
                mothername = "";
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


            if (string.IsNullOrEmpty(Castecategory))
            {
                Castecategory = "";
            }

            if (string.IsNullOrEmpty(Subcategory))
            {
                Subcategory = "";
            }

            string username = HttpContext.Session.GetString("username");

            //string username = "202401010001";

            SqlConnection connection = new SqlConnection(conn); 
            connection.Open();

            string query = "Update  Regmaster set name = @name, fatname=@fatname,gauname=@gauname," +
                "mothname=@mothname,dob=@dob,nationality=@nationality,gender=@gender,categ=@categ,scateg=@scateg where registrationid = @registrationid ";

            SqlCommand comm = new SqlCommand(query, connection);
            comm.Parameters.AddWithValue("@name",candidate);
            comm.Parameters.AddWithValue("@fatname",fathername);

            comm.Parameters.AddWithValue("@gauname",gaurdian);

            comm.Parameters.AddWithValue("@mothname",mothername);

            comm.Parameters.AddWithValue("@dob",dob);

            comm.Parameters.AddWithValue("@nationality",nation);
            comm.Parameters.AddWithValue("@gender",gender);

            comm.Parameters.AddWithValue("@categ",Castecategory);

            comm.Parameters.AddWithValue("@scateg",Subcategory);
            comm.Parameters.AddWithValue("@registrationid",username);

            comm.ExecuteNonQuery();

            connection.Close();
            return RedirectToAction("ProceedSelection", "Admission");
        }

        [Authorize(Roles = "student,admin")]
        public IActionResult ProceedSelection()
        {


            string uname = HttpContext.Session.GetString("username");
            string permit = HttpContext.Session.GetString("permit");
            ViewBag.uname = uname;
            ViewBag.permit = permit;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select address, town, tehsil,post,thana,district," +
                "state,pin from regmaster where registrationid = @uname";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@uname", uname);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                ViewBag.address = reader.GetString(0);
                ViewBag.town = reader.GetString(1);
                ViewBag.tehsil = reader.GetString(2);
                ViewBag.post = reader.GetString(3);
                ViewBag.thana = reader.GetString(4);
                ViewBag.district = reader.GetString(5);
                ViewBag.state = reader.GetString(6);
                ViewBag.pin = reader.GetString(7);
               

            }

            connection.Close();

            return View();
        }

        [HttpPost]
        public IActionResult UpdateProceedSelection(string addr,string town,string tehsil
            ,string post,string thana,string district,string state,string pincode)
        {



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
                 tehsil= "";
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

            if (string.IsNullOrEmpty(pincode))
            {
                pincode = "";
            }



            string username = HttpContext.Session.GetString("username");
            //string username = "202401010001";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "Update  Regmaster set address  = @address, town=@town,tehsil=@tehsil," +
                "post=@post,thana=@thana,district=@district,state=@state,pin=@pin where registrationid = @registrationid";

            SqlCommand comm = new SqlCommand(query, connection);
            comm.Parameters.AddWithValue("@address", addr);
            comm.Parameters.AddWithValue("@town", town);

            comm.Parameters.AddWithValue("@tehsil", tehsil);

            comm.Parameters.AddWithValue("@post", post);
            comm.Parameters.AddWithValue("@thana",thana);

            comm.Parameters.AddWithValue("@district",district);
            comm.Parameters.AddWithValue("@state", state);

            comm.Parameters.AddWithValue("@pin",pincode);

            comm.Parameters.AddWithValue("@registrationid", username);


            comm.ExecuteNonQuery();

            connection.Close();
       
            return RedirectToAction("WeightageClaimed", "Admission");
        }



        [Authorize(Roles = "student")]
        public IActionResult  WeightageClaimed()
        {

            string uname = HttpContext.Session.GetString("username");
            string permit = HttpContext.Session.GetString("permit");
            ViewBag.uname = uname;
            ViewBag.permit = permit;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select partinsport, spouse, ncc,scout,hostel,emailid," +
                "whatsapp  from regmaster where registrationid = @uname";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@uname", uname);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                ViewBag.sport = reader.GetString(0);
                ViewBag.spouse = reader.GetString(1);
                ViewBag.ncc = reader.GetString(2);
                ViewBag.scout = reader.GetString(3);
                ViewBag.hostel = reader.GetString(4);
                ViewBag.emailid = reader.GetString(5);
                ViewBag.whatsapp = reader.GetString(6);
                


            }

            connection.Close();
            return View();

        }

       


        [HttpPost]
        public IActionResult UpdateWeightageClaimed(string insports,string cssuniversity,string nccnss
            ,string scoutguide,string hostel,string emailid,string whnumber)
        {

            if (string.IsNullOrEmpty(insports))
            {
                insports = "";
            }

            if (string.IsNullOrEmpty(cssuniversity))
            {
                cssuniversity = "";
            }

            if (string.IsNullOrEmpty(nccnss))
            {
                nccnss = "";
            }
            if (string.IsNullOrEmpty(scoutguide))
            {
                scoutguide = "";
            }

            if (string.IsNullOrEmpty(hostel))
            {
                hostel = "";
            }

            if (string.IsNullOrEmpty(emailid))
            {
                emailid = "";
            }
            if (string.IsNullOrEmpty(whnumber))
            {
                whnumber = "";
            }



            string username = HttpContext.Session.GetString("username");
            //string username = "202401010001";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "Update  Regmaster set partinsport = @partinsport, spouse=@css,ncc=@ncc," +
                "scout=@scout,hostel=@hostel,emailid=@emailid,whatsapp=@whatsapp where registrationid = @registrationid";

            SqlCommand comm = new SqlCommand(query, connection);
            comm.Parameters.AddWithValue("@partinsport", insports);

            comm.Parameters.AddWithValue("@css", cssuniversity);

            comm.Parameters.AddWithValue("@ncc", nccnss);

            comm.Parameters.AddWithValue("@scout", scoutguide);

            comm.Parameters.AddWithValue("@hostel", hostel);

            comm.Parameters.AddWithValue("@emailid", emailid);

            comm.Parameters.AddWithValue("@whatsapp", whnumber);


            comm.Parameters.AddWithValue("@registrationid", username);


            comm.ExecuteNonQuery();

            connection.Close();


            return RedirectToAction("ProceedSelectionCopy","Admission");
        }




       [Authorize(Roles = "student")]
        public IActionResult ProceedSelectionCopy()
        {


            string uname = HttpContext.Session.GetString("username");
            string permit = HttpContext.Session.GetString("permit");
            ViewBag.uname = uname;
            ViewBag.permit = permit;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select tenyear, tenmarksobt, tenmaxmark,tendiv,tenper,tengroup," +
                "tenschool,tenboard, twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool," +
                "twboard  from regmaster where registrationid = @uname";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@uname", uname);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                ViewBag.tenyear = reader.GetString(0);
                ViewBag.tenmarks = reader.GetString(1);
                ViewBag.tenmax = reader.GetString(2);
                ViewBag.tendiv = reader.GetString(3);
                ViewBag.tenper = reader.GetString(4);
                ViewBag.tengp = reader.GetString(5);
                ViewBag.tenschool = reader.GetString(6);
                ViewBag.tenboard = reader.GetString(7);


                ViewBag.twyear = reader.GetString(8);
                ViewBag.twmarks = reader.GetString(9);
                ViewBag.twmax = reader.GetString(10);
                ViewBag.twdiv = reader.GetString(11);
                ViewBag.twper = reader.GetString(12);
                ViewBag.twgp = reader.GetString(13);
                ViewBag.twschool = reader.GetString(14);
                ViewBag.twboard = reader.GetString(15);



            }

            connection.Close();





            return View();
        }







        [HttpPost]
        public IActionResult UpdateProceedSelection1(
        string tenyear,string tenmarks,string  tenmaxmarks,string  tendiv,string tenpercent,string tengroup,
        string tenstudycenter,string tenboard,string twelyear,string twelmarks,string twelmaxmarks,string tweldiv
            ,string twelpercent,string twelgroup ,string twelstudycenter,string twelboard
            )
        {

            if (string.IsNullOrEmpty(tenyear))
            {
                tenyear = "";
            }

            if (string.IsNullOrEmpty(tenmarks))
            {
                tenmarks = "";
            }

            if (string.IsNullOrEmpty(tenmaxmarks))
            {
                tenmaxmarks = "";
            }
            if (string.IsNullOrEmpty(tendiv))
            {
                tendiv = "";  
            }
            if (string.IsNullOrEmpty(tenpercent))
            {
                tenpercent = "";
            }
            if (string.IsNullOrEmpty(tengroup))
            {
                tengroup = "";
            }
            if (string.IsNullOrEmpty(tenstudycenter))
            {
                tenstudycenter = "";
            }

            if (string.IsNullOrEmpty(tenboard))
            {
                tenboard = "";
            }
            if (string.IsNullOrEmpty(twelyear))
            {
                twelyear = "";
            }
            if (string.IsNullOrEmpty(twelmarks))
            {
                twelmarks = "";
            }
            if (string.IsNullOrEmpty(twelmaxmarks))
            {
                twelmaxmarks = "";
            }
            if (string.IsNullOrEmpty(tweldiv))
            {
                tweldiv = "";
            }
            if (string.IsNullOrEmpty(twelpercent))
            {
                twelpercent = "";
            }
            if (string.IsNullOrEmpty(twelgroup))
            {
                twelgroup = "";
            }
            if (string.IsNullOrEmpty(twelstudycenter))
            {
                twelstudycenter = "";
            }
            if (string.IsNullOrEmpty(twelboard))
            {
                twelboard = "";
            }
           


            string username = HttpContext.Session.GetString("username");
            //string username = "202401010001";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "update regmaster set tenyear=@tenyear, tenmarksobt = @tenmarksobt,tenmaxmark=@tenmaxmark," +
                "tendiv=@tendiv,tenper=@tenper,tengroup=@tengroup,tenschool=@tenschool,tenboard=@tenboard ," +
                "twyear = @twyear, twmarksobt = @twmarksobt, twmaxmark = @twmaxmark," +
                "twdiv=@twdiv,twper=@twper,twgroup=@twgroup,twschool=@twschool,twboard=@twboard where registrationid=@registrationid";



            SqlCommand comm = new SqlCommand(query, connection);
            comm.Parameters.AddWithValue("@tenyear", tenyear);
            comm.Parameters.AddWithValue("@tenmarksobt", tenmarks);
            comm.Parameters.AddWithValue("@tenmaxmark", tenmaxmarks);
            comm.Parameters.AddWithValue("@tendiv", tendiv);
            comm.Parameters.AddWithValue("@tenper", tenpercent);
            comm.Parameters.AddWithValue("@tengroup", tengroup);
            comm.Parameters.AddWithValue("@tenschool", tenstudycenter);
            comm.Parameters.AddWithValue("@tenboard", tenboard);

            comm.Parameters.AddWithValue("@twyear", twelyear);
            comm.Parameters.AddWithValue("@twmarksobt", twelmarks);
            comm.Parameters.AddWithValue("@twmaxmark", twelmaxmarks);
            comm.Parameters.AddWithValue("@twdiv", tweldiv);
            comm.Parameters.AddWithValue("@twper", twelpercent);
            comm.Parameters.AddWithValue("@twgroup", twelgroup);
            comm.Parameters.AddWithValue("@twschool", twelstudycenter);
            comm.Parameters.AddWithValue("@twboard", twelboard);
            comm.Parameters.AddWithValue("@registrationid", username);


            comm.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("ProceedSelectionCopy1", "Admission");


        }





        [Authorize(Roles = "student")]
        public IActionResult ProceedSelectionCopy1()
        {


            string uname = HttpContext.Session.GetString("username");
            string permit = HttpContext.Session.GetString("permit");
            ViewBag.uname = uname;
            ViewBag.permit = permit;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select ugyear, ugmarksobt, ugmaxmark,ugdiv,ugper,uggroup," +
                "ugschool,ugboard, pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool," +
                "pgboard,punish  from regmaster where registrationid = @uname";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@uname", uname);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                ViewBag.ugyear = reader.GetString(0);
                ViewBag.ugmarks = reader.GetString(1);
                ViewBag.ugmax = reader.GetString(2);
                ViewBag.ugdiv = reader.GetString(3);
                ViewBag.ugper = reader.GetString(4);
                ViewBag.uggp = reader.GetString(5);
                ViewBag.ugschool = reader.GetString(6);
                ViewBag.ugboard = reader.GetString(7);


                ViewBag.pgyear = reader.GetString(8);
                ViewBag.pgmarks = reader.GetString(9);
                ViewBag.pgmax = reader.GetString(10);
                ViewBag.pgdiv = reader.GetString(11);
                ViewBag.pgper = reader.GetString(12);
                ViewBag.pggp = reader.GetString(13);
                ViewBag.pgschool = reader.GetString(14);
                ViewBag.pgboard = reader.GetString(15);
                ViewBag.punish = reader.GetString(16);


            }

            connection.Close();


            return View();
        }


        [HttpPost]
        public IActionResult UpdateProceedSelection2(
           string ugpassyear,string ugmarks, string ugmaxmarks, string ugdiv,
           string ugpercent,string uggroup,
           string ugcollege,string ugunivercity,
          string pgyear,string pgmarks,string pgmaxmarks,string pgdiv,string pgpercent,string pggroup,
           string pgcollege,string pgunivercity,string offence)
        { 


            if (string.IsNullOrEmpty(ugpassyear))
            {
                ugpassyear = "";

            }

            if (string.IsNullOrEmpty(ugmarks))
            {
                ugmarks = "";
            }
            if (string.IsNullOrEmpty(ugmaxmarks))
            {
                ugmaxmarks = "";
            }

            if (string.IsNullOrEmpty(ugdiv))
            {
                ugdiv = "";
            }
            if (string.IsNullOrEmpty(ugpercent))
            {
                ugpercent = "";
            }
            if (string.IsNullOrEmpty(uggroup))
            {
                uggroup = "";
            }
            if (string.IsNullOrEmpty(ugcollege))
            {
                ugcollege = "";
            }
            if (string.IsNullOrEmpty(ugunivercity))
            {
                ugunivercity = "";
            }





            if (string.IsNullOrEmpty(pgyear))
            {
                pgyear = "";
            }

            if (string.IsNullOrEmpty(pgmarks))
            {
                pgmarks = "";
            }
            if (string.IsNullOrEmpty(pgmaxmarks))
            {
                pgmaxmarks = "";
            }

            if (string.IsNullOrEmpty(pgdiv))
            {
                pgdiv = "";
            }
            if (string.IsNullOrEmpty(pgpercent))
            {
                pgpercent = "";
            }
            if (string.IsNullOrEmpty(pggroup))
            {
                pggroup = "";
            }
            if (string.IsNullOrEmpty(pgcollege))
            {
                pgcollege = "";
            }
            if (string.IsNullOrEmpty(pgunivercity))
            {
                pgunivercity = "";
            }


            if (string.IsNullOrEmpty(offence))
            {
                offence = "";
            }


            string username = HttpContext.Session.GetString("username");
            //string username = "202401010001";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string query = "update regmaster set ugyear = @ugyear, ugmarksobt = @ugmarksobt,ugmaxmark=@ugmaxmark," +
                "ugdiv=@ugdiv,ugper=@ugper,uggroup=@uggroup,ugschool=@ugschool,ugboard=@ugboard ," +
                "pgyear = @pgyear, pgmarksobt = @pgmarksobt, pgmaxmark = @pgmaxmark," +
                "pgdiv=@pgdiv,pgper=@pgper,pggroup=@pggroup,pgschool=@pgschool,pgboard=@pgboard, punish=@punish where registrationid=@registrationid";



            SqlCommand comm = new SqlCommand(query, connection);
            comm.Parameters.AddWithValue("@ugyear", ugpassyear);
            comm.Parameters.AddWithValue("@ugmarksobt",ugmarks);
            comm.Parameters.AddWithValue("@ugmaxmark", ugmaxmarks);
            comm.Parameters.AddWithValue("@ugdiv", ugdiv);
            comm.Parameters.AddWithValue("@ugper", ugpercent);
            comm.Parameters.AddWithValue("@uggroup", uggroup);
            comm.Parameters.AddWithValue("@ugschool", ugcollege);
            comm.Parameters.AddWithValue("@ugboard", ugunivercity);

            comm.Parameters.AddWithValue("@pgyear", pgyear);
            comm.Parameters.AddWithValue("@pgmarksobt", pgmarks);
            comm.Parameters.AddWithValue("@pgmaxmark", pgmaxmarks);
            comm.Parameters.AddWithValue("@pgdiv", pgdiv);
            comm.Parameters.AddWithValue("@pgper", pgpercent);
            comm.Parameters.AddWithValue("@pggroup", pggroup);
            comm.Parameters.AddWithValue("@pgschool", pgcollege);
            comm.Parameters.AddWithValue("@pgboard", pgunivercity);
            comm.Parameters.AddWithValue("@punish",offence);
            comm.Parameters.AddWithValue("@registrationid", username);


            comm.ExecuteNonQuery();

            connection.Close();



            return RedirectToAction("ProceedSelectionCopy2", "Admission");
        }



        [Authorize(Roles = "student")]
        public IActionResult ProceedSelectionCopy2()
        {
            string uname = HttpContext.Session.GetString("username");
            string permit = HttpContext.Session.GetString("permit");
            ViewBag.uname = uname;
            ViewBag.permit = permit;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProceedSelection3(IFormFile file1, IFormFile file2, IFormFile file3, IFormFile file4,
            IFormFile file5, IFormFile file6, IFormFile file7, IFormFile file8, IFormFile file9, IFormFile file10, IFormFile file11, IFormFile file12
            , IFormFile file13, IFormFile file14, IFormFile file15, IFormFile file16, IFormFile file17)
        {

            string directloc = Path.Combine(_environment.ContentRootPath, "wwwroot\\images");
            string[] fyles = Directory.GetFiles(directloc);
            


            //string uname = "202401010001";
           string uname = HttpContext.Session.GetString("username");
            string newFileName = "";
            List<IFormFile> files = new List<IFormFile>();  
            files.Add(file1);
            files.Add(file2);
            files.Add(file3);
            files.Add(file4);
            files.Add(file5);
            files.Add(file6);
            files.Add(file7);
            files.Add(file8);
            files.Add(file9);
            files.Add(file10);
            files.Add(file11);
            files.Add(file12);
            files.Add(file13);
            files.Add(file14);
            files.Add(file15);
            files.Add(file16);
            files.Add(file17);

            string f1name = ""; string f2name = ""; string f3name = ""; string f4name = ""; string f5name = ""; string f6name = "";
            string f7name = ""; string f8name = ""; string f9name = ""; string f10name = ""; string f11name = ""; string f12name = "";
            string f13name = ""; string f14name = ""; string f15name = ""; string f16name = ""; string f17name = "";




            int countf = 1;
            string rawfilename = "";

            foreach (var formFile in files)
            {
                if (formFile != null)
                {



                    string extension = "";
                    if (countf == 1)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename1";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename1" + extension;

                    }
                    else if (countf == 2)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename2";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename2" + extension;

                    }


                    else if (countf == 3)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename3";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename3" + extension;

                    }



                    else if (countf == 4)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename4";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename4" + extension;

                    }

                    else if (countf == 5)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename5";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename5" + extension;

                    }

                    else if (countf == 6)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename6";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename6" + extension;

                    }
                    else if (countf == 7)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename7";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename7" + extension;

                    }

                    else if (countf == 8)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename8";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename8" + extension;

                    }

                    else if (countf == 9)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename9";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename9" + extension;

                    }
                    else if (countf == 10)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename10";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename10" + extension;

                    }
                    else if (countf == 11)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename11";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename11" + extension;

                    }
                    else if (countf == 12)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename12";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename12" + extension;

                    }

                    else if (countf == 13)
                    {
                       
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename13";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);
                                
                            }

                        }

                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename13" + extension;


                    }
                    else if (countf == 14)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename14";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename14" + extension;

                    }
                    else if (countf == 15)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename15";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename15" + extension;

                    }

                    else if (countf == 16)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename16";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename16" + extension;

                    }
                    else if (countf == 17)
                    {
                        foreach (string fyle in fyles)
                        {
                            string temp = uname + "filename17";
                            rawfilename = Path.GetFileNameWithoutExtension(fyle);
                            if (rawfilename == temp)
                            {
                                System.IO.File.Delete(fyle);

                            }

                        }
                        extension = Path.GetExtension(formFile.FileName);
                        newFileName = uname + "filename17" + extension;

                    }




                    if (formFile.Length > 0)
                    {
                       
                        var filepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", formFile.FileName);
                        bool exists = System.IO.Directory.Exists(filepath);
                        if (!exists)
                        {
                           
                            string newfilepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", newFileName);
                            using var stream = new FileStream(newfilepath, FileMode.Create);
                            await formFile.CopyToAsync(stream);
                            Console.WriteLine("not exists");
                        }
                        else
                        {
                            string newfilepath = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", newFileName);
                            using var stream = new FileStream(newfilepath, FileMode.Create);
                            await formFile.CopyToAsync(stream);
                            
                            Console.WriteLine("exists");
                        }

                         


                    }

                    countf = countf + 1;
                }
                else
                {
                    countf = countf + 1;
                }

            }
            string ext = "";
            string newfilenm = "";

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "update regmaster set att1 = @att1,att2 = @att2, att3 = @att3, att4 = @att4, att5 = @att5 ,att6 = @att6,att7 = @att7, att8 = @att8, att9 = @att9, att10 = @att10" +
            ",att11 = @att11,att12 = @att12, att13 = @att13, att14 = @att14, att15 = @att15, att16 = @att16, att17 = @att17 where registrationid = @registrationid";

           // string query = "update regmaster set att17 = @att17 where registrationid = @registrationid";


            SqlCommand command = new SqlCommand(query,connection);
            if (file1 != null)
            {
                ext = Path.GetExtension(file1.FileName);
                newfilenm = uname + "filename1" + ext;
                command.Parameters.AddWithValue("@att1", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att1", "");
            }

            if (file2!= null)
            {
                ext = Path.GetExtension(file2.FileName);
                newfilenm = uname + "filename2" + ext;
                command.Parameters.AddWithValue("@att2", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att2", "");
            }

            if (file3!= null)
            {
                ext = Path.GetExtension(file3.FileName);
                newfilenm = uname + "filename3" + ext;
                command.Parameters.AddWithValue("@att3", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att3", "");
            }

            if (file4 != null)
            {
                ext = Path.GetExtension(file4.FileName);
                newfilenm = uname + "filename4" + ext;
                command.Parameters.AddWithValue("@att4", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att4", "");
            }

            if (file5!= null)
            {
                ext = Path.GetExtension(file5.FileName);
                newfilenm = uname + "filename5" + ext;
                command.Parameters.AddWithValue("@att5", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att5", "");
            }


            if (file6 != null)
            {
                ext = Path.GetExtension(file17.FileName);
                newfilenm = uname + "filename6" + ext;
                command.Parameters.AddWithValue("@att6", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att6", "");
            }

            if (file7 != null)
            {
                ext = Path.GetExtension(file7.FileName);
                newfilenm = uname + "filename7" + ext;
                command.Parameters.AddWithValue("@att7", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att7", "");
            }

            if (file8 != null)
            {
                ext = Path.GetExtension(file8.FileName);
                newfilenm = uname + "filename8" + ext;
                command.Parameters.AddWithValue("@att8", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att8", "");
            }

            if (file9 != null)
            {
                ext = Path.GetExtension(file9.FileName);
                newfilenm = uname + "filename9" + ext;
                command.Parameters.AddWithValue("@att9", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att9", "");
            }


            if (file10 != null)
            {
                ext = Path.GetExtension(file10.FileName);
                newfilenm = uname + "filename10" + ext;
                command.Parameters.AddWithValue("@att10", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att10", "");
            }

            if (file11 != null)
            {
                ext = Path.GetExtension(file11.FileName);
                newfilenm = uname + "filename11" + ext;
                command.Parameters.AddWithValue("@att11", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att11", "");
            }

            if (file12 != null)
            {
                ext = Path.GetExtension(file12.FileName);
                newfilenm = uname + "filename12" + ext;
                command.Parameters.AddWithValue("@att12", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att12", "");
            }

            if (file13 != null)
            {
                ext = Path.GetExtension(file13.FileName);
                newfilenm = uname + "filename13" + ext;
                command.Parameters.AddWithValue("@att13", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att13", "");
            }

            if (file14 != null)
            {
                ext = Path.GetExtension(file14.FileName);
                newfilenm = uname + "filename14" + ext;
                command.Parameters.AddWithValue("@att14", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att14", "");
            }

            if (file15 != null)
            {
                ext = Path.GetExtension(file15.FileName);
                newfilenm = uname + "filename15" + ext;
                command.Parameters.AddWithValue("@att15", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att15", "");
            }


            if (file16 != null)
            {
                ext = Path.GetExtension(file16.FileName);
                newfilenm = uname + "filename16" + ext;
                command.Parameters.AddWithValue("@att16", newfilenm);
            }
            else
            {


                command.Parameters.AddWithValue("@att16", "");
            }

            if (file17!=null)
            {
                ext = Path.GetExtension(file17.FileName);
                newfilenm = uname + "filename17" + ext;
                command.Parameters.AddWithValue("@att17", newfilenm);
            }
           else
            {

              
                command.Parameters.AddWithValue("@att17", "");
            }

            command.Parameters.AddWithValue("@registrationid",uname);


            command.ExecuteNonQuery();

            connection.Close();

            return RedirectToAction("ProceedSelectionCopy3", "Admission");
        }


       [Authorize(Roles = "student")]
        public IActionResult ProceedSelectionCopy3()
        {
            string uname = HttpContext.Session.GetString("username");
            ViewBag.uname = uname;
            return View();
        }

        [HttpPost]
        public IActionResult  InitiatePayment()
        {
            string username = HttpContext.Session.GetString("username");

            ViewBag.email = username;

            SqlConnection connection = new SqlConnection(conn);
            string query = "select ";


            string key = "rzp_live_3NLZP2r70O1kQx";
            string secret = "3NPzxPPbyrn1tRqVtxef5sqZ";

            Random _random = new Random();

            string TransactionId = _random.Next(0, 10000).ToString();


            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", Convert.ToDecimal(200) * 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", TransactionId);


            RazorpayClient client = new RazorpayClient(key, secret);

            Razorpay.Api.Order order = client.Order.Create(input);
            ViewBag.orderid = order["id"].ToString();
            return View("Payment");

        }





        [HttpPost]
        public async Task<IActionResult> SelectCourses(string levelnm,string coursenm)
        {

            Console.WriteLine(levelnm);
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            if (string.IsNullOrEmpty(coursenm))
            {
                string query = "Select Cname from  CourseMaster where clavel=@clavel";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@clavel", levelnm);
                SqlDataReader reader = cmd.ExecuteReader();
                var courses = new List<Courses>();
                while (reader.Read())
                {
                    Courses course = new Courses();

                    course.CName = reader.GetString(0);

                    courses.Add(course);

                    ViewData["courses"] = courses;

                }

                return PartialView("_CoursePartial");


            }

            else
            {
                string query = "Select cduration from CourseMaster where cname=@cname";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@cname", coursenm);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ViewBag.duration = reader.GetString(0);

                }

                return PartialView("_DurationPartial");

            }



        }

        [HttpPost]
        public IActionResult UpdateSelectCourses(string lname,string Cname,
            string Cacadyear,string unenroll, string admcategory, string unmerit)
        
        {

            string permit = HttpContext.Session.GetString("permit");

            if(permit!=null)
            {
                HttpContext.Session.Remove("permit");
            }

            if (string.IsNullOrEmpty(lname))

            {
                lname = "";
            }

            if (string.IsNullOrEmpty(Cname))

            {
                Cname = "";
            }


            if (string.IsNullOrEmpty(Cacadyear))

            {
                Cacadyear = "";
            }


            if (string.IsNullOrEmpty(unenroll))

            {
                unenroll = "";
            }

            if (string.IsNullOrEmpty(admcategory))

            {
                admcategory = "";
            }


            if (string.IsNullOrEmpty(unmerit))

            {
                unmerit = "";
            }


            string stid = "";
            string query = "";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

           
            query = "select count(*) from regmaster where rlevel = @lname";
           

           
            SqlCommand command = new SqlCommand(query, connection);

            if(lname == "UG")
            {
                command.Parameters.AddWithValue("@lname","UG");
            }
            else if(lname == "PG")
            {
                command.Parameters.AddWithValue("@lname", "PG");
            }

            else
            {
                command.Parameters.AddWithValue("@lname", "PhD");
            }

            int stcount = (Int32)command.ExecuteScalar();

            connection.Close();


            Console.WriteLine(stid);
            Console.WriteLine(stcount);
            Console.WriteLine(Cacadyear);

            if (stcount > 0) 
            {

                stcount = stcount + 1;

                int stcounttemp = stcount;

                int count = 0;
                while (stcounttemp > 0)
                {
                    stcounttemp = stcounttemp / 10;
                    count++;
                }



                if (count == 3)
                {
                    stid = "0" + stcount;
                }
                else if (count == 2)
                {
                    stid = "00" + stcount;
                }
                else
                {
                    stid = "000" + stcount;
                }


                if (lname == "UG")
                {
                    if (Cacadyear == "1st year")
                    {
                        stid = "2024" + "01" + "01" + stid;

                    }

                    else if (Cacadyear == "2nd year")
                    {
                        stid = "2024" + "01" + "02" + stid;
                    }
                    else
                    {
                        stid = "2024" + "01" + "03" + stid;
                    }

                    SqlConnection connection1 = new SqlConnection(conn);
                    connection1.Open();

                    string query1 = "insert into regmaster(rlevel, course, acadyear,uniregno,admcategory,merit,name,fatname,gauname,mothname,dob," +
                                            "nationality,gender,categ,scateg,address,town,tehsil,post,thana,district,state,pin,partinsport,spouse,ncc,scout," +
                                            "hostel,emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark,tendiv,tenper,tengroup,tenschool," +
                                            "tenboard,twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                                            "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                                            "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard,punish," +
                                            "att1,att2,att3,att4,att5,att6,att7,att8,att9,att10,att11,att12,att13,att14," +
                                            "att15,att16,att17,remark,regdate,registrationid,rstatus)" +
                                            "values(@rlevel, @course, @acadyear,@uniregno,@admcategory,@merit,@name,@fatname,@gauname,@mothname,@dob," +
                                            "@nationality,@gender,@categ,@scateg,@address,@town,@tehsil,@post,@thana,@district,@state,@pin,@partinsport,@spouse,@ncc,@scout," +
                                            "@hostel,@emailid,@whatsapp,@tenyear,@tenmarksobt,@tenmaxmark,@tendiv,@tenper,@tengroup,@tenschool," +
                                           "@tenboard,@twyear,@twmarksobt,@twmaxmark,@twdiv,@twper,@twgroup,@twschool,@twboard," +
                                            "@ugyear,@ugmarksobt,@ugmaxmark,@ugdiv,@ugper,@uggroup,@ugschool,@ugboard," +
                                            "@pgyear,@pgmarksobt,@pgmaxmark,@pgdiv,@pgper,@pggroup,@pgschool,@pgboard,@punish," +
                                            "@att1,@att2,@att3,@att4,@att5,@att6,@att7,@att8,@att9,@att10,@att11,@att12,@att13,@att14," +
                                            "@att15,@att16,@att17,@remark,@regdate,@registrationid,@rstatus)";

                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    command1.Parameters.AddWithValue("@rlevel", lname);
                    command1.Parameters.AddWithValue("@course", Cname);

                    command1.Parameters.AddWithValue("@acadyear", Cacadyear);

                    command1.Parameters.AddWithValue("@uniregno", unenroll);

                    command1.Parameters.AddWithValue("@admcategory", admcategory);

                    command1.Parameters.AddWithValue("@merit", unmerit);
                    command1.Parameters.AddWithValue("@name", "");
                    command1.Parameters.AddWithValue("@fatname", "");
                    command1.Parameters.AddWithValue("@gauname", "");
                    command1.Parameters.AddWithValue("@mothname", "");

                    command1.Parameters.AddWithValue("@dob", "");
                    command1.Parameters.AddWithValue("@nationality", "");

                    command1.Parameters.AddWithValue("@gender", "");

                    command1.Parameters.AddWithValue("@categ", "");

                    command1.Parameters.AddWithValue("@scateg", "");

                    command1.Parameters.AddWithValue("@address", "");
                    command1.Parameters.AddWithValue("@town", "");
                    command1.Parameters.AddWithValue("@tehsil", "");
                    command1.Parameters.AddWithValue("@post", "");
                    command1.Parameters.AddWithValue("@thana", "");
                    command1.Parameters.AddWithValue("@district", "");
                    command1.Parameters.AddWithValue("@state", "");

                    command1.Parameters.AddWithValue("@pin", "");

                    command1.Parameters.AddWithValue("@partinsport", "");

                    command1.Parameters.AddWithValue("@spouse", "");

                    command1.Parameters.AddWithValue("@ncc", "");
                    command1.Parameters.AddWithValue("@scout", "");
                    command1.Parameters.AddWithValue("@hostel", "");
                    command1.Parameters.AddWithValue("@emailid", "");
                    command1.Parameters.AddWithValue("@whatsapp", "");



                    command1.Parameters.AddWithValue("@tenyear", "");
                    command1.Parameters.AddWithValue("@tenmarksobt", "");
                    command1.Parameters.AddWithValue("@tenmaxmark", "");
                    command1.Parameters.AddWithValue("@tendiv", "");
                    command1.Parameters.AddWithValue("@tenper", "");
                    command1.Parameters.AddWithValue("@tengroup", "");
                    command1.Parameters.AddWithValue("@tenschool", "");
                    command1.Parameters.AddWithValue("@tenboard", "");



                    command1.Parameters.AddWithValue("@twyear", "");
                    command1.Parameters.AddWithValue("@twmarksobt", "");
                    command1.Parameters.AddWithValue("@twmaxmark", "");
                    command1.Parameters.AddWithValue("@twdiv", "");
                    command1.Parameters.AddWithValue("@twper", "");
                    command1.Parameters.AddWithValue("@twgroup", "");
                    command1.Parameters.AddWithValue("@twschool", "");
                    command1.Parameters.AddWithValue("@twboard", "");

                    command1.Parameters.AddWithValue("@ugyear", "");
                    command1.Parameters.AddWithValue("@ugmarksobt", "");
                    command1.Parameters.AddWithValue("@ugmaxmark", "");
                    command1.Parameters.AddWithValue("@ugdiv", "");
                    command1.Parameters.AddWithValue("@ugper", "");
                    command1.Parameters.AddWithValue("@uggroup", "");
                    command1.Parameters.AddWithValue("@ugschool", "");
                    command1.Parameters.AddWithValue("@ugboard", "");






                    command1.Parameters.AddWithValue("@pgyear", "");
                    command1.Parameters.AddWithValue("@pgmarksobt", "");
                    command1.Parameters.AddWithValue("@pgmaxmark", "");
                    command1.Parameters.AddWithValue("@pgdiv", "");
                    command1.Parameters.AddWithValue("@pgper", "");
                    command1.Parameters.AddWithValue("@pggroup", "");
                    command1.Parameters.AddWithValue("@pgschool", "");
                    command1.Parameters.AddWithValue("@pgboard", "");

                    command1.Parameters.AddWithValue("@punish", "");

                    command1.Parameters.AddWithValue("@att1", "");
                    command1.Parameters.AddWithValue("@att2", "");
                    command1.Parameters.AddWithValue("@att3", "");
                    command1.Parameters.AddWithValue("@att4", "");
                    command1.Parameters.AddWithValue("@att5", "");
                    command1.Parameters.AddWithValue("@att6", "");
                    command1.Parameters.AddWithValue("@att7", "");
                    command1.Parameters.AddWithValue("@att8", "");
                    command1.Parameters.AddWithValue("@att9", "");
                    command1.Parameters.AddWithValue("@att10", "");
                    command1.Parameters.AddWithValue("@att11", "");
                    command1.Parameters.AddWithValue("@att12", "");
                    command1.Parameters.AddWithValue("@att13", "");
                    command1.Parameters.AddWithValue("@att14", "");
                    command1.Parameters.AddWithValue("@att15", "");
                    command1.Parameters.AddWithValue("@att16", "");
                    command1.Parameters.AddWithValue("@att17", "");
                   

                    DateTime dt = DateTime.Now;
                    dt = dt.Date;
                    command1.Parameters.AddWithValue("@remark", "");
                    command1.Parameters.AddWithValue("@regdate", dt);
                    command1.Parameters.AddWithValue("@registrationid", stid);
                    command1.Parameters.AddWithValue("@rstatus", "0");

                    command1.ExecuteNonQuery();

                    //connection1.Close();


                    string uname = stid;
                    string utype = "student";
                   

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                    claims.Add(new Claim(ClaimTypes.Name, uname ));
                    if (utype == "student")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "student"));
                       

                    }
                   
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);

                    string loginquery = "insert into loginmaster(username, userid,password,mobno,address,usertype,remark)" +
                    "values(@username,@userid,@password,@mobno,@address,@usertype,@remark)";
                    SqlCommand command2 = new SqlCommand(loginquery,connection1);
                    command2.Parameters.AddWithValue("@username","");
                    command2.Parameters.AddWithValue("@userid", stid);
                    command2.Parameters.AddWithValue("@password", stid);
                    command2.Parameters.AddWithValue("@mobno", "");
                    command2.Parameters.AddWithValue("@address", "");
                    command2.Parameters.AddWithValue("@usertype", "student");
                    command2.Parameters.AddWithValue("@remark", "good");
                    command2.ExecuteNonQuery();
                    connection1.Close();


                    Console.WriteLine("UG" + stid);

                }

                else if(lname == "PG")
                {
                    if (Cacadyear == "1st year")
                    {
                        stid = "2024" + "02" + "01" + stid;
                    }

                    else
                    {
                        stid = "2024" + "02" + "02" + stid;
                    }





                    SqlConnection connection1 = new SqlConnection(conn);
                    connection1.Open();

                    string query1 = "insert into regmaster(rlevel, course, acadyear,uniregno,admcategory,merit,name,fatname,gauname,mothname,dob," +
                                            "nationality,gender,categ,scateg,address,town,tehsil,post,thana,district,state,pin,partinsport,spouse,ncc,scout," +
                                            "hostel,emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark,tendiv,tenper,tengroup,tenschool," +
                                            "tenboard,twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                                            "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                                            "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard,punish," +
                                            "att1,att2,att3,att4,att5,att6,att7,att8,att9,att10,att11,att12,att13,att14," +
                                            "att15,att16,att17,remark,regdate,registrationid,rstatus)" +
                                            "values(@rlevel, @course, @acadyear,@uniregno,@admcategory,@merit,@name,@fatname,@gauname,@mothname,@dob," +
                                            "@nationality,@gender,@categ,@scateg,@address,@town,@tehsil,@post,@thana,@district,@state,@pin,@partinsport,@spouse,@ncc,@scout," +
                                            "@hostel,@emailid,@whatsapp,@tenyear,@tenmarksobt,@tenmaxmark,@tendiv,@tenper,@tengroup,@tenschool," +
                                           "@tenboard,@twyear,@twmarksobt,@twmaxmark,@twdiv,@twper,@twgroup,@twschool,@twboard," +
                                            "@ugyear,@ugmarksobt,@ugmaxmark,@ugdiv,@ugper,@uggroup,@ugschool,@ugboard," +
                                            "@pgyear,@pgmarksobt,@pgmaxmark,@pgdiv,@pgper,@pggroup,@pgschool,@pgboard,@punish," +
                                            "@att1,@att2,@att3,@att4,@att5,@att6,@att7,@att8,@att9,@att10,@att11,@att12,@att13,@att14," +
                                            "@att15,@att16,@att17,@remark,@regdate,@registrationid,@rstatus)";

                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    command1.Parameters.AddWithValue("@rlevel", lname);
                    command1.Parameters.AddWithValue("@course", Cname);

                    command1.Parameters.AddWithValue("@acadyear", Cacadyear);

                    command1.Parameters.AddWithValue("@uniregno", unenroll);

                    command1.Parameters.AddWithValue("@admcategory", admcategory);

                    command1.Parameters.AddWithValue("@merit", unmerit);
                    command1.Parameters.AddWithValue("@name", "");
                    command1.Parameters.AddWithValue("@fatname", "");
                    command1.Parameters.AddWithValue("@gauname", "");
                    command1.Parameters.AddWithValue("@mothname", "");

                    command1.Parameters.AddWithValue("@dob", "");
                    command1.Parameters.AddWithValue("@nationality", "");

                    command1.Parameters.AddWithValue("@gender", "");

                    command1.Parameters.AddWithValue("@categ", "");

                    command1.Parameters.AddWithValue("@scateg", "");

                    command1.Parameters.AddWithValue("@address", "");
                    command1.Parameters.AddWithValue("@town", "");
                    command1.Parameters.AddWithValue("@tehsil", "");
                    command1.Parameters.AddWithValue("@post", "");
                    command1.Parameters.AddWithValue("@thana", "");
                    command1.Parameters.AddWithValue("@district", "");
                    command1.Parameters.AddWithValue("@state", "");

                    command1.Parameters.AddWithValue("@pin", "");

                    command1.Parameters.AddWithValue("@partinsport", "");

                    command1.Parameters.AddWithValue("@spouse", "");

                    command1.Parameters.AddWithValue("@ncc", "");
                    command1.Parameters.AddWithValue("@scout", "");
                    command1.Parameters.AddWithValue("@hostel", "");
                    command1.Parameters.AddWithValue("@emailid", "");
                    command1.Parameters.AddWithValue("@whatsapp", "");



                    command1.Parameters.AddWithValue("@tenyear", "");
                    command1.Parameters.AddWithValue("@tenmarksobt", "");
                    command1.Parameters.AddWithValue("@tenmaxmark", "");
                    command1.Parameters.AddWithValue("@tendiv", "");
                    command1.Parameters.AddWithValue("@tenper", "");
                    command1.Parameters.AddWithValue("@tengroup", "");
                    command1.Parameters.AddWithValue("@tenschool", "");
                    command1.Parameters.AddWithValue("@tenboard", "");



                    command1.Parameters.AddWithValue("@twyear", "");
                    command1.Parameters.AddWithValue("@twmarksobt", "");
                    command1.Parameters.AddWithValue("@twmaxmark", "");
                    command1.Parameters.AddWithValue("@twdiv", "");
                    command1.Parameters.AddWithValue("@twper", "");
                    command1.Parameters.AddWithValue("@twgroup", "");
                    command1.Parameters.AddWithValue("@twschool", "");
                    command1.Parameters.AddWithValue("@twboard", "");

                    command1.Parameters.AddWithValue("@ugyear", "");
                    command1.Parameters.AddWithValue("@ugmarksobt", "");
                    command1.Parameters.AddWithValue("@ugmaxmark", "");
                    command1.Parameters.AddWithValue("@ugdiv", "");
                    command1.Parameters.AddWithValue("@ugper", "");
                    command1.Parameters.AddWithValue("@uggroup", "");
                    command1.Parameters.AddWithValue("@ugschool", "");
                    command1.Parameters.AddWithValue("@ugboard", "");






                    command1.Parameters.AddWithValue("@pgyear", "");
                    command1.Parameters.AddWithValue("@pgmarksobt", "");
                    command1.Parameters.AddWithValue("@pgmaxmark", "");
                    command1.Parameters.AddWithValue("@pgdiv", "");
                    command1.Parameters.AddWithValue("@pgper", "");
                    command1.Parameters.AddWithValue("@pggroup", "");
                    command1.Parameters.AddWithValue("@pgschool", "");
                    command1.Parameters.AddWithValue("@pgboard", "");

                    command1.Parameters.AddWithValue("@punish", "");

                    command1.Parameters.AddWithValue("@att1", "");
                    command1.Parameters.AddWithValue("@att2", "");
                    command1.Parameters.AddWithValue("@att3", "");
                    command1.Parameters.AddWithValue("@att4", "");
                    command1.Parameters.AddWithValue("@att5", "");
                    command1.Parameters.AddWithValue("@att6", "");
                    command1.Parameters.AddWithValue("@att7", "");
                    command1.Parameters.AddWithValue("@att8", "");
                    command1.Parameters.AddWithValue("@att9", "");
                    command1.Parameters.AddWithValue("@att10", "");
                    command1.Parameters.AddWithValue("@att11", "");
                    command1.Parameters.AddWithValue("@att12", "");
                    command1.Parameters.AddWithValue("@att13", "");
                    command1.Parameters.AddWithValue("@att14", "");
                    command1.Parameters.AddWithValue("@att15", "");
                    command1.Parameters.AddWithValue("@att16", "");
                    command1.Parameters.AddWithValue("@att17", "");

                    DateTime dt = DateTime.Now;
                    dt = dt.Date;
                    command1.Parameters.AddWithValue("@remark", "");
                    command1.Parameters.AddWithValue("@regdate", dt);
                    command1.Parameters.AddWithValue("@registrationid", stid);
                    command1.Parameters.AddWithValue("@rstatus", "0");

                    command1.ExecuteNonQuery();
                    //connection1.Close();




                    string uname = stid;
                    string utype = "student";


                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                    claims.Add(new Claim(ClaimTypes.Name, uname));
                    if (utype == "student")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "student"));


                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);



                    string loginquery = "insert into loginmaster(username, userid,password,mobno,address,usertype,remark)" +
                   "values(@username,@userid,@password,@mobno,@address,@usertype,@remark)";
                    SqlCommand command2 = new SqlCommand(loginquery, connection1);
                    command2.Parameters.AddWithValue("@username", "");
                    command2.Parameters.AddWithValue("@userid", stid);
                    command2.Parameters.AddWithValue("@password", stid);
                    command2.Parameters.AddWithValue("@mobno", "");
                    command2.Parameters.AddWithValue("@address", "");
                    command2.Parameters.AddWithValue("@usertype", "student");
                    command2.Parameters.AddWithValue("@remark", "good");
                    command2.ExecuteNonQuery();
                    connection1.Close();

                    Console.WriteLine("PG" + stid);
                }


                else
                {
                    if (Cacadyear == "1st year")
                    {
                        stid = "2024" + "03" + "01" + stid;
                    }

                    SqlConnection connection1 = new SqlConnection(conn);
                    connection1.Open();

                    string query1 = "insert into regmaster(rlevel, course, acadyear,uniregno,admcategory,merit,name,fatname,gauname,mothname,dob," +
                                            "nationality,gender,categ,scateg,address,town,tehsil,post,thana,district,state,pin,partinsport,spouse,ncc,scout," +
                                            "hostel,emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark,tendiv,tenper,tengroup,tenschool," +
                                            "tenboard,twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                                            "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                                            "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard,punish," +
                                            "att1,att2,att3,att4,att5,att6,att7,att8,att9,att10,att11,att12,att13,att14," +
                                            "att15,att16,att17,remark,regdate,registrationid,rstatus)" +
                                            "values(@rlevel, @course, @acadyear,@uniregno,@admcategory,@merit,@name,@fatname,@gauname,@mothname,@dob," +
                                            "@nationality,@gender,@categ,@scateg,@address,@town,@tehsil,@post,@thana,@district,@state,@pin,@partinsport,@spouse,@ncc,@scout," +
                                            "@hostel,@emailid,@whatsapp,@tenyear,@tenmarksobt,@tenmaxmark,@tendiv,@tenper,@tengroup,@tenschool," +
                                           "@tenboard,@twyear,@twmarksobt,@twmaxmark,@twdiv,@twper,@twgroup,@twschool,@twboard," +
                                            "@ugyear,@ugmarksobt,@ugmaxmark,@ugdiv,@ugper,@uggroup,@ugschool,@ugboard," +
                                            "@pgyear,@pgmarksobt,@pgmaxmark,@pgdiv,@pgper,@pggroup,@pgschool,@pgboard,@punish," +
                                            "@att1,@att2,@att3,@att4,@att5,@att6,@att7,@att8,@att9,@att10,@att11,@att12,@att13,@att14," +
                                            "@att15,@att16,@att17,@remark,@regdate,@registrationid,@rstatus)";

                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    command1.Parameters.AddWithValue("@rlevel", lname);
                    command1.Parameters.AddWithValue("@course", Cname);

                    command1.Parameters.AddWithValue("@acadyear", Cacadyear);

                    command1.Parameters.AddWithValue("@uniregno", unenroll);

                    command1.Parameters.AddWithValue("@admcategory", admcategory);

                    command1.Parameters.AddWithValue("@merit", unmerit);
                    command1.Parameters.AddWithValue("@name", "");
                    command1.Parameters.AddWithValue("@fatname", "");
                    command1.Parameters.AddWithValue("@gauname", "");
                    command1.Parameters.AddWithValue("@mothname", "");

                    command1.Parameters.AddWithValue("@dob", "");
                    command1.Parameters.AddWithValue("@nationality", "");

                    command1.Parameters.AddWithValue("@gender", "");

                    command1.Parameters.AddWithValue("@categ", "");

                    command1.Parameters.AddWithValue("@scateg", "");

                    command1.Parameters.AddWithValue("@address", "");
                    command1.Parameters.AddWithValue("@town", "");
                    command1.Parameters.AddWithValue("@tehsil", "");
                    command1.Parameters.AddWithValue("@post", "");
                    command1.Parameters.AddWithValue("@thana", "");
                    command1.Parameters.AddWithValue("@district", "");
                    command1.Parameters.AddWithValue("@state", "");

                    command1.Parameters.AddWithValue("@pin", "");

                    command1.Parameters.AddWithValue("@partinsport", "");

                    command1.Parameters.AddWithValue("@spouse", "");

                    command1.Parameters.AddWithValue("@ncc", "");
                    command1.Parameters.AddWithValue("@scout", "");
                    command1.Parameters.AddWithValue("@hostel", "");
                    command1.Parameters.AddWithValue("@emailid", "");
                    command1.Parameters.AddWithValue("@whatsapp", "");



                    command1.Parameters.AddWithValue("@tenyear", "");
                    command1.Parameters.AddWithValue("@tenmarksobt", "");
                    command1.Parameters.AddWithValue("@tenmaxmark", "");
                    command1.Parameters.AddWithValue("@tendiv", "");
                    command1.Parameters.AddWithValue("@tenper", "");
                    command1.Parameters.AddWithValue("@tengroup", "");
                    command1.Parameters.AddWithValue("@tenschool", "");
                    command1.Parameters.AddWithValue("@tenboard", "");



                    command1.Parameters.AddWithValue("@twyear", "");
                    command1.Parameters.AddWithValue("@twmarksobt", "");
                    command1.Parameters.AddWithValue("@twmaxmark", "");
                    command1.Parameters.AddWithValue("@twdiv", "");
                    command1.Parameters.AddWithValue("@twper", "");
                    command1.Parameters.AddWithValue("@twgroup", "");
                    command1.Parameters.AddWithValue("@twschool", "");
                    command1.Parameters.AddWithValue("@twboard", "");

                    command1.Parameters.AddWithValue("@ugyear", "");
                    command1.Parameters.AddWithValue("@ugmarksobt", "");
                    command1.Parameters.AddWithValue("@ugmaxmark", "");
                    command1.Parameters.AddWithValue("@ugdiv", "");
                    command1.Parameters.AddWithValue("@ugper", "");
                    command1.Parameters.AddWithValue("@uggroup", "");
                    command1.Parameters.AddWithValue("@ugschool", "");
                    command1.Parameters.AddWithValue("@ugboard", "");






                    command1.Parameters.AddWithValue("@pgyear", "");
                    command1.Parameters.AddWithValue("@pgmarksobt", "");
                    command1.Parameters.AddWithValue("@pgmaxmark", "");
                    command1.Parameters.AddWithValue("@pgdiv", "");
                    command1.Parameters.AddWithValue("@pgper", "");
                    command1.Parameters.AddWithValue("@pggroup", "");
                    command1.Parameters.AddWithValue("@pgschool", "");
                    command1.Parameters.AddWithValue("@pgboard", "");

                    command1.Parameters.AddWithValue("@punish", "");

                    command1.Parameters.AddWithValue("@att1", "");
                    command1.Parameters.AddWithValue("@att2", "");
                    command1.Parameters.AddWithValue("@att3", "");
                    command1.Parameters.AddWithValue("@att4", "");
                    command1.Parameters.AddWithValue("@att5", "");
                    command1.Parameters.AddWithValue("@att6", "");
                    command1.Parameters.AddWithValue("@att7", "");
                    command1.Parameters.AddWithValue("@att8", "");
                    command1.Parameters.AddWithValue("@att9", "");
                    command1.Parameters.AddWithValue("@att10", "");
                    command1.Parameters.AddWithValue("@att11", "");
                    command1.Parameters.AddWithValue("@att12", "");
                    command1.Parameters.AddWithValue("@att13", "");
                    command1.Parameters.AddWithValue("@att14", "");
                    command1.Parameters.AddWithValue("@att15", "");
                    command1.Parameters.AddWithValue("@att16", "");
                    command1.Parameters.AddWithValue("@att17", "");

                    DateTime dt = DateTime.Now;
                    dt = dt.Date;
                    command1.Parameters.AddWithValue("@remark", "");
                    command1.Parameters.AddWithValue("@regdate", dt);
                    command1.Parameters.AddWithValue("@registrationid", stid);
                    command1.Parameters.AddWithValue("@rstatus", "0");

                    command1.ExecuteNonQuery();
                    //connection1.Close();




                    string uname = stid;
                    string utype = "student";


                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                    claims.Add(new Claim(ClaimTypes.Name, uname));
                    if (utype == "student")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "student"));


                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);



                    string loginquery = "insert into loginmaster(username, userid,password,mobno,address,usertype,remark)" +
                   "values(@username,@userid,@password,@mobno,@address,@usertype,@remark)";
                    SqlCommand command2 = new SqlCommand(loginquery, connection1);
                    command2.Parameters.AddWithValue("@username", "");
                    command2.Parameters.AddWithValue("@userid", stid);
                    command2.Parameters.AddWithValue("@password", stid);
                    command2.Parameters.AddWithValue("@mobno", "");
                    command2.Parameters.AddWithValue("@address", "");
                    command2.Parameters.AddWithValue("@usertype", "student");
                    command2.Parameters.AddWithValue("@remark", "good");
                    command2.ExecuteNonQuery();
                    connection1.Close();

                    Console.WriteLine("PG" + stid);
                }

            }
            else
            {

                Console.WriteLine(Cacadyear);
               
                if(lname == "UG")
                {
                    if(Cacadyear=="1st year")
                    {
                        stid = "2024" + "01" + "01" + "0001";
                           
                    }

                   else if (Cacadyear == "2nd year")
                    {
                        stid = "2024" + "01" + "02" + "0001";
                    }
                  else 
                    {
                        stid = "2024" + "01" + "03" + "0001";
                    }

                    SqlConnection connection1 = new SqlConnection(conn);
                    connection1.Open();

string query1 = "insert into regmaster(rlevel, course, acadyear,uniregno,admcategory,merit,name,fatname,gauname,mothname,dob," +
                        "nationality,gender,categ,scateg,address,town,tehsil,post,thana,district,state,pin,partinsport,spouse,ncc,scout," +
                        "hostel,emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark,tendiv,tenper,tengroup,tenschool," +
                        "tenboard,twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                        "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                        "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard,punish," +
                        "att1,att2,att3,att4,att5,att6,att7,att8,att9,att10,att11,att12,att13,att14," +
                        "att15,att16,att17,remark,regdate,registrationid,rstatus)" +
                        "values(@rlevel, @course, @acadyear,@uniregno,@admcategory,@merit,@name,@fatname,@gauname,@mothname,@dob," +
                        "@nationality,@gender,@categ,@scateg,@address,@town,@tehsil,@post,@thana,@district,@state,@pin,@partinsport,@spouse,@ncc,@scout," +
                        "@hostel,@emailid,@whatsapp,@tenyear,@tenmarksobt,@tenmaxmark,@tendiv,@tenper,@tengroup,@tenschool," +
                       "@tenboard,@twyear,@twmarksobt,@twmaxmark,@twdiv,@twper,@twgroup,@twschool,@twboard," +
                        "@ugyear,@ugmarksobt,@ugmaxmark,@ugdiv,@ugper,@uggroup,@ugschool,@ugboard," +
                        "@pgyear,@pgmarksobt,@pgmaxmark,@pgdiv,@pgper,@pggroup,@pgschool,@pgboard,@punish," +
                        "@att1,@att2,@att3,@att4,@att5,@att6,@att7,@att8,@att9,@att10,@att11,@att12,@att13,@att14," +
                        "@att15,@att16,@att17,@remark,@regdate,@registrationid,@rstatus)";

                    SqlCommand command1 = new SqlCommand(query1,connection1);
                    command1.Parameters.AddWithValue("@rlevel",lname);
                    command1.Parameters.AddWithValue("@course", Cname);

                    command1.Parameters.AddWithValue("@acadyear", Cacadyear);

                    command1.Parameters.AddWithValue("@uniregno", unenroll);

                    command1.Parameters.AddWithValue("@admcategory", admcategory);

                    command1.Parameters.AddWithValue("@merit", unmerit);
                    command1.Parameters.AddWithValue("@name", "");
                    command1.Parameters.AddWithValue("@fatname", "");
                    command1.Parameters.AddWithValue("@gauname", "");
                    command1.Parameters.AddWithValue("@mothname", "");

                    command1.Parameters.AddWithValue("@dob", "");
                    command1.Parameters.AddWithValue("@nationality", "");

                    command1.Parameters.AddWithValue("@gender", "");

                    command1.Parameters.AddWithValue("@categ", "");

                    command1.Parameters.AddWithValue("@scateg", "");

                    command1.Parameters.AddWithValue("@address", "");
                    command1.Parameters.AddWithValue("@town", "");
                    command1.Parameters.AddWithValue("@tehsil", "");
                    command1.Parameters.AddWithValue("@post", "");
                    command1.Parameters.AddWithValue("@thana", "");
                    command1.Parameters.AddWithValue("@district", "");
                    command1.Parameters.AddWithValue("@state", "");

                    command1.Parameters.AddWithValue("@pin", "");

                    command1.Parameters.AddWithValue("@partinsport", "");

                    command1.Parameters.AddWithValue("@spouse", "");

                    command1.Parameters.AddWithValue("@ncc", "");
                    command1.Parameters.AddWithValue("@scout", "");
                    command1.Parameters.AddWithValue("@hostel", "");
                    command1.Parameters.AddWithValue("@emailid", "");
                    command1.Parameters.AddWithValue("@whatsapp", "");



                    command1.Parameters.AddWithValue("@tenyear", "");
                    command1.Parameters.AddWithValue("@tenmarksobt", "");
                    command1.Parameters.AddWithValue("@tenmaxmark", "");
                    command1.Parameters.AddWithValue("@tendiv", "");
                    command1.Parameters.AddWithValue("@tenper", "");
                    command1.Parameters.AddWithValue("@tengroup", "");
                    command1.Parameters.AddWithValue("@tenschool", "");
                    command1.Parameters.AddWithValue("@tenboard", "");



                    command1.Parameters.AddWithValue("@twyear", "");
                    command1.Parameters.AddWithValue("@twmarksobt", "");
                    command1.Parameters.AddWithValue("@twmaxmark", "");
                    command1.Parameters.AddWithValue("@twdiv", "");
                    command1.Parameters.AddWithValue("@twper", "");
                    command1.Parameters.AddWithValue("@twgroup", "");
                    command1.Parameters.AddWithValue("@twschool", "");
                    command1.Parameters.AddWithValue("@twboard", "");

                    command1.Parameters.AddWithValue("@ugyear", "");
                    command1.Parameters.AddWithValue("@ugmarksobt", "");
                    command1.Parameters.AddWithValue("@ugmaxmark", "");
                    command1.Parameters.AddWithValue("@ugdiv", "");
                    command1.Parameters.AddWithValue("@ugper", "");
                    command1.Parameters.AddWithValue("@uggroup", "");
                    command1.Parameters.AddWithValue("@ugschool", "");
                    command1.Parameters.AddWithValue("@ugboard", "");






                    command1.Parameters.AddWithValue("@pgyear", "");
                    command1.Parameters.AddWithValue("@pgmarksobt", "");
                    command1.Parameters.AddWithValue("@pgmaxmark", "");
                    command1.Parameters.AddWithValue("@pgdiv", "");
                    command1.Parameters.AddWithValue("@pgper", "");
                    command1.Parameters.AddWithValue("@pggroup", "");
                    command1.Parameters.AddWithValue("@pgschool", "");
                    command1.Parameters.AddWithValue("@pgboard", "");

                    command1.Parameters.AddWithValue("@punish","");

                    command1.Parameters.AddWithValue("@att1", "");
                    command1.Parameters.AddWithValue("@att2", "");
                    command1.Parameters.AddWithValue("@att3", "");
                    command1.Parameters.AddWithValue("@att4", "");
                    command1.Parameters.AddWithValue("@att5", "");
                    command1.Parameters.AddWithValue("@att6", "");
                    command1.Parameters.AddWithValue("@att7", "");
                    command1.Parameters.AddWithValue("@att8", "");
                    command1.Parameters.AddWithValue("@att9", "");
                    command1.Parameters.AddWithValue("@att10", "");
                    command1.Parameters.AddWithValue("@att11", "");
                    command1.Parameters.AddWithValue("@att12", "");
                    command1.Parameters.AddWithValue("@att13", "");
                    command1.Parameters.AddWithValue("@att14", "");
                    command1.Parameters.AddWithValue("@att15", "");
                    command1.Parameters.AddWithValue("@att16", "");
                    command1.Parameters.AddWithValue("@att17", "");

                    DateTime dt = DateTime.Now;
                     dt = dt.Date;
                    command1.Parameters.AddWithValue("@remark","");
                    command1.Parameters.AddWithValue("@regdate",dt);
                    command1.Parameters.AddWithValue("@registrationid",stid);
                    command1.Parameters.AddWithValue("@rstatus", "0");

                    command1.ExecuteNonQuery();
                    //connection1.Close();



                    string uname = stid;
                    string utype = "student";


                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                    claims.Add(new Claim(ClaimTypes.Name, uname));
                    if (utype == "student")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "student"));


                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);


                    string loginquery = "insert into loginmaster(username, userid,password,mobno,address,usertype,remark)" +
                   "values(@username,@userid,@password,@mobno,@address,@usertype,@remark)";
                    SqlCommand command2 = new SqlCommand(loginquery, connection1);
                    command2.Parameters.AddWithValue("@username", "");
                    command2.Parameters.AddWithValue("@userid", stid);
                    command2.Parameters.AddWithValue("@password", stid);
                    command2.Parameters.AddWithValue("@mobno", "");
                    command2.Parameters.AddWithValue("@address", "");
                    command2.Parameters.AddWithValue("@usertype", "student");
                    command2.Parameters.AddWithValue("@remark", "good");
                    command2.ExecuteNonQuery();
                    connection1.Close();

                    Console.WriteLine("UG"+stid);

                }


               else if(lname == "PG") 
                {
                    if (Cacadyear == "1st year")
                    {
                        stid = "2024" + "02" + "01" + "0001";
                    }

                   else
                    {
                        stid = "2024" + "02" + "02" + "0001";
                    }

                    SqlConnection connection1 = new SqlConnection(conn);
                    connection1.Open();

                    string query1 = "insert into regmaster(rlevel, course, acadyear,uniregno,admcategory,merit,name,fatname,gauname,mothname,dob," +
                                            "nationality,gender,categ,scateg,address,town,tehsil,post,thana,district,state,pin,partinsport,spouse,ncc,scout," +
                                            "hostel,emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark,tendiv,tenper,tengroup,tenschool," +
                                            "tenboard,twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                                            "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                                            "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard,punish," +
                                            "att1,att2,att3,att4,att5,att6,att7,att8,att9,att10,att11,att12,att13,att14," +
                                            "att15,att16,att17,remark,regdate,registrationid,rstatus)" +
                                            "values(@rlevel, @course, @acadyear,@uniregno,@admcategory,@merit,@name,@fatname,@gauname,@mothname,@dob," +
                                            "@nationality,@gender,@categ,@scateg,@address,@town,@tehsil,@post,@thana,@district,@state,@pin,@partinsport,@spouse,@ncc,@scout," +
                                            "@hostel,@emailid,@whatsapp,@tenyear,@tenmarksobt,@tenmaxmark,@tendiv,@tenper,@tengroup,@tenschool," +
                                           "@tenboard,@twyear,@twmarksobt,@twmaxmark,@twdiv,@twper,@twgroup,@twschool,@twboard," +
                                            "@ugyear,@ugmarksobt,@ugmaxmark,@ugdiv,@ugper,@uggroup,@ugschool,@ugboard," +
                                            "@pgyear,@pgmarksobt,@pgmaxmark,@pgdiv,@pgper,@pggroup,@pgschool,@pgboard,@punish," +
                                            "@att1,@att2,@att3,@att4,@att5,@att6,@att7,@att8,@att9,@att10,@att11,@att12,@att13,@att14," +
                                            "@att15,@att16,@att17,@remark,@regdate,@registrationid,@rstatus)";

                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    command1.Parameters.AddWithValue("@rlevel", lname);
                    command1.Parameters.AddWithValue("@course", Cname);

                    command1.Parameters.AddWithValue("@acadyear", Cacadyear);

                    command1.Parameters.AddWithValue("@uniregno", unenroll);

                    command1.Parameters.AddWithValue("@admcategory", admcategory);

                    command1.Parameters.AddWithValue("@merit", unmerit);
                    command1.Parameters.AddWithValue("@name", "");
                    command1.Parameters.AddWithValue("@fatname", "");
                    command1.Parameters.AddWithValue("@gauname", "");
                    command1.Parameters.AddWithValue("@mothname", "");

                    command1.Parameters.AddWithValue("@dob", "");
                    command1.Parameters.AddWithValue("@nationality", "");

                    command1.Parameters.AddWithValue("@gender", "");

                    command1.Parameters.AddWithValue("@categ", "");

                    command1.Parameters.AddWithValue("@scateg", "");

                    command1.Parameters.AddWithValue("@address", "");
                    command1.Parameters.AddWithValue("@town", "");
                    command1.Parameters.AddWithValue("@tehsil", "");
                    command1.Parameters.AddWithValue("@post", "");
                    command1.Parameters.AddWithValue("@thana", "");
                    command1.Parameters.AddWithValue("@district", "");
                    command1.Parameters.AddWithValue("@state", "");

                    command1.Parameters.AddWithValue("@pin", "");

                    command1.Parameters.AddWithValue("@partinsport", "");

                    command1.Parameters.AddWithValue("@spouse", "");

                    command1.Parameters.AddWithValue("@ncc", "");
                    command1.Parameters.AddWithValue("@scout", "");
                    command1.Parameters.AddWithValue("@hostel", "");
                    command1.Parameters.AddWithValue("@emailid", "");
                    command1.Parameters.AddWithValue("@whatsapp", "");



                    command1.Parameters.AddWithValue("@tenyear", "");
                    command1.Parameters.AddWithValue("@tenmarksobt", "");
                    command1.Parameters.AddWithValue("@tenmaxmark", "");
                    command1.Parameters.AddWithValue("@tendiv", "");
                    command1.Parameters.AddWithValue("@tenper", "");
                    command1.Parameters.AddWithValue("@tengroup", "");
                    command1.Parameters.AddWithValue("@tenschool", "");
                    command1.Parameters.AddWithValue("@tenboard", "");



                    command1.Parameters.AddWithValue("@twyear", "");
                    command1.Parameters.AddWithValue("@twmarksobt", "");
                    command1.Parameters.AddWithValue("@twmaxmark", "");
                    command1.Parameters.AddWithValue("@twdiv", "");
                    command1.Parameters.AddWithValue("@twper", "");
                    command1.Parameters.AddWithValue("@twgroup", "");
                    command1.Parameters.AddWithValue("@twschool", "");
                    command1.Parameters.AddWithValue("@twboard", "");

                    command1.Parameters.AddWithValue("@ugyear", "");
                    command1.Parameters.AddWithValue("@ugmarksobt", "");
                    command1.Parameters.AddWithValue("@ugmaxmark", "");
                    command1.Parameters.AddWithValue("@ugdiv", "");
                    command1.Parameters.AddWithValue("@ugper", "");
                    command1.Parameters.AddWithValue("@uggroup", "");
                    command1.Parameters.AddWithValue("@ugschool", "");
                    command1.Parameters.AddWithValue("@ugboard", "");






                    command1.Parameters.AddWithValue("@pgyear", "");
                    command1.Parameters.AddWithValue("@pgmarksobt", "");
                    command1.Parameters.AddWithValue("@pgmaxmark", "");
                    command1.Parameters.AddWithValue("@pgdiv", "");
                    command1.Parameters.AddWithValue("@pgper", "");
                    command1.Parameters.AddWithValue("@pggroup", "");
                    command1.Parameters.AddWithValue("@pgschool", "");
                    command1.Parameters.AddWithValue("@pgboard", "");

                    command1.Parameters.AddWithValue("@punish", "");

                    command1.Parameters.AddWithValue("@att1", "");
                    command1.Parameters.AddWithValue("@att2", "");
                    command1.Parameters.AddWithValue("@att3", "");
                    command1.Parameters.AddWithValue("@att4", "");
                    command1.Parameters.AddWithValue("@att5", "");
                    command1.Parameters.AddWithValue("@att6", "");
                    command1.Parameters.AddWithValue("@att7", "");
                    command1.Parameters.AddWithValue("@att8", "");
                    command1.Parameters.AddWithValue("@att9", "");
                    command1.Parameters.AddWithValue("@att10", "");
                    command1.Parameters.AddWithValue("@att11", "");
                    command1.Parameters.AddWithValue("@att12", "");
                    command1.Parameters.AddWithValue("@att13", "");
                    command1.Parameters.AddWithValue("@att14", "");
                    command1.Parameters.AddWithValue("@att15", "");
                    command1.Parameters.AddWithValue("@att16", "");
                    command1.Parameters.AddWithValue("@att17", "");

                    DateTime dt = DateTime.Now;
                    dt = dt.Date;
                    command1.Parameters.AddWithValue("@remark", "");
                    command1.Parameters.AddWithValue("@regdate", dt);
                    command1.Parameters.AddWithValue("@registrationid", stid);
                    command1.Parameters.AddWithValue("@rstatus", "0");

                    command1.ExecuteNonQuery();
                   // connection1.Close();




                    string uname = stid;
                    string utype = "student";


                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                    claims.Add(new Claim(ClaimTypes.Name, uname));
                    if (utype == "student")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "student"));


                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);


                    string loginquery = "insert into loginmaster(username, userid,password,mobno,address,usertype,remark)" +
                   "values(@username,@userid,@password,@mobno,@address,@usertype,@remark)";
                    SqlCommand command2 = new SqlCommand(loginquery, connection1);
                    command2.Parameters.AddWithValue("@username", "");
                    command2.Parameters.AddWithValue("@userid", stid);
                    command2.Parameters.AddWithValue("@password", stid);
                    command2.Parameters.AddWithValue("@mobno", "");
                    command2.Parameters.AddWithValue("@address", "");
                    command2.Parameters.AddWithValue("@usertype", "student");
                    command2.Parameters.AddWithValue("@remark", "good");
                    command2.ExecuteNonQuery();
                    connection1.Close();


                    Console.WriteLine("PG"+stid);
                }

                else
                {
                    if (Cacadyear == "1st year")
                    {
                        stid = "2024" + "03" + "01" + "0001";
                    }


                    SqlConnection connection1 = new SqlConnection(conn);
                    connection1.Open();

                    string query1 = "insert into regmaster(rlevel, course, acadyear,uniregno,admcategory,merit,name,fatname,gauname,mothname,dob," +
                                            "nationality,gender,categ,scateg,address,town,tehsil,post,thana,district,state,pin,partinsport,spouse,ncc,scout," +
                                            "hostel,emailid,whatsapp,tenyear,tenmarksobt,tenmaxmark,tendiv,tenper,tengroup,tenschool," +
                                            "tenboard,twyear,twmarksobt,twmaxmark,twdiv,twper,twgroup,twschool,twboard," +
                                            "ugyear,ugmarksobt,ugmaxmark,ugdiv,ugper,uggroup,ugschool,ugboard," +
                                            "pgyear,pgmarksobt,pgmaxmark,pgdiv,pgper,pggroup,pgschool,pgboard,punish," +
                                            "att1,att2,att3,att4,att5,att6,att7,att8,att9,att10,att11,att12,att13,att14," +
                                            "att15,att16,att17,remark,regdate,registrationid,rstatus)" +
                                            "values(@rlevel, @course, @acadyear,@uniregno,@admcategory,@merit,@name,@fatname,@gauname,@mothname,@dob," +
                                            "@nationality,@gender,@categ,@scateg,@address,@town,@tehsil,@post,@thana,@district,@state,@pin,@partinsport,@spouse,@ncc,@scout," +
                                            "@hostel,@emailid,@whatsapp,@tenyear,@tenmarksobt,@tenmaxmark,@tendiv,@tenper,@tengroup,@tenschool," +
                                           "@tenboard,@twyear,@twmarksobt,@twmaxmark,@twdiv,@twper,@twgroup,@twschool,@twboard," +
                                            "@ugyear,@ugmarksobt,@ugmaxmark,@ugdiv,@ugper,@uggroup,@ugschool,@ugboard," +
                                            "@pgyear,@pgmarksobt,@pgmaxmark,@pgdiv,@pgper,@pggroup,@pgschool,@pgboard,@punish," +
                                            "@att1,@att2,@att3,@att4,@att5,@att6,@att7,@att8,@att9,@att10,@att11,@att12,@att13,@att14," +
                                            "@att15,@att16,@att17,@remark,@regdate,@registrationid,@rstatus)";

                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    command1.Parameters.AddWithValue("@rlevel", lname);
                    command1.Parameters.AddWithValue("@course", Cname);

                    command1.Parameters.AddWithValue("@acadyear", Cacadyear);

                    command1.Parameters.AddWithValue("@uniregno", unenroll);

                    command1.Parameters.AddWithValue("@admcategory", admcategory);

                    command1.Parameters.AddWithValue("@merit", unmerit);
                    command1.Parameters.AddWithValue("@name", "");
                    command1.Parameters.AddWithValue("@fatname", "");
                    command1.Parameters.AddWithValue("@gauname", "");
                    command1.Parameters.AddWithValue("@mothname", "");

                    command1.Parameters.AddWithValue("@dob", "");
                    command1.Parameters.AddWithValue("@nationality", "");

                    command1.Parameters.AddWithValue("@gender", "");

                    command1.Parameters.AddWithValue("@categ", "");

                    command1.Parameters.AddWithValue("@scateg", "");

                    command1.Parameters.AddWithValue("@address", "");
                    command1.Parameters.AddWithValue("@town", "");
                    command1.Parameters.AddWithValue("@tehsil", "");
                    command1.Parameters.AddWithValue("@post", "");
                    command1.Parameters.AddWithValue("@thana", "");
                    command1.Parameters.AddWithValue("@district", "");
                    command1.Parameters.AddWithValue("@state", "");

                    command1.Parameters.AddWithValue("@pin", "");

                    command1.Parameters.AddWithValue("@partinsport", "");

                    command1.Parameters.AddWithValue("@spouse", "");

                    command1.Parameters.AddWithValue("@ncc", "");
                    command1.Parameters.AddWithValue("@scout", "");
                    command1.Parameters.AddWithValue("@hostel", "");
                    command1.Parameters.AddWithValue("@emailid", "");
                    command1.Parameters.AddWithValue("@whatsapp", "");



                    command1.Parameters.AddWithValue("@tenyear", "");
                    command1.Parameters.AddWithValue("@tenmarksobt", "");
                    command1.Parameters.AddWithValue("@tenmaxmark", "");
                    command1.Parameters.AddWithValue("@tendiv", "");
                    command1.Parameters.AddWithValue("@tenper", "");
                    command1.Parameters.AddWithValue("@tengroup", "");
                    command1.Parameters.AddWithValue("@tenschool", "");
                    command1.Parameters.AddWithValue("@tenboard", "");



                    command1.Parameters.AddWithValue("@twyear", "");
                    command1.Parameters.AddWithValue("@twmarksobt", "");
                    command1.Parameters.AddWithValue("@twmaxmark", "");
                    command1.Parameters.AddWithValue("@twdiv", "");
                    command1.Parameters.AddWithValue("@twper", "");
                    command1.Parameters.AddWithValue("@twgroup", "");
                    command1.Parameters.AddWithValue("@twschool", "");
                    command1.Parameters.AddWithValue("@twboard", "");

                    command1.Parameters.AddWithValue("@ugyear", "");
                    command1.Parameters.AddWithValue("@ugmarksobt", "");
                    command1.Parameters.AddWithValue("@ugmaxmark", "");
                    command1.Parameters.AddWithValue("@ugdiv", "");
                    command1.Parameters.AddWithValue("@ugper", "");
                    command1.Parameters.AddWithValue("@uggroup", "");
                    command1.Parameters.AddWithValue("@ugschool", "");
                    command1.Parameters.AddWithValue("@ugboard", "");






                    command1.Parameters.AddWithValue("@pgyear", "");
                    command1.Parameters.AddWithValue("@pgmarksobt", "");
                    command1.Parameters.AddWithValue("@pgmaxmark", "");
                    command1.Parameters.AddWithValue("@pgdiv", "");
                    command1.Parameters.AddWithValue("@pgper", "");
                    command1.Parameters.AddWithValue("@pggroup", "");
                    command1.Parameters.AddWithValue("@pgschool", "");
                    command1.Parameters.AddWithValue("@pgboard", "");

                    command1.Parameters.AddWithValue("@punish", "");

                    command1.Parameters.AddWithValue("@att1", "");
                    command1.Parameters.AddWithValue("@att2", "");
                    command1.Parameters.AddWithValue("@att3", "");
                    command1.Parameters.AddWithValue("@att4", "");
                    command1.Parameters.AddWithValue("@att5", "");
                    command1.Parameters.AddWithValue("@att6", "");
                    command1.Parameters.AddWithValue("@att7", "");
                    command1.Parameters.AddWithValue("@att8", "");
                    command1.Parameters.AddWithValue("@att9", "");
                    command1.Parameters.AddWithValue("@att10", "");
                    command1.Parameters.AddWithValue("@att11", "");
                    command1.Parameters.AddWithValue("@att12", "");
                    command1.Parameters.AddWithValue("@att13", "");
                    command1.Parameters.AddWithValue("@att14", "");
                    command1.Parameters.AddWithValue("@att15", "");
                    command1.Parameters.AddWithValue("@att16", "");
                    command1.Parameters.AddWithValue("@att17", "");

                    DateTime dt = DateTime.Now;
                    dt = dt.Date;
                    command1.Parameters.AddWithValue("@remark", "");
                    command1.Parameters.AddWithValue("@regdate", dt);
                    command1.Parameters.AddWithValue("@registrationid", stid);
                    command1.Parameters.AddWithValue("@rstatus", "0");

                    command1.ExecuteNonQuery();
                    //connection1.Close();




                    string uname = stid;
                    string utype = "student";


                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uname));
                    claims.Add(new Claim(ClaimTypes.Name, uname));
                    if (utype == "student")
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "student"));


                    }

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                    HttpContext.SignInAsync(claimsPrincipal);

                    HttpContext.Session.SetString("username", uname);


                    string loginquery = "insert into loginmaster(username, userid,password,mobno,address,usertype,remark)" +
                   "values(@username,@userid,@password,@mobno,@address,@usertype,@remark)";
                    SqlCommand command2 = new SqlCommand(loginquery, connection1);
                    command2.Parameters.AddWithValue("@username", "");
                    command2.Parameters.AddWithValue("@userid", stid);
                    command2.Parameters.AddWithValue("@password", stid);
                    command2.Parameters.AddWithValue("@mobno", "");
                    command2.Parameters.AddWithValue("@address", "");
                    command2.Parameters.AddWithValue("@usertype", "student");
                    command2.Parameters.AddWithValue("@remark", "good");
                    command2.ExecuteNonQuery();
                    connection1.Close();



                    Console.WriteLine("PG" + stid);
                }








            }





            return RedirectToAction("PersonalDetails", "Admission",new{ success="saved successfully"});
        }

        public IActionResult RegisterLogin()
        {
            string success = Request.Query["success"];
            string error = Request.Query["error"];

            ViewBag.success = success;  
            ViewBag.error = error;  

            return View();  
        }

        [HttpPost]
        public IActionResult NewRegistration(string cname, string cemail,string cmobile,string cpass)
        {
            if(string.IsNullOrEmpty(cname))
            {
                cname = "";
            }

            if (string.IsNullOrEmpty(cemail))
            {
                cemail = "";
            }
            if (string.IsNullOrEmpty(cmobile))
            {
                cmobile = "";
            }
            if (string.IsNullOrEmpty(cpass))
            {
                cpass = "";
            }

            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string vquery = "select count(*) from RegisterLoginMaster where Cemail = @Cemail";
            SqlCommand cmd = new SqlCommand(vquery, connection);
            cmd.Parameters.AddWithValue("@Cemail", cemail);
            int count = (Int32)cmd.ExecuteScalar();


            if (count > 0)
            {
                connection.Close();
                return RedirectToAction("RegisterLogin", "Admission", new { error = "Already Registered" });
            }
            else
            {
                string query = "insert into RegisterLoginMaster (Cname,Cemail,Cmobile,Cpassword,Clevel,Ccourse,Cacyear,unenroll,admcategory,unmerit)values(@Cname,@Cemail,@Cmobile,@Cpassword,@Clevel,@Ccourse,@Cacyear,@unenroll,@admcategory,@unmerit)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cname  ", cname);
                command.Parameters.AddWithValue("@Cemail", cemail);
                command.Parameters.AddWithValue("@Cmobile", cmobile);
                command.Parameters.AddWithValue("@Cpassword", cpass);
                command.Parameters.AddWithValue("@Clevel", "");
                command.Parameters.AddWithValue("@Ccourse", "");
                command.Parameters.AddWithValue("@Cacyear", "");
                command.Parameters.AddWithValue("@unenroll", "");
                command.Parameters.AddWithValue("@admcategory", "");
                command.Parameters.AddWithValue("unmerit", "");
                command.ExecuteNonQuery();
                

                string query1 = "insert into loginmaster(UserName,UserId,Password,MobNo,Address,UserType,Remark)values(@UserName,@UserId,@Password,@MobNo,@Address,@UserType,@Remark)";
                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.Parameters.AddWithValue("@UserName", cemail);
                command1.Parameters.AddWithValue("@UserId", cemail);
                command1.Parameters.AddWithValue("@Password", cpass);
                command1.Parameters.AddWithValue("@MobNo", cmobile);
                command1.Parameters.AddWithValue("@Address", "");
                command1.Parameters.AddWithValue("@UserType", "student");
                command1.Parameters.AddWithValue("@Remark", "");
                command1.ExecuteNonQuery();

                connection.Close();

                return RedirectToAction("RegisterLogin", "Admission", new { success = "Registered Successfully" });

            }

           


        }

        public IActionResult LoginPortal()
        {

            return View();

        }

        [HttpPost]
        public IActionResult   LoginFromLoginPortal(string email,string pass)
        {
            if (string.IsNullOrEmpty(email)) {

                email = "";
            }
            if (string.IsNullOrEmpty(pass))
            {

                pass = "";
            }

            var account = _accountService.Login(email, pass);

            if (account != null)
            {
                string uname = account.Username;
                string utype = account.Usertype;
                string folder = "";

                string url = "";

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
                claims.Add(new Claim(ClaimTypes.Name, email));
                if (utype == "student")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "student"));
                    folder = "Admission";
                    url = "SelectCourses";

                }
               
                else
                {
                    folder = "Admission";
                    url = "LoginPortal";
                }



                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", uname);




                return RedirectToAction(url, folder);



            }
            else
            {
                Console.WriteLine("invalid login attempt");
                ViewBag.Message = "Invalid login";
                return RedirectToAction("LoginPortal","Admission");
            }





        }


        public IActionResult Logout()
        {

            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("permit");
            HttpContext.SignOutAsync();

            return RedirectToAction("SelectCourses", "Admission");
        }




    }
}
