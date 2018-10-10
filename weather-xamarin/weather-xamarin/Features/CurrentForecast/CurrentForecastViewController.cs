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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Console.WriteLine("current forecast view loaded");

            RenderLoadingIndicator();

            Presenter = new CurrentForecastPresenter(this);
            Presenter.start();
        }

        // ICurrentForecastView methods

        public void OnReceiveForecast(CurrentForecast forecast)
        {
            // Make the view even dumber than this method

            Console.WriteLine("hit onReceiveForecast!");
            Console.WriteLine(forecast);

            // TODO: update UI
        }

        public void RenderLoadingIndicator() {
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
