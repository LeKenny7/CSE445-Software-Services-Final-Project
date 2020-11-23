using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EncryptionLibrary;

namespace Proj5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e) //submit login information
        {
            if(username.Text.Length == 0 || password.Text.Length == 0)
            {
                try
                {
                    if (Auth(username.Text, password.Text, "App_Data/Member.xml")) //Check if login is a member
                    {
                        FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                    }
                    else if (Auth(username.Text, password.Text, "App_Data/Staff.xml")) //Check if login is a staff
                    {

                        FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                    }
                    else //If not member or staff, do nothing and refresh text boxes
                    {
                        username.Text = "";
                        password.Text = "";
                        error.Text = "Incorrect Username/Password. Please try again or Register as a new Member!";
                    }
                }
                catch (Exception)
                {

                }
            }
            else //a text box is blank
            {
                username.Text = "";
                password.Text = "";
                error.Text = "Please fill out both Username and Password.";
            }
        }

        public Boolean Auth(String un, String ps, String fn) //Check if login info is correct
        {

            try
            {
                using (XmlTextReader reader = new XmlTextReader(Server.MapPath(fn)))
                {
                    Boolean validUser = false;
                    Boolean validPassword = false;

                    while (reader.Read())
                    {

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Name")) //Checks username
                        {
                            string sname = reader.ReadString();
                            if (sname == un)
                            {
                                validUser = true;
                                reader.Read();
                            }
                        }

                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Password")) //Checks password
                        {
                            Class1 decrypt = new Class1();
                        
                            string spass = reader.ReadString();
                            string decryptPassword = decrypt.decryptAsync(spass);
                            if (decryptPassword == ps)//Decrypt password
                            {
                                Debug.WriteLine("Password Found");
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

        protected void LinkButton1_Click(object sender, EventArgs e) //Wants to register so go to captcha form
        {
            Response.Redirect("CaptchaForm.aspx");
        }
    }
}