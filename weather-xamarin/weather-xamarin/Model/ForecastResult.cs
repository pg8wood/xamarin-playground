using System;
namespace weatherxamarin.WeatherApi
{
    public class ForecastResult {

        public double latitude;
        public double longitude;
        public string timezone;
        public CurrentForecast currently;
        public int offset;

        public ForecastResult(double latitude, double longitude, string timezone, CurrentForecast currently, int offset)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.timezone = timezone ?? throw new ArgumentNullException(nameof(timezone));
            this.currently = currently ?? throw new ArgumentNullException(nameof(currently));
            this.offset = offset;
        }
    }
}
