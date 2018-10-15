using System;
namespace weatherxamarin.Model.UserLocation
{
    public class Location
    {
        public double Latitude;
        public double Longitude;
        public string CityName;
        public string SubLocalityName;

        public Location(double latitude, double longitude, string cityName, string subLocalityName)
        {
            Latitude = latitude;
            Longitude = longitude;
            CityName = cityName;
            SubLocalityName = subLocalityName;
        }
    }
}
