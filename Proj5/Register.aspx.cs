using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using EncryptionLibrary;

namespace Proj5
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e) //Register account button
        {
            if (username.Text.Length == 0 || password.Text.Length == 0)
            {
                Boolean isFound = Auth(username.Text, password.Text);
                if (isFound == false)
                {
                    XDocument doc = XDocument.Load((Server.MapPath("App_Data/Member.xml"))); //Add account credentials to member.xml
                    XElement root = new XElement("user");
                    root.Add(new XElement("Name", username.Text));

                    //Encrypt Password in XML
                    Class1 encrypt = new Class1();
                    string temp = encrypt.encryptAsync(password.Text);
                    root.Add(new XElement("Password", temp));

                    doc.Element("allUsers").Add(root);
                    doc.Save((Server.MapPath("App_Data/Member.xml")));
                    FormsAuthentication.RedirectFromLoginPage(username.Text, false); //Check if it account is authentic from member.xml
                }
                else
                {
                    throw new Exception("Duplicate Account");   //Custom error
                }
            }
            else //a text box is blank
            {
                username.Text = "";
                password.Text = "";
            }
        }

        public Boolean Auth(String un, String ps) //Check if user is authentic
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath("App_Data/Member.xml"))) //look through member.xml
                {
                    Boolean validUser = false;
                    Boolean validPassword = false;

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name")) //Check for username
                        {
                            string sname = reader.ReadString();
                            if (sname == un)
                            {
                                validUser = true;
                                reader.Read();
                            }
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Password")) //Check for password
                        {
                            Class1 decrypt = new Class1();
                            string spass = reader.ReadString();
                            if (decrypt.decryptAsync(spass) == ps)//Decrypt Password
                            {
                                validPassword = true;
                            }
                        }
                        if (validPassword == true && validUser == true) //Return true if credentials are in the xml file
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ec) { }
            return false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e) //link to login page
        {
            Response.Redirect("Login.aspx");
        }
    }
}