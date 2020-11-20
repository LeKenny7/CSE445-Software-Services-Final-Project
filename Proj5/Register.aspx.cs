using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Proj5
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean isFound = Auth(username.Text, password.Text);
            if (isFound == false)
            {
                XDocument doc = XDocument.Load((Server.MapPath("App_Data/Member.xml")));
                XElement root = new XElement("user");
                root.Add(new XElement("Name", username.Text));
                root.Add(new XElement("Password", password.Text));

                doc.Element("allUsers").Add(root);
                doc.Save((Server.MapPath("App_Data/Member.xml")));
                FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                //Response.Redirect("Timezone.aspx");
            }
            else
            {
                throw new Exception("Duplicate Account");
            }
        }

        public Boolean Auth(String un, String ps)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath("App_Data/Member.xml")))
                {
                    Boolean validUser = false;
                    Boolean validPassword = false;

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name"))
                        {
                            //Response.Write(reader.Value);
                            string sname = reader.ReadString();
                            if (sname == un)
                            {
                                validUser = true;
                                //Response.Write("u: " + reader.Value);
                                reader.Read();
                                //Response.Write("read: " + reader.Value);
                            }
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Password"))
                        {
                            string spass = reader.ReadString();
                            if (spass == ps)
                            {
                                //Response.Write("p: " + reader.Value);
                                validPassword = true;
                            }
                        }
                        if (validPassword == true && validUser == true)
                        {
                            //Response.Redirect("timezone.aspx");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ec) { }
            return false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}