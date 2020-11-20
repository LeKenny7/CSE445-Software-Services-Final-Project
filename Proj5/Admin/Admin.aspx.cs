using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace Proj5.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                /*if (!User.Identity.Name.Equals("TA"))
                {
                    Response.Redirect("../Default.aspx");
                }*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean isFound = Auth(username.Text, password.Text);
            if (isFound == false)
            {
                XDocument doc = XDocument.Load((Server.MapPath("../App_Data/Staff.xml")));
                XElement root = new XElement("user");
                root.Add(new XElement("Name", username.Text));
                root.Add(new XElement("Password", password.Text));

                doc.Element("allUsers").Add(root);
                doc.Save((Server.MapPath("../App_Data/Staff.xml")));
                //Response.Redirect("Timezone.aspx");
                username.Text = "";
                password.Text = "";

            }
            else
            {
                //throw new Exception("Duplicate Account");
            }
        }

        public bool A(String username)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Server.MapPath("../App_Data/Staff.xml"));
            XmlNodeList all = xd.DocumentElement.SelectNodes("/allUsers/user");
            Response.Write("size: " + all.Count);
            foreach (XmlNode child in all)
            {
                String un = child.SelectSingleNode("Name").InnerText;
                Response.Write(un);
                if (un.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }


        public Boolean Auth(String un, String ps)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath("../App_Data/Staff.xml")))
                {
                    Boolean validUser = false;
                    Boolean validPassword = false;

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name"))
                        {
                            Response.Write(reader.Value);
                            string sname = reader.ReadString();
                            if (sname == un)
                            {
                                validUser = true;
                                Response.Write("u: " + reader.Value);
                                reader.Read();
                                Response.Write("read: " + reader.Value);
                            }
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Password"))
                        {
                            string spass = reader.ReadString();
                            if (spass == ps)
                            {
                                Response.Write("p: " + reader.Value);
                                validPassword = true;
                            }
                        }
                        if (validPassword == true && validUser == true)
                        {
                            //Response.Redirect("../Timezone.aspx");
                            return true;
                        }
                        else
                        {
                            //errorLabel.Text = "Incorrect username or password: if you dont have an account please register!";
                        }
                    }
                }
            }
            catch (Exception ec) { }
            return false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../Default.aspx");

        }
    }
}