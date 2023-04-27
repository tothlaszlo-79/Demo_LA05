using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LA05.ConFactory
{
    public class ConnFactory
    {

        private static string GetConStr()
        {
            var conStr = System.Configuration.ConfigurationManager.
                ConnectionStrings["Teszt"].ConnectionString;
            return conStr;
        }

        public static DbConnection GetOpenConnection()
        {

            var connection = new SqlConnection(GetConStr());
            connection.Open();

            return connection;
        }


    }
}
