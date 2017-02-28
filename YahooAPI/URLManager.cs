using System;
namespace YahooAPI
{
    public class URLManager
    {
         static string domainNameStr = "https://query.yahooapis.com/v1/public/yql";
         static string queryPart1Str = "?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22";
         static string queryPart2Str = "%2C%20";
         static string countryStr = "in";
         static string queryPart3Str = "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

        public static string GetURL(string selectedCity)
        {
            return domainNameStr + queryPart1Str + selectedCity + queryPart2Str + countryStr + queryPart3Str;
        }
    }
}
