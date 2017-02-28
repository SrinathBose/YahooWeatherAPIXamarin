using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net.Http;

using Xamarin.Forms;

namespace YahooAPI
{
    public partial class CityWeatherReport : ContentPage, INotifyPropertyChanged
    {
        bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }

            set
            {
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public CityWeatherReport(string selectedCity)
        {
            InitializeComponent();

            IsLoading = false;
            BindingContext = this;

            InvokeWeatherReport(selectedCity);
        }

        async void InvokeWeatherReport(string selectedCity)
        {
            IsLoading = true;
            await GetWeatherReport(selectedCity);
        }

        public async Task GetWeatherReport(string selectedCity)
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var url = new Uri(URLManager.GetURL(selectedCity));
            var response = await client.GetAsync(url);
            IsLoading = false;

            if (response.IsSuccessStatusCode)
            {
                var weatherReportResponse = response.Content.ReadAsStringAsync().Result;
                if (weatherReportResponse != "")
                        WeatherReport.Text = selectedCity + " Weather Report \n\n" + new WeatherReportJSONParser().ParseWeatherData(weatherReportResponse);
            }
        }
    }
}
