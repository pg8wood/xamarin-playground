using System;
using System.Threading.Tasks;

namespace weatherxamarin.WeatherApi
{
    public interface IWeatherApi
    {
        async Task GetCurrentForecast(double latitude, double longitude);
    }
}
