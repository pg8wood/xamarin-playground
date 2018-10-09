using System;

using UIKit;

using weatherxamarin.WeatherApi;

namespace weatherxamarin
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            showLoadingIndicator();
        }

        private void showLoadingIndicator() {
            var indicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray)
            {
                Frame = new CoreGraphics.CGRect(0, 0, 50, 50),
                Center = View.Center
            };
            View.AddSubview(indicator);
            View.BringSubviewToFront(indicator);
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
            indicator.StartAnimating();
        }
    }
}
