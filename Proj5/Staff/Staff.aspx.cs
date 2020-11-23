using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EncryptionLibrary;

namespace Proj5.Staff
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    if (Auth(User.Identity.Name))
                    {
                    }
                    else
                    {
                        Response.Redirect("../Default.aspx"); //Deny access if not a staff member
                    }
                }
                catch(Exception ec)
                {
                    Response.Redirect("../Default.aspx");
                }
            }

        }

        public bool Auth(String username) //Check if user is a staff by verifying information in staff.xml file
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Server.MapPath("../App_Data/Staff.xml"));
            XmlNodeList all = xd.DocumentElement.SelectNodes("/allUsers/user");
            foreach (XmlNode child in all) //Looks through each staff member in staff.xml
            {
                String un = child.SelectSingleNode("Name").InnerText;
                if(un.Equals(username))
                {
                    return true;
                }
            }
                return false;
        }

        protected void Button1_Click(object sender, EventArgs e) //home button
        {
            Response.Redirect("../Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e) //View all members users and encrypted passwords
        {
            String full = "";
            int count = 1;
            XmlDocument xd = new XmlDocument();
            xd.Load(Server.MapPath("../App_Data/Member.xml"));
            XmlNodeList all = xd.DocumentElement.SelectNodes("/allUsers/user");
            //Response.Write("size: " + all.Count);
            foreach (XmlNode child in all)
            {
                String un = child.SelectSingleNode("Name").InnerText;
                String pw = child.SelectSingleNode("Password").InnerText;//Leave password Encrypted
                full += "Member " + count + ": Username [" + un + "] Password: [" + pw + "]<br/>"; //This is the string output
                count++;
            }
            xml.Text = full;
        }
    }
}