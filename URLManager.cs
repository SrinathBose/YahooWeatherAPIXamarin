using System;
namespace YahooAPI
{
    public class URLManager
    {
         string domainNameStr;
         string queryPart1Str;
         string queryPart2Str;
         string countryStr;
         string queryPart3Str;

        public URLManager()
        {
            domainNameStr = "https://query.yahooapis.com/v1/public/yql";
            queryPart1Str = "?q=select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22";
            queryPart2Str = "%2C%20";
            countryStr = "in";
            queryPart3Str = "%22)&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        }

        public  string GetURL(string selectedCity)
        {
            return domainNameStr + queryPart1Str + selectedCity + queryPart2Str + countryStr + queryPart3Str;
        }
    }
}
