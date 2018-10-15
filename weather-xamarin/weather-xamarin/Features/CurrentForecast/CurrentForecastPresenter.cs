using System;
using System.Threading.Tasks;
using weatherxamarin.Features.UserLocation;
using weatherxamarin.Model.UserLocation;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public interface ICurrentForecastView
    {
        void HideLabels(bool hidden);
        void RenderLoadingIndicator();
        void RenderLocationName(string cityName, string subLocalityName);
        void RenderWeatherSummary(string iconName, double temperature, string summary);
        void StopLoadingIndicator();
    }

    public class CurrentForecastPresenter: ILocationUpdateHandler
    {
        private readonly ICurrentForecastView View;
        private CurrentForecastInteractor Interactor;
        private ILocationManager LocationInteractor;

        public CurrentForecastPresenter(ICurrentForecastView View)
        {
            this.View = View;
        }

        public void Start()
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

            View.HideLabels(true);
            View.RenderLoadingIndicator();
        }

        public async void OnUserRefresh() {
            Location currentLocation = LocationInteractor.GetCurrentLocation();

            /* 
             * Is this the best way to check, or would an async getter be better? 
             * Currently, bailing here achieves the same result, as the UI is updated
             * by the ILocationUpdateHandler. But I'm not quite sure if bailing
             * here is antipattern or not.
             */
            if (currentLocation == null)
            {
                return;
            }

            CurrentForecast forecast = await Interactor.GetCurrentForecast(currentLocation.Latitude, currentLocation.Longitude);

            View.RenderWeatherSummary(forecast.icon, forecast.temperature, forecast.summary);
            View.StopLoadingIndicator();
        }


        // ILocationUpdate Handler methods

        public async void OnLocationChanged(Location newLocation)
        {
            CurrentForecast forecast = await Interactor.GetCurrentForecast(newLocation.Latitude, newLocation.Longitude);
            View.RenderWeatherSummary(forecast.icon, forecast.temperature, forecast.summary);
            View.RenderLocationName(newLocation.CityName, newLocation.SubLocalityName);
            View.StopLoadingIndicator();
            View.HideLabels(false);
        }
    }
}
