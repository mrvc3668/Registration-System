using Register_System.Models.Interface_Logic_;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Register_System.Models.Class_Logic_
{
    public class UserLogic : IUserLogic
    {
        public void GetUserDetails(User userinfo)
        {
            using (var contest = new Model1())
            {
                var result = contest.Users.Where(x=>x.UserName == userinfo.UserName);

                foreach(var d in result)
                {
                    userinfo.UserId = d.UserId;
                    userinfo.UserName = d.UserName;
                    userinfo.Position = d.Position;
                    userinfo.Division = d.Division;
                    userinfo.UserType = d.UserType;
                }
            }
        }

      

        public int Login(string username, string password)
        {
            int loggedin = 0;

            using (var context = new Model1())
            {
                loggedin = Convert.ToInt32(context.Users.Any(x=>x.UserName.Equals(username) && x.Password.Equals(password)));
            }

            return loggedin;
        }

        public bool Register(string username, string password, string division, string position, int usertype)
        {
            bool register = false;
        
            using (var context = new Model1())
            {
                var user = new User
                {
                    UserName = username,
                    Password = password,
                    ConfirmPassword = password,
                    Division = division,
                    Position = position,
                    UserType = usertype
                };

               context.Users.Add(user);
               register = Convert.ToBoolean(context.SaveChanges());
            }
              
            return register;
        }

        public bool UserExists(string username)
        {
            bool exists = false;

            using (var context = new Model1())
            {
                exists = context.Users.Any(x=>x.UserName == username);
            }

            return exists;
        }

        List<User> IUserLogic.getAll()
        {
            var list = new List<User>();
            //list.Add
            //  (
            //    new User
            //    {
            //        Userid = 19,
            //        Username = "Malaleveva",
            //        Password = "0000000000",
            //        ConfirmPassword = "0000000000",
            //        Division = "",
            //        Position = "",
            //        UserType = 0
            //    }
            //   );

            return list;
        }
    }

}
