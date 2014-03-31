using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiChat.State;

namespace WebApiChat.Controllers
{
    public class BaseController : Controller
    {
        public ChatSession Sesh
        {
            get
            {
                return new ChatSession(Session);
            }
        }

        protected ActionResult GoHome()
        {
            return RedirectToAction("Index", "Home");
        }
	}
}
