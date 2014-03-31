using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiChat.State;

namespace WebApiChat.Infra
{
    public class ChatBasePage : System.Web.Mvc.WebViewPage
    {
        public ChatSession Sesh
        {
            get
            {
                return new ChatSession(Session);
            }
        }

        public override void Execute()
        {
        }
    }

    public class ChatBasePage<T> : System.Web.Mvc.WebViewPage<T>
    {
        public ChatSession Sesh
        {
            get
            {
                return new ChatSession(Session);
            }
        }

        public override void Execute()
        {
        }
    }
}
