using Libms.Models;
using Libms.Sessions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Libms.Controllers
{


    public class Admission : Controller
    {

        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";

        private IAccountServices _accountService;


        public Admission(IAccountServices accountService)
        {
            //_logger = logger;
            // _environment = environment;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SelectCourses()
        {
            return View();
        }


        public IActionResult ProceedSelection()
        {
            return View();
        }


        public IActionResult UpdateProceedSelection()
        {
            return RedirectToAction("ProceedSelectionCopy", "Admission");
        }







        public IActionResult ProceedSelectionCopy()
        {
            return View();
        }




        public IActionResult UpdateProceedSelection1()
        {
            return RedirectToAction("ProceedSelectionCopy1", "Admission");
        }






        public IActionResult ProceedSelectionCopy1()
        {
            return View();
        }



        public IActionResult UpdateProceedSelection2()
        {
            return RedirectToAction("ProceedSelectionCopy2", "Admission");
        }




        public IActionResult ProceedSelectionCopy2()
        {
            return View();
        }


        public IActionResult UpdateProceedSelection3()
        {
            return RedirectToAction("ProceedSelectionCopy3", "Admission");
        }



        public IActionResult ProceedSelectionCopy3()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SelectCourses(string levelnm,string coursenm)
        {

            Console.WriteLine(levelnm);
            SqlConnection connection = new SqlConnection(conn);

            connection.Open();

            if (string.IsNullOrEmpty(coursenm))
            {
                string query = "Select Cname from CourseMaster where clavel=@clavel";
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
            string Cacadyear,string candidate,string fathername,string gaurdian,
            string mothername,DateTime dob,string nation,string gender,string Castecategory,
            string Subcategory)
        {
            string username = HttpContext.Session.GetString("username");

            Console.WriteLine(lname);
            Console.WriteLine(Cname);
            Console.WriteLine(Cacadyear);
            Console.WriteLine(candidate);
            Console.WriteLine(fathername);
            Console.WriteLine(gaurdian);
            Console.WriteLine(mothername);
            Console.WriteLine(dob);
            Console.WriteLine(nation);
            Console.WriteLine(gender);
            Console.WriteLine(Castecategory);
            Console.WriteLine(Subcategory);

            //SqlConnection connection = new SqlConnection(conn);
            //connection.Open();
            //string query = "Update registerloginmaster" +
            //    " set clevel=@clevel,ccourse=@ccourse,cacyear=@cacyear," +
            //    "candidate=@candidate,fname=@fname,cgaurdian=@cgaurdian," +
            //    "mname=@mname,cdob=@cdob,cnationality=@cnationality," +
            //    "cgender=@cgender,ccategory=@ccategory," +
            //    "csubcategory=@csubcategory where cemail=@cemail";
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@clevel", lname);
            //cmd.Parameters.AddWithValue("@ccourse", Cname);
            //cmd.Parameters.AddWithValue("@cacyear", Cacadyear);
            //cmd.Parameters.AddWithValue("@candidate", candidate);
            //cmd.Parameters.AddWithValue("@fname", fathername);
            //cmd.Parameters.AddWithValue("@cgaurdian", gaurdian);
            //cmd.Parameters.AddWithValue("@mname", mothername);
            //cmd.Parameters.AddWithValue("@cdob", dob);
            //cmd.Parameters.AddWithValue("@cnationality", nation);
            //cmd.Parameters.AddWithValue("@cgender", gender);
            //cmd.Parameters.AddWithValue("@ccategory", Castecategory);
            //cmd.Parameters.AddWithValue("@csubcategory", Subcategory);
            //cmd.Parameters.AddWithValue("@cemail", username);

            //cmd.ExecuteNonQuery();
            //connection.Close();

            return RedirectToAction("ProceedSelection", "Admission",new{ success="saved successfully"});
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
            if (string.IsNullOrEmpty(cname))
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

            //SqlConnection connection = new SqlConnection(conn);
            //connection.Open();
            //string vquery = "select count(*) from RegisterLoginMaster where Cemail = @Cemail";
            //SqlCommand cmd = new SqlCommand(vquery,connection);
            //cmd.Parameters.AddWithValue("@Cemail",cemail);
            //int count = (Int32)cmd.ExecuteScalar();


            //if(count > 0)
            //{
            //    connection.Close();
            //    return RedirectToAction("RegisterLogin", "Admission", new { error = "Already Registered" });  
            //}
            //else
            //{
            //    string query = "insert into RegisterLoginMaster (Cname,Cemail,Cmobile,Cpassword)values(@Cname,@Cemail,@Cmobile,@Cpassword)";
            //    SqlCommand command = new SqlCommand(query,connection);
            //    command.Parameters.AddWithValue("@Cname",cname);
            //    command.Parameters.AddWithValue("@Cemail", cemail);
            //    command.Parameters.AddWithValue("@Cmobile", cmobile);
            //    command.Parameters.AddWithValue("@Cpassword", cpass);
            //    command.ExecuteNonQuery();


            //    string query1 = "insert into loginmaster(UserName,UserId,Password,MobNo,Address,UserType,Remark)values(@UserName,@UserId,@Password,@MobNo,@Address,@UserType,@Remark)";
            //    SqlCommand command1 = new SqlCommand(query1,connection);
            //    command1.Parameters.AddWithValue("@UserName",cemail);
            //    command1.Parameters.AddWithValue("@UserId", cemail);
            //    command1.Parameters.AddWithValue("@Password", cpass);
            //    command1.Parameters.AddWithValue("@MobNo", cmobile);
            //    command1.Parameters.AddWithValue("@Address", "");
            //    command1.Parameters.AddWithValue("@UserType", "student");
            //    command1.Parameters.AddWithValue("@Remark", "");
            //    command1.ExecuteNonQuery();

            //    connection.Close();

            //    return RedirectToAction("RegisterLogin", "Admission", new { success = "Registered Successfully" });

            //}

            return RedirectToAction("RegisterLogin", "Admission", new { success = "Registered Successfully" });


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






    }
}
