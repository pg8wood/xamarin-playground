using System;
namespace weatherxamarin.WeatherApi
{
    public class CurrentForecast
    {
        public long time;
        public string summary;
        public string icon;
        public double precipIntensity;
        public double precipProbability;
        public string precipType;
        public double temperature;
        public double apparentTemperature;
        public double dewPoint;
        public double humidity;
        public double pressure;
        public double windSpeed;
        public double windGust;
        public int windBearing;
        public double cloudCover;
        public int uvIndex;
        public double visibility;
        public double ozone;

        public CurrentForecast(long time, string summary, string icon, double precipIntensity, double precipProbability, string precipType, double temperature, double apparentTemperature, double dewPoint, double humidity, double pressure, double windSpeed, double windGust, int windBearing, double cloudCover, int uvIndex, double visibility, double ozone)
        {
            this.time = time;
            this.summary = summary;
            this.icon = icon;
            this.precipIntensity = precipIntensity;
            this.precipProbability = precipProbability;
            this.precipType = precipType;
            this.temperature = temperature;
            this.apparentTemperature = apparentTemperature;
            this.dewPoint = dewPoint;
            this.humidity = humidity;
            this.pressure = pressure;
            this.windSpeed = windSpeed;
            this.windGust = windGust;
            this.windBearing = windBearing;
            this.cloudCover = cloudCover;
            this.uvIndex = uvIndex;
            this.visibility = visibility;
            this.ozone = ozone;
        }
    }
}

