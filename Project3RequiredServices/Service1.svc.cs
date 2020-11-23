using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Services.Description;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project3RequiredServices
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string output = "";
        public decimal SolarIntensity(decimal latitude, decimal longitude)
        {

            

            //string URL = "https://api.nytimes.com/svc/search/v2/articlesearch.json?q=election&api-key=s1ZGU41UAmxXmQJl55z7w9Ywo4v1U1cE";
            string URL = "https://api.openuv.io/api/v1/uv?lat=-33.34&lng=115.342";


            /*var webClient = new System.Net.WebClient();
            var json = webClient.DownloadString(URL);
            Debug.WriteLine(json);

            */
            Debug.WriteLine("Before API Call! \n");
            callAPI(latitude, longitude);
            Debug.WriteLine("After API Call! \n");


            decimal uvOutput = Convert.ToDecimal(output);
           
            return uvOutput;
        }

        private async void callAPI(decimal lat, decimal longi)
        {
            //https://api.openuv.io/api/v1/uv?lat=-33.34&lng=115.342
            const string URL = "https://api.openuv.io/";
            string urlParameters = "api/v1/uv?lat=";
            urlParameters += Convert.ToString(lat) + "&lng=" + Convert.ToString(longi) + "&dt=2020-10-19T01:26:35.968Z";
            string urlParameters2 = "api/v1/uv?lat=37.7749&lng=122.4194&dt=2020-10-19T01:26:35.968Z";

            Debug.WriteLine(urlParameters);
            Debug.WriteLine(urlParameters2);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-access-token", "5c94ff1901e284ef24a81fff58dabc5d");

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Successful Response! \n");
                // Parse the response body.
                /* var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                 foreach (var d in dataObjects)
                 {
                     Console.WriteLine("{0}", d.Name);
                 }*/
                string stuff = await response.Content.ReadAsStringAsync();
                string findUV = stuff.Substring(16);
                string uv = "";
                while(findUV[0] != ',')
                {
                    uv += findUV[0];
                    findUV = findUV.Substring(1);
                }
                Debug.WriteLine(stuff);
                Debug.WriteLine(uv);
                output = uv;
            }
            else
            {
                Debug.WriteLine("Failed Response! \n");
                Debug.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }


        }
        public string[] Top10Words(string url)
        {
            string[] topWords = new string[10];
            var webClient = new System.Net.WebClient();
            var json = webClient.DownloadString(url);

            json = Regex.Replace(json, "<.*?>", String.Empty);
            json = Regex.Replace(json, "{.*?}", String.Empty);
            json = Regex.Replace(json, "(.*?)", String.Empty);

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = json.Split(delimiterChars);
            var counts = words
            .GroupBy(w => w)
            .Select(g => new { Word = g.Key, Count = g.Count() })
            .ToList();

            counts.Sort((obj1, obj2) => obj1.Count.CompareTo(obj2.Count));

            for (int i = 0; i < topWords.Length; i++)
            {
                topWords[i] = counts[i].Word;
                Debug.WriteLine(topWords[i]);
            }

            return topWords;
        }

        public decimal WindIntensity(decimal latitude, decimal longitude)
        {
            string urlParameters = "http://api.openweathermap.org/data/2.5/weather?lat=";
            urlParameters += Convert.ToString(latitude) + "&lon=" + Convert.ToString(longitude) + "&appid=eab8e9b3a12b565bd07ac4f7dab41cb1";
            string url = "http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=eab8e9b3a12b565bd07ac4f7dab41cb1";

            var webClient = new System.Net.WebClient();
            var json = webClient.DownloadString(urlParameters);
            Debug.WriteLine(urlParameters);
            Debug.WriteLine(url);
            Debug.WriteLine(json);

            int index = json.IndexOf("wind");
            string result = json.Substring(index);
            result = result.Substring(15);
            Debug.WriteLine(result);
            string wind = "";
            while (result[0] != ',')
            {
                wind += result[0];
                result = result.Substring(1);
            }

            Debug.WriteLine(wind);
            decimal windIndex = Convert.ToDecimal(wind);
            return windIndex;
        }

        public decimal HailIntensity(decimal latitude, decimal longitude)
        {
            decimal lat1 = latitude - 1;
            decimal lng1 = longitude - 1;
            decimal lat2 = latitude + 1;
            decimal lng2 = longitude + 1;
            string box = "" + Convert.ToString(lat1) + "," + Convert.ToString(lng1) + "," + Convert.ToString(lat2) + "," + Convert.ToString(lng2);
            string url = "https://www.ncdc.noaa.gov/swdiws/csv/nx3hail/20100101:20200821?stat=count&bbox=" + box;
            var webClient = new System.Net.WebClient();
            var response = webClient.DownloadString(url);
            string count = "";
            for(int i = 0; i < 15; i++)
            {
                if (Char.IsDigit(response[i]))
                {
                    count += response[i];
                }
            }
            Debug.WriteLine(response);

            return Convert.ToDecimal(count);
        }

        public decimal LocationPop(string cityName)
        {


            string url = "https://public.opendatasoft.com/api/records/1.0/search/?dataset=geonames-all-cities-with-a-population-1000&rows=1&q=";
            url += cityName + "&facet=timezone&facet=country" ;
            var webClient = new System.Net.WebClient();
            var response = webClient.DownloadString(url);

            int index = response.IndexOf("population\":");
            Debug.WriteLine(index);
            string text = "";
            
               text = response.Substring(index);
            
            
            Debug.WriteLine(text);
            string count = "";
            for (int i = 0; i < 25; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    count += text[i];
                }
            }
            Debug.WriteLine(count);
            return Convert.ToDecimal(count);
        }
    }
    public class result
    {
        double uv  { get; set;}

    }
}
