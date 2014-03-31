using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChat.Models;

namespace WebApiChat.State
{
    public class ChatSession
    {
        private HttpSessionStateBase sesh;

        public ChatSession(HttpSessionStateBase session)
        {
            sesh = session;
        }

        public User CurrentUser
        {
            get
            {
                return (User)sesh["current_user"];
            }
            set
            {
                sesh["current_user"] = value;
            }
        }

        public bool IsLoggedOn
        {
            get
            {
                return CurrentUser != null;
            }
        }
    }
}
