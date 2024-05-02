using Libms.Models;
using System.Data.SqlClient;
namespace Libms.Sessions
{
    public class AccountServices : IAccountServices 
    {

         
        private List<Account> accounts;
        string conn = "Data Source=SQL5112.site4now.net;Initial Catalog=db_a9eacf_library;User Id=db_a9eacf_library_admin;Password=BrainLib@123#;";
        //public string conn = "Data Source=DESKTOP-6LQD0UJ\\SQLEXPRESS;Initial Catalog=MyUser;Integrated Security=True";
        public AccountServices()
        {
            accounts = new List<Account>();
            string query = "SELECT  * From LoginMaster";

            SqlConnection connection = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())

            {
                Account account = new Account();
                account.Username = reader.GetString(2);
                account.Password = reader.GetString(3);
                account.Usertype = reader.GetString(6);
                accounts.Add(account);
            }


            connection.Close();







        }
        public Account Login(string username, string password)
        {



            return accounts.SingleOrDefault(x => x.Username == username && x.Password == password);


        }


    }
}



