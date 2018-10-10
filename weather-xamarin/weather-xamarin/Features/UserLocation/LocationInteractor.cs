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
        private readonly CLLocationManager LocationManager;
        private readonly ILocationUpdateHandler Handler;

        public LocationInteractor(ILocationUpdateHandler updateHandler)
        {
            this.Handler = updateHandler;

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
                Location location = new Location(newLocation.Coordinate.Latitude, 
                                                 newLocation.Coordinate.Longitude, 
                                                 placemarks[0].Locality);

                Handler.OnLocationChanged(location);
            }));
        }

        public void OnLocationChanged(Location location)
        {
            Console.WriteLine($"You're in {location.CityName}");
        }

        public void StartUpdatingLocation()
        {
            LocationManager.RequestWhenInUseAuthorization();

            if (CLLocationManager.Status == CLAuthorizationStatus.Denied) {
                return;
            }

            LocationManager.DistanceFilter = 8046.72; // ~5 miles to update 
            LocationManager.StartUpdatingLocation();
        }
    }
}
