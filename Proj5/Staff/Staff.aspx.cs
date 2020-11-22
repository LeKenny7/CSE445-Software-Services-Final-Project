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
                        //Response.Write(User.Identity.Name + " is a Staff Member");
                    }
                    else
                    {
                        //Response.Write(User.Identity.Name + " is NOT a Staff Member");
                        Response.Redirect("../Default.aspx");
                    }
                }
                catch(Exception ec)
                {
                    Response.Redirect("../Default.aspx");
                }
            }

        }

        public bool Auth(String username)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Server.MapPath("../App_Data/Staff.xml"));
            XmlNodeList all = xd.DocumentElement.SelectNodes("/allUsers/user");
            //Response.Write("size: " + all.Count);
            foreach (XmlNode child in all)
            {
                String un = child.SelectSingleNode("Name").InnerText;
                //Response.Write(un);
                if(un.Equals(username))
                {
                    return true;
                }
            }
                return false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
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
                full += "Member " + count + ": Username [" + un + "] Password: [" + pw + "]<br/>";
                count++;
            }
            xml.Text = full;
        }
    }
}