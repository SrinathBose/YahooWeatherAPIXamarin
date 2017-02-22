using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace YahooAPI
{
    public partial class CityWeatherReport : ContentPage
    {
        public CityWeatherReport(string selectedCity)
        {
            InitializeComponent();
            WeatherReport.Text = selectedCity;
            InvokeWeatherReport(selectedCity);
        }

        async void InvokeWeatherReport(string selectedCity)
        {
            await GetWeatherReport(selectedCity);
        }

        public async Task GetWeatherReport(string selectedCity)
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var url = new Uri(new URLManager().GetURL(selectedCity));
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var weatherReportResponse = response.Content.ReadAsStringAsync().Result;
                if (weatherReportResponse != "")
                    WeatherReport.Text = selectedCity + " Weather Report \n\n" + new WeatherReportJSONParser().ParseWeatherData(weatherReportResponse);

            }
        }
    }
}
