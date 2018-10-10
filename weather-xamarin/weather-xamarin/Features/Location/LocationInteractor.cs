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
            LocationManager = new CLLocationManager();
            LocationManager.Delegate = this; 
        }

        public override void UpdatedLocation(CLLocationManager manager, CLLocation newLocation, CLLocation oldLocation)
        {
            base.UpdatedLocation(manager, newLocation, oldLocation);

            var geocoder = new CLGeocoder();

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

            if (CLLocationManager.Status == CLAuthorizationStatus.Denied) {
                return;
            }

            LocationManager.StartUpdatingLocation();
        }
    }
}
