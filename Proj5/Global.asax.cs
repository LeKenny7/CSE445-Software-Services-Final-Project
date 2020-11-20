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

    }
}