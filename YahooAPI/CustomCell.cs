using Xamarin.Forms;

namespace YahooAPI
{
    public class CustomCell : ViewCell
    {
        public static readonly BindableProperty CityNameProperty = BindableProperty.Create("City", typeof(string), typeof(CustomCell));
        public static readonly BindableProperty FindWeatherProperty = BindableProperty.Create("Find", typeof(string), typeof(CustomCell));
        public string City
        {
            get
            {
                return (string)GetValue(CityNameProperty);
            }
            set
            {
                SetValue(CityNameProperty, value);
            }
        }

        public string Find
        {
            get
            {
                return (string)GetValue(FindWeatherProperty);
            }
            set
            {
                SetValue(FindWeatherProperty, value);
            }
        }
    }
}
