using Xamarin.Forms;
using System;

namespace YahooAPI
{
    public partial class YahooAPIPage : ContentPage
    {
        public YahooAPIPage()
        {
            InitializeComponent();
        }

        async void StartYahooAPI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CityListView());
        }
    }
}
