using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Redirector.Models;

namespace Redirector.Controllers
{
    public class RedirectController : Controller
    {
        public ActionResult Index()
        {
            string url = Request.ServerVariables[ "HTTP_HOST" ]; // "1800-vitamins.net"

            var datacontext = new RedirectDataContext();
            var redirectUrl = from r in datacontext.Redirects
                              where r.@base == url
                              select r.redirect1;

            if ( redirectUrl.Count() > 0 )
            {
                return Redirect( redirectUrl.First() );
            }
            else
            {
                return null;
            }
        }

    }
}
