using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Data;
using Dapper;

namespace Util
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionHelper.WithNewConnection(con =>
            {
                const string sql = "INSERT INTO users (username) VALUES (@username)";
                for (var i = 0; i < 20; i++)
                {
                    con.Execute(sql, new { username = "Example" + i });
                }
            });
        }
    }
}
