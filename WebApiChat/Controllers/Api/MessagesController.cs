using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Data;
using Dapper;
using WebApiChat.Infra;
using WebApiChat.Models;

namespace WebApiChat.Controllers.Api
{
    public class MessagesController : BaseApiController
    {
        // GET api/<controller>
        public IEnumerable<Message> Get(long To, long From)
        {
            return ConnectionHelper.WithNewConnection(
                con => 
                    con.Query<Message>(
                    "SELECT * FROM messages WHERE (`to` = @To AND `from` = @From) OR (`to` = @From AND `from` = @To)", new { To, From }));
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Message message)
        {
            ConnectionHelper.WithNewConnection(con =>
            {
                con.Execute("INSERT INTO messages (`from`, `to`, timestamp, body) VALUES (@from, @to, @timestamp, @body)",
                    new { from = message.from, to = message.to, timestamp = message.timestamp, body = message.body });
            });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
