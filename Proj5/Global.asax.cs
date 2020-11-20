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
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //String fullM = Auth("App_Data/Member.xml");
            //String fullS = Auth("App_Data/Staff.xml");

            //write(fullM, "Member/Web.Config");
            //write(fullS, "Staff/Web.Config");
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            //Console.WriteLine("Error");

            if (HttpContext.Current == null) return;
            HttpContext context = HttpContext.Current;

            Exception exception = context.Server.GetLastError();

            Response.Redirect(exception.Message);

            /*string errorInfo =
               "<br>Offending URL: " + context.Request.Url.ToString() +
               "<br>Source: " + exception.Source +
               "<br>Message: " + exception.Message +
               "<br>Stack trace: " + exception.StackTrace;*/


            /*context.Response.Write(errorInfo);
            context.Server.ClearError();*/
            

            if (exception.Message.Equals("Duplicate Account"))
            {
                Response.Redirect("../Error.aspx");
            }
        }

    }
}