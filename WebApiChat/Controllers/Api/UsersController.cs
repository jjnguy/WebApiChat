using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Data;
using WebApiChat.Models;
using Dapper;
using WebApiChat.Infra;

namespace WebApiChat.Controllers.Api
{
    public class UsersController : BaseApiController
    {
        [Route("api/users/{id:int}")]
        public User Get(long id)
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                return con.Query<User>("SELECT * FROM users WHERE id = @id", new { id }).Single();
            });
        }

        [Route("api/users/{username}")]
        public User Get(string username)
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                return con.Query<User>("SELECT * FROM users WHERE username = @username", new { username }).Single();
            });
        }

        [Route("api/users/find/{username}"), HttpGet]
        public List<User> Find(string username)
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                return con.Query<User>("SELECT * FROM users WHERE username LIKE @username", 
                    new { username = "%" + username + "%" }).ToList();
            });
        }
    }
}
