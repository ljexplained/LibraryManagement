using Libms.Sessions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;
using System.Net.Security;

 //my name is love

namespace Libms.Controllers
{
    public class Administration : Controller
    {
        //string conn = "Data Source=desktop-6lqd0uj\\sqlexpress;Integrated Security=True";
        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";

        private IAccountServices _accountService;


        public Administration(IAccountServices accountService)
        {
            //_logger = logger;
            // _environment = environment;
            _accountService = accountService;
        }

        public IActionResult Index()
        {

            return View();
        }



        [HttpPost]
        public IActionResult Index(string email, string pass)
        {



             
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
                if (utype == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    folder = "Home";
                    url = "Index";

                }
                else if (utype == "user")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "user"));
                    folder = "Home";
                    url = "Index";
                }

                else
                {
                    folder = "Administration";
                    url = "Index";
                }



                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);


                HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("username", uname);




                return RedirectToAction(url, folder);



            }
            else
            {
                Console.WriteLine("invalid login attemt");
                ViewBag.Message = "Invalid login";
                return View();
            }


            


        }


        [Authorize(Roles = "admin")]
        public IActionResult Changepassword()
        {
            string userid = HttpContext.Session.GetString("username");

            SqlConnection connection = new SqlConnection(conn);
            string query = "select * from loginmaster where userid = @userid";
            connection.Open();

            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@userid", userid);

             SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ViewBag.userid = reader.GetString(2);
                ViewBag.password = reader.GetString(3);


            }

            reader.Close();
            connection.Close();
            return View();

        }

        [HttpPost]
        public IActionResult UpdatePassword(string uname, string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                return RedirectToAction("ChangePassword", "Administration");
            }
            else
            {
                SqlConnection connection = new SqlConnection(conn);
                string query = "update  loginmaster set password = @password where userid = @userid";
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userid", uname);
                command.Parameters.AddWithValue("@password", password);

                command.ExecuteNonQuery();

                connection.Close();

                return RedirectToAction("ChangePassword", "Administration");

            }

           

        }


        public IActionResult Logout()
        {

            HttpContext.Session.Remove("username");
            HttpContext.SignOutAsync();

           return RedirectToAction("Index","Administration");
        }





    }
}
