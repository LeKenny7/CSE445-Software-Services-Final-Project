using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Timezone
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //This is the timezone Service for A6, the others were in here for the deployment
        public string GetTimezone(string zipcode)
        {
            string coordURL = "https://www.zipcodeapi.com/rest/bOZ1pU6gquArhawPerllMCmsPtz13ECJst7q7lQJOq4V25N7tP6Zvy3djTwQRvhx/info.json/" + zipcode + "/degrees"; // invokes service to obtain lat and long of given zipcode

            //variables to hold the final return string and data to send into the next
            string finalData = "";
            double lat;
            double lng;

            using (var webClient = new System.Net.WebClient())//using the web client
            {
                var json = webClient.DownloadString(coordURL); // Retrieves JSON Document

                if (!json.Equals("{}"))//if the json is not empty
                {
                    Zipcode2 zipcodeResponse = JsonConvert.DeserializeObject<Zipcode2>(json);//convert into the second Zipcode Object
                    //gather latitude and longitude to be placed into a new API call
                    lat = zipcodeResponse.lat;
                    lng = zipcodeResponse.lng;
                    string timezoneURL = "https://api.ipgeolocation.io/timezone?apiKey=b19e1e494315409e8eb639c29d430f76&lat=" + lat + "&long=" + lng;//second api call to use the gathered lattitude and longitude to find the inecessary information
                    using (var newWebClient = new System.Net.WebClient())//start the new/next webclient
                    {
                        var finalJson = newWebClient.DownloadString(timezoneURL);//create a new/final json
                        if (!finalJson.Equals("{}"))//if this json is not empty
                        {
                            Time timeResponse = JsonConvert.DeserializeObject<Time>(finalJson);//deserialize the JSON into the time object
                            finalData = "Timezone: " + zipcodeResponse.timezone.timezone_abbr + " Current Time and Date: " + timeResponse.date_time_txt;//format the final string to return the timezone name and the time and date
                        }
                        else
                        {
                            finalData = "Error";//if something happens with either service then produce an error
                        }
                    }
                }
                else
                {
                    finalData = "Error";//if something happens with either service then produce an error
                }
            }
            return finalData;//return final formatted string
        }
        //This set of objects/lists (Time, TimeZone2, and Zipcode2) are part of the Timezone Service
        //nested lists and objects to deserialize JSON to get the timezone information
        public class Time
        {
            public string timezone
            {
                get;
                set;
            }
            public string timezone_offset
            {
                get;
                set;
            }
            public string date
            {
                get;
                set;
            }
            public string date_time
            {
                get;
                set;
            }
            public string date_time_txt
            {
                get;
                set;
            }
            public string date_time_wti
            {
                get;
                set;
            }
            public string date_time_ymd
            {
                get;
                set;
            }
            public string date_time_unix
            {
                get;
                set;
            }
            public string time_24
            {
                get;
                set;
            }
            public string time_12
            {
                get;
                set;
            }
            public string week
            {
                get;
                set;
            }
            public string month
            {
                get;
                set;
            }
            public string year
            {
                get;
                set;
            }
            public string year_abbr
            {
                get;
                set;
            }
            public string is_dst
            {
                get;
                set;
            }
            public string dst_savings
            {
                get;
                set;
            }
        }
        public class Timezone2
        {
            public string timezone_identifier
            {
                get;
                set;
            }
            public string timezone_abbr
            {
                get;
                set;
            }
            public string utc_offset_sec
            {
                get;
                set;
            }
            public string is_dst
            {
                get;
                set;
            }
        }
        public class Zipcode2
        {
            public string zip_code
            {
                get;
                set;
            }
            public double lat
            {
                get;
                set;
            }
            public double lng
            {
                get;
                set;
            }
            public string city
            {
                get;
                set;
            }
            public string state
            {
                get;
                set;
            }
            public Timezone2 timezone
            {
                get;
                set;
            }
            public IList<string> acceptable_city_names
            {
                get;
                set;
            }
            public IList<int> area_codes
            {
                get;
                set;
            }
        }
    }
}
