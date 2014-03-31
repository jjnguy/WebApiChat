using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Data;
using WebApiChat.Models;
using Dapper;

namespace WebApiChat.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/users
        public List<User> Get()
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                return con.Query<User>("SELECT * FROM users").ToList();
            });
        }

        // GET api/users/5
        public User Get(int id)
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                return con.Query<User>("SELECT * FROM users WHERE id = @id", new { id }).Single();
            });
        }

        // POST api/users
        public void Post([FromBody]User value)
        {
            ConnectionHelper.WithNewConnection(con =>
            {
                con.Execute("INSERT INTO users (id, username) VALUES (@id, @username)", new { id = value.id, username = value.username });
            });
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]User value)
        {
            if (value.id != id) throw new Exception("Cannot change a user's id");
            ConnectionHelper.WithNewConnection(con =>
            {
                con.Execute("UPDATE users SET username = @username WHERE id = @id", value);
            });
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
            throw new Exception("Cannot delete users yet.");
        }
    }
}
