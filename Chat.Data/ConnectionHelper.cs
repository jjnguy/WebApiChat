using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Chat.Data
{
    public static class ConnectionHelper
    {
        const string ConnectonString = "server=localhost;user=jjnguy;database=chat;port=3307;password=asdf1234;";
        public static T WithNewConnection<T>(Func<DbConnection, T> Code)
        {
            DbConnection con = new MySqlConnection(ConnectonString);
            con.Open();

            var result = Code(con);

            con.Close();

            return result;
        }
        public static void WithNewConnection(Action<DbConnection> Code)
        {
            DbConnection con = new MySqlConnection(ConnectonString);
            con.Open();

            Code(con);

            con.Close();
        }
    }
}
