using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proj5
{
    public partial class _Default : Page //Home page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e) //Go to members page to do zip code and city services
        {
            Response.Redirect("Member/Member.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e) //Go to staff page to view current members
        {
            Response.Redirect("Staff/Staff.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e) //Go to Admin page to create staff logins
        {
            Response.Redirect("Admin/Admin.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e) //Go to log into an account
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e) //Goes to register an account which first needs to go through captcha
        {
            Response.Redirect("CaptchaForm.aspx");
        }
    }
}