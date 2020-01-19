using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSQuickShareService
{
    public static class UtilityOperations
    {
        public static string getConnectionString()
        {
            //string connectionString = "SERVER=199.79.63.90;" + "DATABASE=jenainfo_lazzycoder;" + "UID=jenainfo_lazycod;" + "PASSWORD=N+.vJAOSXTbW;";
            string connectionString = "Server=148.72.232.167;" + "Initial Catalog=VSQuickShare;" + "User Id=VSQuickShare;" + "Password=bmBq^765;";
            return connectionString;
        }
        public static void showMessage(string text)
        {
            //MessageBox.Show(text, "LazzyCoder Manager", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }
    }
}