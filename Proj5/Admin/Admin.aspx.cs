﻿using System;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean isFound = Auth(username.Text, password.Text);
            if (isFound == false)
            {
                XDocument doc = XDocument.Load((Server.MapPath("../App_Data/Staff.xml")));
                XElement root = new XElement("user");
                root.Add(new XElement("Name", username.Text));

                //Encrypt Password in XML
                Class1 encrypt = new Class1();
                string temp = encrypt.encryptAsync(password.Text);
                root.Add(new XElement("Password", temp));

                doc.Element("allUsers").Add(root);
                doc.Save((Server.MapPath("../App_Data/Staff.xml")));
                //Response.Redirect("Timezone.aspx");
                username.Text = "";
                password.Text = "";

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
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath("../App_Data/Staff.xml")))
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
                            Class1 decrypt = new Class1();
                            string spass = reader.ReadString();
                            if (decrypt.decryptAsync(spass) == ps)//Decrypt Password
                            {
                                //Response.Write("p: " + reader.Value);
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