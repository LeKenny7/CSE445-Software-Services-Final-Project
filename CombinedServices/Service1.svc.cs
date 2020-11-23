using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace CombinedServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetWeatherData(string zipcode) //Get weather informaiton based off zipcode
        {
            string info = "";
            string url = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + "&appid=a54af6322f5f69ea4ff5ebcbb7c0d711"; //Get weather report

            using (var webClient = new System.Net.WebClient()) //Get contents from the URL
            {
                string json = webClient.DownloadString(url); //string of the json file
                int[] indexes = new int[7]; //holds index of key word used to identify json results
                int[] skip = { 7, 14, 6, 12, 10, 10, 10 }; //tells how many indexes to skip to reach wanted json result
                string result;
                string[] weatherInfo = new string[7]; //holds wanted json results
                indexes[0] = json.IndexOf("main\":\""); //Main weather condition
                indexes[1] = json.IndexOf("description"); //Describes weather condition
                indexes[2] = json.IndexOf("temp\":"); //Current temperature
                indexes[3] = json.IndexOf("feels_like"); //What the temperature feels like
                indexes[4] = json.IndexOf("temp_min"); //Min temp for the day
                indexes[5] = json.IndexOf("temp_max"); //Max temp for the day
                indexes[6] = json.IndexOf("humidity"); //Humidity level

                for (int i = 0; i < indexes.Length; i++) //Finds and saves the specific json results
                {
                    result = json.Substring(indexes[i]).Substring(skip[i]); //substring starting from wanted json result
                    while (!(result[0] == ',') && !(result[0] == '\"') && !(result[0] == '}')) //Stop adding chars when reach stop char
                    {
                        weatherInfo[i] += result[0]; //Add char one by one
                        result = result.Substring(1); //Remove first char of substring
                    }
                }
                string tempTemp = ""; //temporaryly hold Temperature
                double temperature;
                for (int i = 2; i < 6; i++) //Convert temperature from Kelvin to Farenheit
                {
                    temperature = Convert.ToDouble(weatherInfo[i]); //Make string double
                    temperature = Math.Round((temperature - 273.15) * 9 / 5 + 32); //Kelvin to Farenheit and round to nearest digit
                    tempTemp = temperature.ToString(); //double to string
                    tempTemp += "F"; //Add units
                    weatherInfo[i] = tempTemp; //Replace Kelvin with the new Farenheit values
                }
                //Convert string array to single string for user readibility
                info = "<br/>Main: " + weatherInfo[0] + "<br/>Description: " + weatherInfo[1] + "<br/>Temp: " + weatherInfo[2] + "<br/>Feels Like: " + weatherInfo[3]
                    + "<br/>Temp Min: " + weatherInfo[4] + "<br/>Temp Max: " + weatherInfo[5] + "<br/>Humidity: " + weatherInfo[6];
            }
            return string.Format(info);
        }
        public string GetFilteredData(string URLstring) //Get filtered string of news URL Content
        {
            List<string> sortedWords = new List<string>(); //Takes the list of words after they have been sorted by frequency
            WebsiteStringServiceReference.ServiceClient wordFilter = new WebsiteStringServiceReference.ServiceClient(); //service reference
            string URLContent = wordFilter.GetWebContent(URLstring); //Gets the string of the URL content

            URLContent = URLContent.Replace("\r", " ").Replace("\n", " ").Replace("\t", " "); //Delete some of the typical html texts like \r and \t
            URLContent = findBody(URLContent); //Gets the main content of the news article (the main text)
            URLContent = replaceString(URLContent); //remove the majority of html formatted text to get just the words the user cares about

            URLContent = URLContent.Replace("&amp", "&"); //Some symbols are returned as hex or decimal so we change it to readible char
            URLContent = URLContent.Replace("&#038", "&");
            URLContent = URLContent.Replace("&#x27", "'");
            URLContent = URLContent.Replace("&#39", "'");
            URLContent = URLContent.Replace("&#8221", "\"");
            URLContent = URLContent.Replace("&#8220", "\"");
            URLContent = URLContent.Replace("&#8217", "'");
            URLContent = URLContent.Replace("&#8216", "'");
            URLContent = URLContent.Replace("&#8212", "-");
            URLContent = URLContent.Replace("&quot", "\"");

            URLContent = URLContent.ToLower(); //Make all words lowercase to work with easier
            URLContent = removeStopWords(URLContent); //Removes function words
            URLContent = Regex.Replace(URLContent, @"[ ]{2,}", " "); //Replaces double spaces with a single space
            URLContent = URLContent.Replace(" \n", "\n");
            URLContent = Regex.Replace(URLContent, @"[\n]{2,}", "\n"); //Replaces double new lines with a single new line

            return string.Format(URLContent);
        }
        public string GetTopWordsData(string filteredString) //Gets top 10 words from the filtered news URL content
        {
            string top10WordsString = ""; //String will hold the list of most use words
            List<string> sortedWords = new List<string>(); //Takes the list of words after they have been sorted by frequency

            sortedWords = splitString(filteredString); //split the string into an array string
            string[] removeChars = { "{", "=", "}", "'", "\"" }; //unwanted characters
            sortedWords.Remove(""); //Remove an empty space
            foreach (var character in removeChars) //Remove unwanted characters
            {
                sortedWords.Remove(character);
            }
            for (int i = 0; i < 10; i++) //Gets the top 10 words into a nice list string
            {
                top10WordsString = top10WordsString + (i + 1) + ": " + sortedWords[i] + "\n";
            }
            return string.Format(top10WordsString);
        }
        public string findBody(string URLContent) //Get the main body of text of the news article
        {
            int paraPos1 = URLContent.IndexOf("<p>"); //most bodies of text start with either <p> or <p class
            int paraClassPos1 = URLContent.IndexOf("<p class");
            int pos1 = 0;

            int pos2 = URLContent.LastIndexOf("</p>"); //End of body of text
            if (paraClassPos1 == -1 && paraPos1 != -1) //Check if string only used <p class
            {
                pos1 = paraPos1;
            }
            else if (paraClassPos1 != -1 && paraPos1 == -1) //Check if string only used <p>
            {
                pos1 = paraClassPos1;
            }
            else if (paraClassPos1 < paraPos1) //If both <p class and <p> exists, get the one that appears first
            {
                pos1 = paraClassPos1;
            }
            else if (paraClassPos1 > paraPos1)
            {
                pos1 = paraPos1;
            }
            int subStringLength = pos2 - pos1; //Get length of substring
            URLContent = URLContent.Substring(pos1, subStringLength); //Get just the body of text
            return URLContent;
        }
        public List<string> splitString(string URLContent) //Split the string into a string List
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '|', ';', ')', '\n' }; //These chars separate the words
            string[] words = URLContent.Split(delimiterChars); //Split the string based on the chars
            List<string> sortedWords = new List<string>(); //List to hold the words
            List<int> wordCount = new List<int>(); //List to hold the quantity of the words above
            var stringGroup = words.GroupBy(x => x); //Group the words together by quantity
            foreach (var word in stringGroup) //Add string into the two lists
            {
                if(word.Key.Length == 1)
                {

                }
                else if (wordCount.Count() == 0) //Start the initial lists
                {
                    wordCount.Add(word.Count());
                    sortedWords.Add(word.Key);
                    wordCount.Add(0);
                    sortedWords.Add("zeroPlaceHolder");
                }
                else
                {
                    for (int i = 0; i < wordCount.Count(); i++) //Insert into list, the more quantity the more it is in the front of list
                    {
                        if (wordCount[i] <= word.Count())
                        {
                            wordCount.Insert(i, word.Count());
                            sortedWords.Insert(i, word.Key);
                            i = wordCount.Count() + 1;
                        }
                    }
                }
            }
            return sortedWords;
        }
        public string replaceBracket(string URLContent) //Removes text that are within { }. Main text Usually won't use this
        {
            int index = 0;
            int symbolCount = 0;
            bool remove = false;
            foreach (char c in URLContent) //Delete eachc char one by one until { and } are deleted
            {
                if (c == '{')
                {
                    symbolCount++; //If we encounter nested {, we must continue until we find all of their }
                    remove = true;
                }
                if (remove == true) //There is still a lonely {, we will continue to remove chars
                {
                    if (c == '}')
                    {
                        symbolCount--; //Condition to stop the loop
                    }
                    URLContent = URLContent.Remove(index, 1); //Remove a char
                    index--; //Decrement so that when we do increment, we will remain in the same position since a char was removed
                    if (symbolCount == 0) //return condition
                    {
                        remove = false;
                        return URLContent;
                    }
                }
                index++;
            }
            return URLContent;
        }
        public string replaceString(string URLContent) //Removes the html format around our main text
        {
            int pos1 = URLContent.IndexOf("<"); //Positions of specific char/strings we need to filter out
            int bracketPos1 = URLContent.IndexOf("{");
            int scriptPos1 = URLContent.IndexOf("<script>");
            int script2Pos1 = URLContent.IndexOf("<script >");
            int stylePos1 = URLContent.IndexOf("<style>");
            int arrowPos = URLContent.IndexOf("-->");

            if (pos1 >= 0)
            {
                if (scriptPos1 == pos1) //If we find <script> remove everything until </script>
                {
                    int scriptPos2 = URLContent.IndexOf("</script>");
                    int count = (scriptPos2 + 9) - scriptPos1;
                    URLContent = URLContent.Remove(scriptPos1, count);
                    URLContent = replaceString(URLContent);
                }
                else if (script2Pos1 == pos1) //If we find <script > remove everything until </script>
                {
                    int scriptPos2 = URLContent.IndexOf("</script>");
                    int count = (scriptPos2 + 9) - script2Pos1;
                    URLContent = URLContent.Remove(script2Pos1, count);
                    URLContent = replaceString(URLContent);
                }
                else if (stylePos1 == pos1) //If we find <style > remove everything until </style>
                {
                    int stylePos2 = URLContent.IndexOf("</style>");
                    int count = (stylePos2 + 8) - stylePos1;
                    URLContent = URLContent.Remove(stylePos1, count);
                    URLContent = replaceString(URLContent);
                }
                else if ((bracketPos1 < pos1 && bracketPos1 >= 0) || (bracketPos1 >= 0 && pos1 == -1)) //If we find bracket remove everything until end bracket
                {
                    string subURLContent = URLContent.Substring(bracketPos1);
                    URLContent = URLContent.Substring(0, bracketPos1);
                    URLContent = URLContent + replaceBracket(subURLContent);
                    URLContent = replaceString(URLContent);
                }
                else //If we find < remove everything until >
                {
                    int pos2 = URLContent.IndexOf(">");
                    URLContent = URLContent.Insert(pos2 + 1, " ");
                    int count = (pos2 + 1) - pos1;
                    if (count < 1)
                    {
                        if (arrowPos >= 0 && arrowPos < pos1) //If the < is just an arrow like <--, remove the arrow
                        {
                            URLContent = URLContent.Remove(arrowPos, 3);
                            URLContent = replaceString(URLContent);
                        }
                    }
                    else //remove everything until >
                    {
                        URLContent = URLContent.Remove(pos1, count);
                        URLContent = replaceString(URLContent);
                    }
                }
            }
            return URLContent;
        }

        public string removeStopWords(string URLContent) //Removes the function words
        {
            string combinedWords = "";
            char[] delimiterChars = { ' ', ',', '.', ':', '|', ';', ')', '\n', '(' }; //Split the strings first into
            string[] words = URLContent.Split(delimiterChars);
            for (int i = 0; i < words.Length; i++) //recombine the array into a string
            {
                combinedWords = combinedWords + " " + words[i];
            }
            URLContent = combinedWords;
            //List of function words that were defined online
            string[] stopWords = {" a ", " about ", " above ", " across ", " after ", " afterwards ", " again ", " against ", " all ",
                " almost ", " alone ", " along ", " already ", " also ", " although ", " always ", " am ", " among ", " amongst ",
                " amoungst ", " an ", " and ", " another ", " any ", " anyhow ", " anyone ", " anything ", " anyway ", " anywhere ", " are ",
                " around ", " as ", " at ", " be ", " became ", " because ", " been ", " before ", " beforehand ", " behind ", " being ",
                " below ", " beside ", " besides ", " between ", " beyond ", " both ", " but ", " by ", " can ", " cannot ", " could ",
                " dare ", " despite ", " did ", " do ", " does ", " done ", " down ", " during ", " each ", " eg ", " either ", " else ",
                " elsewhere ", " enough ", " etc ", " even ", " ever ", " every ", " everyone ", " everything ", " everywhere ", " except ",
                " few ", " first ", " for ", " former ", " formerly ", " from ", " furhter ", " from ", " further ", " furthermore ", " had ",
                " has ", " have ", " he ", " hence ", " her ", " here ", " hereabouts ", " hereafter ", " hereby ", " herein ", " hereinafter ",
                " heretofore ", " hereunder ", " hereupon ", " herewith ", " hers ", " herself ", " him ", " himself ", " his ", " how ",
                " however ", " i ", " ie ", " if ", " in ", " indeed ", " inside ", " instead ", " into ", " is ", " it ", " its ", " itself ",
                " last ", " latter ", " latterly ", " least ", " less ", " lot ", " lots ", " many ", " may ", " me ", " meanwhie ", " might ",
                " mine ", " more ", " moreover ", " most ", " mostly ", " much ", " my ", " myself ", " namely ", " near ", " need ",
                " neither ", " never ", " nevertheless ", " next ", " no ", " nobody ", " none ", " noone ", " nor ", " not ", " nothing ",
                " now ", " nowhere ", " of ", " off ", " often ", " oftentimes ", " on ", " once ", " one ", " only ", " onto ", " or ",
                " other ", " others ", " otherwise ", " ought ", " our ", " ours ", " ourselves ", " out ", " outside ", " over ", " per ",
                " perhaps ", " rather ", " re ", "said", " same ", " second ", " several ", " shall ", " she ", " should ", " since ", " so ",
                " some ", " somehow ", " someone ", " something ", " sometime ", " sometimes ", " somewhat ", " somewhere ", " still ",
                " such ", " than ", " that ", " the ", " their ", " theirs ", " them ", " themselves ", " then ", " thence ", " there ",
                " thereabouts ", " thereafter ", " thereby ", " therefore ", " therein ", " thereof ", " thereon ", " thereupon ", " these ",
                " they ", " third ", " this ", " those ", " though ", " through ", " throughout ", " thru ", " thus ", " to ", " together ",
                " too ", " top ", " toward ", " towards ", " under ", " until ", " up ", " upon ", " us ", " used ", " very ", " via ", " was ",
                " we ", " well ", " were ", " what ", " whatever ", " when ", " whence ", " whenever ", " where ", " whereafter ", " whereas ",
                " whereby ", " wherein ", " whereupon ", " wherever ", " whether ", " which ", " while ", " whither ", " who ", " whoever ",
                " whole ", " whom ", " whose ", " why ", " whyever ", " will ", " with ", " within ", " would ", " yes ", " yet ", " you ",
                " your ", " yours ", " yourself ", " yourselves"};
            for (int i = 0; i < stopWords.Length; i++) //Remove those function words
            {
                URLContent = URLContent.Replace(stopWords[i], " ");
            }
            return URLContent;
        }
    }
}
