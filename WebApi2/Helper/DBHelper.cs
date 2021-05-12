using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Helper
{
    public class DBHelper
    {
        private static string IPAddress = @"DESKTOP-JOHNREM";
        private static string Catalog = @"practiceDB";
        private static string UserID = "sa";
        private static string Password = "sa";

        public static string ConnectionString()
        {
            return "Data Source=" + IPAddress + ";Initial Catalog =" + Catalog + "; Persist Security Info=True; User ID=" + UserID + "; Password=" + Password;
        }

    }
}