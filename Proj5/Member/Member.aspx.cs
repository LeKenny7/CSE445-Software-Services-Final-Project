using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proj5.Member
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("../Default.aspx");
        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            Multi.Service1Client client = new Multi.Service1Client(); // Makes sure both text boxes are full
            string zip = zipcode.Text;
            tz.Text = client.GetTimezone(zip);
        }
    }
}