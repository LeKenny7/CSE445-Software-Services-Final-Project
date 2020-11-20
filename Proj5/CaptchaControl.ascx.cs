using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proj5
{
    public partial class CaptchaControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void verifyButton_Click(object sender, EventArgs e) //Checks if correctly entered captcha
        {
            string userInput = CaptchaCode.Text;
            bool correctCaptcha = ExampleCaptcha.Validate(userInput); //returns if captcha is correct
            CaptchaCode.Text = null;    //clears the previous text

            if (correctCaptcha)
            {
                captchaLabel.Text = "Correct input!";
                Response.Redirect("Register.aspx"); //Go to zipcode page
                // TODO: proceed with protected action
            }
            else
            {
                captchaLabel.Text = "Wrong input!"; //Redoo
            }
        }
    }
}