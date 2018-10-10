using System;
using System.Threading.Tasks;
using weatherxamarin.Features.UserLocation;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public interface ICurrentForecastView
    {
        void RenderLoadingIndicator();
        void RenderWeatherSummary(string iconName, double temperature, string summary);
        void StopLoadingIndicator();
    }

    public class CurrentForecastPresenter
    {
        private ICurrentForecastView View;
        private CurrentForecastInteractor Interactor;
        //private ILocationManager

        public CurrentForecastPresenter(ICurrentForecastView View)
        {
            this.View = View;
        }

        public void start()
        {
            Interactor = new CurrentForecastInteractor();
            View.RenderLoadingIndicator();
            ProcessForecast();
        }

        private async void ProcessForecast()
        {
            CurrentForecast forecast = await Interactor.GetCurrentForecast();
            View.RenderWeatherSummary(forecast.icon, forecast.temperature, forecast.summary);
            View.StopLoadingIndicator();
        }

    }
}
