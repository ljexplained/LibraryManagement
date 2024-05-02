using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Libms.Controllers
{
    public class DeleteController : Controller
    {


        //string conn = "Data Source=desktop-6lqd0uj\\sqlexpress;Integrated Security=True";
        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult DeleteCollege()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from CollegeMaster where cid = @cid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);    
            cmd.Parameters.AddWithValue("@cid", delid);
            cmd.ExecuteNonQuery();  
            connection.Close();
            return RedirectToAction("CollegeMaster", "Home"); 
        }



        public IActionResult DeleteBook()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from BookMaster where bid = @bid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@bid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("BookMaster", "Home");
        }



        public IActionResult DeleteSession()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from SessionMaster where sid = @sid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@sid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("SessionMaster", "Home");
        }




        public IActionResult DeleteSection()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from SectionMaster where sid = @sid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@sid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("SectionMaster", "Home");
        }




        public IActionResult DeleteClass()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from ClassMaster where cid = @cid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@cid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("ClassMaster", "Home");
        }




        public IActionResult DeleteBookCategory()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from BookCategoryMaster where bcid = @bcid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@bcid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("BookCategoryMaster", "Home");
        }


        public IActionResult DeleteMember()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from MemberMaster where mid = @mid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("MemberMaster", "Home");
        }



        public IActionResult DeleteMemberType()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from MemberTypeMaster where mtid = @mtid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mtid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("MemberTypeMaster", "Home");
        }


        public IActionResult DeleteRule()
        {

            string delid = Request.Query["delid"];

            SqlConnection connection = new SqlConnection(conn);

            string query = "delete from RuleMaster where rid = @rid";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@rid", delid);
            cmd.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("RuleMaster", "Home");
        }

       

        [HttpPost]
        public async Task<IActionResult>  DeleteSelectedBooks(int[] bookids)
        {
            
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            try
            {

                foreach (int bookid in bookids)
                {

                    string query = "delete from bookmaster where bid = @bid";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@bid", bookid);
                    cmd.ExecuteNonQuery();


                }


            }
            catch (Exception ex) {

                Console.WriteLine(ex);

            }


            Console.WriteLine(bookids.Length);
           
            return RedirectToAction("BookMaster","Home");

        }


    }
}
