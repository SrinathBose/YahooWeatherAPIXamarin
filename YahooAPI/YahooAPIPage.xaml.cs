using Xamarin.Forms;
using System;
using YahooAPI;

namespace YahooAPI
{
    
    public partial class YahooAPIPage : ContentPage
    {
        public YahooAPIPage()
        {
            InitializeComponent();
           
            MessagingCenter.Subscribe<YahooAPIPage>(this, "start", async (messageSender) =>
            {
                if (NetworkConnectivityManager.CheckConnectionStatus())
                    await Navigation.PushAsync(new CityListView());
                else
                    await DisplayAlert("Alert", "Cannot connect to Internet, Check your connectios.", "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<YahooAPIPage>(new YahooAPIPage(), "start");
        }
    }
}
