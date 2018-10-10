using System;
using System.Threading.Tasks;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public class CurrentForecastInteractor
    {
        public CurrentForecastInteractor()
        {
        }

        // TODO get user's location
        public async Task<CurrentForecast> GetCurrentForecast()
        {
            return await DarkSkyApi.Instance.GetCurrentForecast(38.0293, 78.4767);
        }
    }
}
