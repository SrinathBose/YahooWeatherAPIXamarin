using Xamarin.Forms;
using YahooAPI;
using System.Collections.Generic;

namespace YahooAPI
{
    public partial class CityListView : ContentPage
    {
         public CityListView()
        {
            InitializeComponent();

            List<string> cityList = new CityListProvider().GetCities();
            CityList.ItemsSource = cityList;
            CityList.ItemTemplate = new DataTemplate(() =>
            {
                CustomCell cell = new CustomCell();
                cell.SetBinding(CustomCell.CityNameProperty, ".");

                return cell;
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<CityListView, string>(this, "findWeather", async (messageSender, selectedCity) => await Navigation.PushAsync(new CityWeatherReport(selectedCity)));
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<CityListView, string>(this, "findWeather");
        }
    }
}
