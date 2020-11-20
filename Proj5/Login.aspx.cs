using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Proj5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (Auth(username.Text, password.Text, "App_Data/Member.xml"))
                {
                    FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                }
                else if (Auth(username.Text, password.Text, "App_Data/Staff.xml"))
                {

                    FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                }
                else
                {
                    username.Text = "";
                    password.Text = "";
                }
            }
            catch(Exception)
            {

            }
            

        }

        public Boolean Auth(String un, String ps, String fn)
        {

            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath(fn)))
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
                            //Response.Redirect("timezone.aspx");
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}