using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooAPI
{
    public class WeatherReportJSONParser
    {
        public WeatherReportJSONParser()
        {
        }

        public string ParseWeatherData(string updatainedWeatherReport)
        {
            string uptainedWeatherReport = JsonConvert.DeserializeObject(updatainedWeatherReport).ToString();

            var parsedWeatherReport = JObject.Parse(uptainedWeatherReport);

            var queryData = parsedWeatherReport["query"];
            var resultData = queryData["results"];
            var channelData = resultData["channel"];
            var windData = channelData["wind"];

            string windChillnessData = windData["chill"].ToString();
            string windSpeedData = windData["speed"].ToString();
            string windDirectionData = windData["direction"].ToString();

            string finaleWeatherResult = "Wind Chillness Is " + windChillnessData +
                "\nWind Speed Is " + windSpeedData +
                "\nWind Direction Is " + windDirectionData;

            return finaleWeatherResult;
        }
    }
}
