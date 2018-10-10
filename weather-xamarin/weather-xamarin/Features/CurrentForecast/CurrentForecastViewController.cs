using System;

using UIKit;
using weatherxamarin.Features.CurrentWeather;
using weatherxamarin.WeatherApi;

namespace weatherxamarin
{
    public partial class CurrentForecastViewController : UIViewController, ICurrentForecastView
    {
        private CurrentForecastPresenter Presenter;
        private UIActivityIndicatorView LoadingIndicator;

        protected CurrentForecastViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TemperatureLabel.Hidden = true;
            SummaryLabel.Hidden = true;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Presenter = new CurrentForecastPresenter(this);
            Presenter.start();
        }


        // ICurrentForecastView methods


        public void RenderLoadingIndicator() {
            Console.WriteLine("LoadingIndicator:");
            Console.WriteLine(LoadingIndicator);
            if (LoadingIndicator == null) {
                LoadingIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray)
                {
                    Frame = new CoreGraphics.CGRect(0, 0, 50, 50),
                    Center = View.Center
                };
                View.AddSubview(LoadingIndicator);
            }

            View.BringSubviewToFront(LoadingIndicator);
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
            LoadingIndicator.StartAnimating();
        }

        public void RenderWeatherSummary(string iconName, double temperature, string summary)
        {
            WeatherIcon.Image = UIImage.FromBundle(iconName);
            TemperatureLabel.Text = Math.Round(temperature).ToString() + "°F";
            SummaryLabel.Text = summary;
            TemperatureLabel.Hidden = false;
            SummaryLabel.Hidden = false;
        }

        public void StopLoadingIndicator()
        {
            LoadingIndicator.RemoveFromSuperview();
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
        }
    }
}
