using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiChat.Controllers
{
    public class LogonController : ApiController
    {
        // GET api/logon
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/logon/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/logon
        public void Post([FromBody]string value)
        {
        }

        // PUT api/logon/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/logon/5
        public void Delete(int id)
        {
        }
    }
}
