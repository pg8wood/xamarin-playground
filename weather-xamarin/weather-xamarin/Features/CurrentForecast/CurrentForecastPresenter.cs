using System;
using System.Threading.Tasks;
using weatherxamarin.Features.UserLocation;
using weatherxamarin.Model.UserLocation;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public interface ICurrentForecastView
    {
        void RenderLoadingIndicator();
        void RenderWeatherSummary(string iconName, double temperature, string summary);
        void StopLoadingIndicator();
    }

    public class CurrentForecastPresenter: ILocationUpdateHandler
    {
        private ICurrentForecastView View;
        private CurrentForecastInteractor Interactor;
        private ILocationManager LocationInteractor;

        public CurrentForecastPresenter(ICurrentForecastView View)
        {
            this.View = View;
        }

        public void start()
        {
            Interactor = new CurrentForecastInteractor();

            /*
             * Since LocationInteractor is an iOS-specific implementation, this
             * line makes this presenter iOS-dependent. 
             * 
             * TODO: When adding Android capabilities, make the CurrentForecastPresenter
             * an abstract class with a few concrete methods, but location-related stuff 
             * should be abstract and implemented at a platform-specifc presenter implementation. 
             */
            LocationInteractor = new LocationInteractor(this);
            LocationInteractor.StartUpdatingLocation();

            View.RenderLoadingIndicator();
        }

        public async void OnLocationChanged(Location location)
        {
            CurrentForecast forecast = await Interactor.GetCurrentForecast(location.Latitude, location.Longitude);
            View.RenderWeatherSummary(forecast.icon, forecast.temperature, forecast.summary);
            View.StopLoadingIndicator();
        }
    }
}
