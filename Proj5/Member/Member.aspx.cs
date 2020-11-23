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
            HttpCookie myCookies = Request.Cookies["myCookieID"]; //checks for any cookies
            if ((myCookies == null) || (myCookies["Zipcode"] == ""))
            {
                zipcodeLabel.Text = "No history of zipcode";
            }
            else
            {
                zipcodeLabel.Text = "Last entered valid zipcode: " + myCookies["Zipcode"]; //uses last entered zipcode
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //Home page button
        {
            Response.Redirect("../Default.aspx");
        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            Multi.Service1Client client = new Multi.Service1Client(); // Makes sure both text boxes are full
            string zip = zipcodeTextBox.Text;
            string weatherInfo = "<br/>Weather Info:";
            WeatherServiceReference.Service1Client weatherService = new WeatherServiceReference.Service1Client(); //uses weather service
            try //checks for valid zipcode
            {
                tz.Text = client.GetTimezone(zip);
                weatherInfo += weatherService.GetWeatherData(zip);
            }
            catch (System.ServiceModel.FaultException) //redo if incorrect zipcode
            {
                weatherInfoLabel.Text = "Incorrect zipcode, try again";
                return;
            }
            weatherInfoLabel.Text = weatherInfo;

            HttpCookie myCookies = new HttpCookie("myCookieID");
            myCookies["Zipcode"] = zipcodeTextBox.Text; //add zipcode to cookie
            myCookies.Expires = DateTime.Now.AddMonths(6); //remove cookie after 6 months
            Response.Cookies.Add(myCookies); //Add to cookie
            zipcodeLabel.Text = "Zipcode stored in cookie: " + myCookies["Zipcode"]; //Let user know zipcode is stored in cookie
        }

        protected void CityButton_Click(object sender, EventArgs e) //Gets city population based off of city name
        {
            CityPopService.Service1Client cityPopClient = new CityPopService.Service1Client();
            decimal outputPop = cityPopClient.LocationPop(CityBox.Text);
            PopOutput.Text = outputPop.ToString();
        }
    }
}