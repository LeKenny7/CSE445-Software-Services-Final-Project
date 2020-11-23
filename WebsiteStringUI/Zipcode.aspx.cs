using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteStringUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieID"]; //checks for any cookies
            if((myCookies == null) || (myCookies["Zipcode"]==""))
            {
                zipcodeLabel.Text = "No history of zipcode";
            }
            else
            {
                zipcodeLabel.Text = "Last entered valid zipcode: " + myCookies["Zipcode"]; //uses last entered zipcode
            }
        }

        protected void zipcodeButton_Click(object sender, EventArgs e)
        {
            string zipcode = zipcodeTextBox.Text;
            string weatherInfo = "<br/>Weather Info:";
            WeatherServiceReference.Service1Client weatherService = new WeatherServiceReference.Service1Client(); //uses weather service
            try //checks for valid zipcode
            {
                weatherInfo += weatherService.GetWeatherData(zipcode);
            }
            catch(System.ServiceModel.FaultException) //redo if incorrect zipcode
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

            string url = "http://webstrar63.fulton.asu.edu/page5/Service1.svc/zip?zipcode=" + zipcode; //code for air pollution service
            var client = new WebClient();
            string response = "";
            try
            {
                response = client.DownloadString(url);
            }
            catch (WebException)
            {
                PollutionInfoLabel.Text = "No information for that zipcode";
                return;
            }
            response = client.DownloadString(url);
            response = response.Replace("&lt;br/&gt;", "");
            response = response.Replace("&lt;/br&gt;", "</br>");
            PollutionInfoLabel.Text = response;
        }
    }
}