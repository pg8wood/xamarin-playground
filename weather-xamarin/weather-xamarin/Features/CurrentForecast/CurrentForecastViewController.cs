using System;

using UIKit;
using weatherxamarin.Features.CurrentWeather;
using weatherxamarin.WeatherApi;

namespace weatherxamarin
{
    public partial class CurrentForecastViewController : UIViewController, ICurrentForecastView
    {
        private CurrentForecastPresenter Presenter;

        protected CurrentForecastViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void OnReceiveForecast(CurrentForecast forecast)
        {
            Console.WriteLine("hit onReceiveForecast!");
            Console.WriteLine(forecast);
            //throw new NotImplementedException();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Console.WriteLine("current forecast view loaded");

            showLoadingIndicator();

            Presenter = new CurrentForecastPresenter(this);
            Presenter.start();
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
