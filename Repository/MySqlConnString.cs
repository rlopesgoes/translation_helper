using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMLEditor.Repository
{
    public class MySqlConnString
    {
        private static String GetConnString()
        {
            return  "Server=yourserver;Port=3307;Database=translations;Uid=uid;Pwd=password;CharSet=utf8";
        }

        internal static MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
           return new MySql.Data.MySqlClient.MySqlConnection(MySqlConnString.GetConnString());
        }
    }
}
