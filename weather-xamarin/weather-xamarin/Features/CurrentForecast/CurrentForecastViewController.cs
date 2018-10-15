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
            Presenter.Start();
        }

        private void CreateRefreshControl() {
            RefreshControl = new UIRefreshControl();
            RefreshControl.AddTarget(OnUserRefresh, UIControlEvent.ValueChanged);
            ScrollView.AddSubview(RefreshControl);
        }

        private void OnUserRefresh(Object sender, EventArgs e) {
            Presenter.OnUserRefresh();
        }

        public void HideLabels(bool hidden) {
            CityLabel.Hidden = hidden;
            SubLocalityLabel.Hidden = hidden;
            TemperatureLabel.Hidden = hidden;
            SummaryLabel.Hidden = hidden;
        }
        public void RenderLocationName(string cityName, string subLocalityName)
        {
            CityLabel.Text = cityName;
            SubLocalityLabel.Text = subLocalityName;
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
            RefreshControl.EndRefreshing();
            LoadingIndicator.RemoveFromSuperview();
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
        }

    }
}
