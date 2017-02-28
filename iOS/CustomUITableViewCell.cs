using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using System;

namespace YahooAPI.iOS
{
    public class CustomUITableViewCell : UITableViewCell, INativeElementView
    {
        public UILabel cityNameLbl { get; set; }
        public UIButton findWeatherBtn { get; set;}

        public CustomCell customCell { get; private set; }
        public Element Element => customCell;

        public CustomUITableViewCell(string cellId, CustomCell cell) : base(UITableViewCellStyle.Default, cellId)
        {
            customCell = cell;

            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 200);

            cityNameLbl = new UILabel()
            {
                Frame = new CGRect(10,10,100,45),
                TextColor = UIColor.FromRGB(127, 51, 0),
                BackgroundColor = UIColor.Clear
            };

            findWeatherBtn = new UIButton()
            {
                Frame = new CGRect(200, 10, 200, 40),
                BackgroundColor = UIColor.FromRGB(0, 0, 255),
                UserInteractionEnabled = true,
            };

            ContentView.Add(cityNameLbl);
            ContentView.Add(findWeatherBtn);

            findWeatherBtn.TouchDown += (sender, e) =>
            {
                BackgroundColor = UIColor.FromRGB(122, 120, 125);
                MessagingCenter.Send<CityListView, string>(new CityListView(), "findWeather", cell.City);
            };
        }

        public void UpdateCell(CustomCell cell)
        {
            cityNameLbl.Text = cell.City;
            findWeatherBtn.SetTitle("FIND", UIControlState.Normal);
            findWeatherBtn.Alpha = 0.5f;
        }
    }
}
