using System;
namespace weatherxamarin.Model.UserLocation
{
    public class Location
    {
        public double Latitude;
        public double Longitude;
        public string CityName;

        public Location(double latitude, double longitude, string cityName)
        {
            Latitude = latitude;
            Longitude = longitude;
            CityName = cityName;
        }
    }
}
