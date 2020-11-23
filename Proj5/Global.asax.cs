using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.Xml.Linq;

namespace Proj5
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_End()
        {
            Response.Write("< hr /> This page was last accessed at " + DateTime.Now.ToString());
        }

        void Application_Error(object sender, EventArgs e) //Custom error page if duplicate account
        {
            if (HttpContext.Current == null) return;
            HttpContext context = HttpContext.Current;

            Exception exception = context.Server.GetLastError();

            if (exception.InnerException.Message.Equals("Duplicate Account"))
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}