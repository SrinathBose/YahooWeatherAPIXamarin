using System;
using Xamarin.Forms;

namespace YahooAPI
{
    public partial class CityListView : ContentPage
    {
        public string selectedcity;
        public CityListView()
        {
            InitializeComponent();
            CityList.ItemsSource = new CityListProvider().GetCities();
        }
        async void OnCitySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            selectedcity = e.SelectedItem.ToString();
            await Navigation.PushAsync(new CityWeatherReport(selectedcity));
        }
    }
}
