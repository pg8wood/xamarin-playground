using System;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public class CurrentForecastInteractor
    {
        public CurrentForecastInteractor()
        {
        }

        // TODO get user's location
        public CurrentForecast getCurrentForecast()
        {
            return DarkSkyApi.Instance.GetCurrentForecast(38.0293, 78.4767).Result;
        }
    }
}
