using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AirQualityService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetPollutionData(string zipCode)
        {
            string city = "";
            string zipCodeURL = "https://www.mapquestapi.com/search/v2/radius?origin=" + zipCode + "&key=DVg0oPgjl3CotyALGwtHpfl05kGdH4pX"; //Need to get cityName from the zipcode
            using (var webClient1 = new System.Net.WebClient()) //Get contents from the URL
            {
                string zipJson = webClient1.DownloadString(zipCodeURL); //string of the json file
                int cityIndex = zipJson.IndexOf("adminArea5"); //Text right before the city name
                string cityResult = zipJson.Substring(cityIndex).Substring(13); //create substring starting from first char of city name
                while (cityResult[0] != '\"') //gets entire string of the cityName until quotation mark
                {
                    city += cityResult[0]; //adds first char to city name
                    cityResult = cityResult.Substring(1); //removes first char
                }
            }

            string AQI = "";
            string AQIDescription = "";
            string url = "https://api.waqi.info/feed/" + city + "/?token=983fb4cd89c97689dbcccaa8728aa4c2bfbdfa93"; //Get Air Quality Index

            using (var webClient = new System.Net.WebClient()) //Get contents from the URL
            {
                string json = webClient.DownloadString(url); //string of the json file
                int index = json.IndexOf("aqi"); //text right before giving the air quality index number
                string result = json.Substring(index).Substring(5); ////create substring starting from first char of AQI
                while (result[0] != ',')//gets entire string of the cityName until comma
                {
                    AQI += result[0]; //adds first char to AQI
                    result = result.Substring(1); //removes first char
                }
            }
            switch (Int32.Parse(AQI)) //Translate AQI score for user readibility
            {
                case int n when (n >= 0 && n <= 50): //0-50 is good
                    AQIDescription = "Good";
                    break;
                case int n when (n >= 51 && n <= 100): //51-100 is moderate
                    AQIDescription = "Moderate";
                    break;
                case int n when (n >= 101 && n <= 150): //101-150 is unhealthy for sensitive groups
                    AQIDescription = "Unhealthy for Sensitive Groups";
                    break;
                case int n when (n >= 151 && n <= 200): //151-200 is unhealthy
                    AQIDescription = "Unhealthy";
                    break;
                case int n when (n >= 201 && n <= 300): //201-300 is very unhealthy
                    AQIDescription = "Very Unhealthy";
                    break;
                case int n when (n >= 301 && n <= 500): //300-500 is hazardous
                    AQIDescription = "Hazardous";
                    break;
                default:
                    AQIDescription = "Invalid AQI"; //anything else is invalid
                    break;
            }
            AQI = "Air Quality Index: " + AQI + "Quality: " + AQIDescription; //Readible string for user
            return string.Format(AQI);
        }
    }
}
