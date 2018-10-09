using System;
using System.Threading.Tasks;

namespace weatherxamarin.WeatherApi
{
    public interface IWeatherApi
    {
        Task<CurrentForecast> GetCurrentForecast(double latitude, double longitude);
    }
}
