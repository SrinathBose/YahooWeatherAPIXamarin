using YahooAPI;
using YahooAPI.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;

[assembly:ExportRenderer(typeof(StartButton),typeof(StartButtonRenderer))]

namespace YahooAPI.iOS
{
    public class StartButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = Control as UIButton;

                button.BackgroundColor = UIColor.FromRGB(0, 255, 0);

                button.TouchDown += (sender, ev) =>
                {
                    button.BackgroundColor = UIColor.FromRGB(255, 0, 0);
                };
           
                button.TouchUpInside += (sender, ev) =>
                {
                    button.BackgroundColor = UIColor.FromRGB(0, 255, 0);
                    MessagingCenter.Send<YahooAPIPage>(new YahooAPIPage(), "start");
                };


            }
        }
    }
}
