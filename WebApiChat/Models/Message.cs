using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiChat.Models
{
    public class Message
    {
        public long id;
        public long from;
        public long to;
        public DateTime timestamp = DateTime.UtcNow;
        public string body;
    }
}