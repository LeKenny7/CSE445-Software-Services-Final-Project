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

namespace Proj5.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e) //login button
        {
            Boolean isFound = Auth(username.Text, password.Text); //Checks if admin login is exists and is correct
            if (isFound == false)
            {
                XDocument doc = XDocument.Load((Server.MapPath("../App_Data/Staff.xml"))); //Add name to staff
                XElement root = new XElement("user");
                root.Add(new XElement("Name", username.Text));

                //Encrypt Password in XML
                Class1 encrypt = new Class1();
                string temp = encrypt.encryptAsync(password.Text);
                root.Add(new XElement("Password", temp));

                doc.Element("allUsers").Add(root);
                doc.Save((Server.MapPath("../App_Data/Staff.xml")));
                username.Text = "";
                password.Text = "";

            }
            else
            {
                throw new Exception("Duplicate Account"); //Custome duplicate account error
            }
        }

        public Boolean Auth(String un, String ps) //Checks if authentic account through staff.xml
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath("../App_Data/Staff.xml")))
                {
                    Boolean validUser = false;
                    Boolean validPassword = false;

                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name"))//Checks if names are the same
                        {
                            string sname = reader.ReadString();
                            if (sname == un)
                            {
                                validUser = true;
                                reader.Read();
                            }
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Password")) //checks if passwords are the same
                        {
                            Class1 decrypt = new Class1();
                            string spass = reader.ReadString();
                            if (decrypt.decryptAsync(spass) == ps)//Decrypt Password
                            {
                                validPassword = true;
                            }
                        }
                        if (validPassword == true && validUser == true)
                        {
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

        protected void Button2_Click(object sender, EventArgs e) //Go back to home
        {
            Response.Redirect("../Default.aspx");
        }
    }
}