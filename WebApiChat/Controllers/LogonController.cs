using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Data;
using WebApiChat.Models;
using Dapper;

namespace WebApiChat.Controllers
{
    public class LogonController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(string Username)
        {
            ConnectionHelper.WithNewConnection(con => 
            {
                var user = con.Query<User>("SELECT * FROM users WHERE username = @Username", new { Username }).SingleOrDefault();
                if (user == null)
                {
                    var id = con.Query<ulong>("INSERT INTO users (username) VALUES (@Username); SELECT LAST_INSERT_ID()", new { Username }).Single();
                    Sesh.CurrentUser = new User
                    {
                        id = (long)id,
                        username = Username
                    };
                } 
                else 
                {
                    Sesh.CurrentUser = user;
                }
            });
            return GoHome();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Sesh.CurrentUser = null;
            Session.Abandon();
            return GoHome();
        }
	}
}
