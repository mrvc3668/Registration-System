using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register_System.Models.Interface_Logic_
{
    public interface IUserLogic
    {
        List<User> getAll();
        bool UserExists(string username);
        int Login(string username, string password);
        void GetUserDetails(User username);

        bool Register(string username, string password, string division, string position, int usertype);
    }
}
