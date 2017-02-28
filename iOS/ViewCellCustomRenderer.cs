using Xamarin.Forms.Platform.iOS;
using UIKit;
using System.ComponentModel;
using YahooAPI;
using YahooAPI.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomCell),typeof(ViewCellCustomRenderer))]
namespace YahooAPI.iOS
{
    public class ViewCellCustomRenderer : ViewCellRenderer
    {
        CustomUITableViewCell cell;

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {

            var customCell = (CustomCell)item;

            cell = reusableCell as CustomUITableViewCell;
            if (cell == null)
                cell = new CustomUITableViewCell(item.GetType().FullName, customCell);
            else
                cell.customCell.PropertyChanged -= OnCustomCellPropertyChanged;
            
            customCell.PropertyChanged += OnCustomCellPropertyChanged;

            cell.UpdateCell(customCell);

            return cell;
        }

        void OnCustomCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var nativeCell = (CustomCell)sender;
            if (e.PropertyName == CustomCell.CityNameProperty.PropertyName)
            {
                cell.cityNameLbl.Text = nativeCell.City;
            }
            else if (e.PropertyName == CustomCell.FindWeatherProperty.PropertyName)
            {
                cell.findWeatherBtn.SetTitle(nativeCell.Find, UIControlState.Normal);
                cell.findWeatherBtn.TouchDown += (sen, eve) => System.Diagnostics.Debug.WriteLine("Property changed");
            }
        }


    }
}
