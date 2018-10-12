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
        private UIRefreshControl RefreshControl;

        protected CurrentForecastViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateRefreshControl();

            Presenter = new CurrentForecastPresenter(this);
            Presenter.start();
        }

        private void CreateRefreshControl() {
            RefreshControl = new UIRefreshControl();
            RefreshControl.AddTarget(OnUserRefresh, UIControlEvent.ValueChanged);
        }

        private void OnUserRefresh(Object sender, EventArgs e) {
            Presenter.OnUserRefresh();
        }

        public void RenderLabelsAreHidden(bool visible) {
            CityLabel.Hidden = visible;
            TemperatureLabel.Hidden = visible;
            SummaryLabel.Hidden = visible;
        }

        public void RenderLocality(string locality)
        {
            CityLabel.Text = locality;
        }

        public void RenderLoadingIndicator()
        {
            if (LoadingIndicator == null)
            {
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
        }

        public void StopLoadingIndicator()
        {
            LoadingIndicator.RemoveFromSuperview();
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
        }

    }
}
