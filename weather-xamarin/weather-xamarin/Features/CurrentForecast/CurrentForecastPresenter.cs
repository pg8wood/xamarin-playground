using System;
using System.Threading.Tasks;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public interface ICurrentForecastView
    {
        void OnReceiveForecast(CurrentForecast forecast);
        void RenderLoadingIndicator();
    }

    public class CurrentForecastPresenter
    {
        private ICurrentForecastView View;
        private CurrentForecastInteractor Interactor;

        public CurrentForecastPresenter(ICurrentForecastView View)
        {
            this.View = View;
        }

        public void start() {
            Interactor = new CurrentForecastInteractor();
            View.RenderLoadingIndicator();
            processForecast();
        }

        private async void processForecast() {
            CurrentForecast forecast = await Interactor.GetCurrentForecast();
            View.OnReceiveForecast(forecast);
        }

    }
}
