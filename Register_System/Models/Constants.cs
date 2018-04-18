using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Register_System.Models
{
    public class Constants
    {
        public const string CONNECTION_STRING = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Vusi.Mngomezulu\\Documents\\Visual Studio 2015\\Projects\\RegisterSystem\\RegisterSystem\\App_Data\\UserDatabase.mdf';Integrated Security=True";

        public static int RandomCode()
        {
            int result = 0;

            Random num = new Random();

            result = num.Next(1000, 9999);

            return result;
        }


    }
}