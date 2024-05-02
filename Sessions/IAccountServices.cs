using Libms.Models;

namespace Libms.Sessions
{
    public interface IAccountServices
    {

        public Account Login(string username, string password);
    }
}
