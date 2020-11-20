using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Proj5
{
    public partial class CurrentUsername : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name != null && HttpContext.Current.User.Identity.Name != "")
            {
                currentUserLabel.Text = "Welcome, " + HttpContext.Current.User.Identity.Name;
                LogoutButton.Visible = true;
            }
            else
            {
                currentUserLabel.Text = "Not Logged In";
                LogoutButton.Visible = false;
            }

        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            currentUserLabel.Text = "Not Logged In";
            LogoutButton.Visible = false;
        }
    }
}