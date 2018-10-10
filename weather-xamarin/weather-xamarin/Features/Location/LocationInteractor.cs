using System;
using CoreLocation;
using GLKit;

using weatherxamarin.Model.UserLocation;

namespace weatherxamarin.Features.UserLocation
{
    /*
     * iOS-specific implementation of LocationManager interface
     */
    public class LocationInteractor: CLLocationManagerDelegate, ILocationManager
    {
        private CLLocationManager LocationManager;

        public LocationInteractor()
        {
            LocationManager = new CLLocationManager
            {
                Delegate = this
            };
        }

        //public override [Export("locationManager:didUpdateLocations:")]
        public override void LocationsUpdated(CLLocationManager manager, CLLocation[] locations)
        {
            Console.WriteLine("locations updated");

            var geocoder = new CLGeocoder();
            var newLocation = locations[0];

            // TODO see if the anonymous function causes a memory leak
            geocoder.ReverseGeocodeLocation(newLocation, new CLGeocodeCompletionHandler((placemarks, error) =>
            {
                if (placemarks.Length < 1)
                {
                    return;
                }

                Console.WriteLine($"You're in {placemarks[0].Locality}");
                OnLocationChanged(new Location(newLocation.Coordinate.Latitude, newLocation.Coordinate.Longitude, placemarks[0].Locality));
            }));
        }

        public void OnLocationChanged(Location location)
        {
            Console.WriteLine($"You're in {location.CityName}");
        }

        public void StartUpdatingLocation()
        {
            LocationManager.RequestWhenInUseAuthorization();

            Console.WriteLine("requesting location...");

            if (CLLocationManager.Status == CLAuthorizationStatus.Denied) {
                Console.WriteLine("location denied :(");
                return;
            }

            LocationManager.StartUpdatingLocation();
        }
    }
}
