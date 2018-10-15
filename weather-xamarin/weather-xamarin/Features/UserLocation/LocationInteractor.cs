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
        private Location CurrentLocation;
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

        public override void LocationsUpdated(CLLocationManager manager, CLLocation[] locations)
        {
            var geocoder = new CLGeocoder();
            var newLocation = locations[0];

            // TODO see if the anonymous function causes a memory leak
            geocoder.ReverseGeocodeLocation(newLocation, new CLGeocodeCompletionHandler((placemarks, error) =>
            {
                if (placemarks.Length < 1)
                {
                    return;
                }

                CLPlacemark placemark = placemarks[0];

                Location location = new Location(newLocation.Coordinate.Latitude,
                                                 newLocation.Coordinate.Longitude,
                                                 placemark.Locality,
                                                 placemark.SubLocality);

                CurrentLocation = location;
                Handler.OnLocationChanged(location);
            }));
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

        public Location GetCurrentLocation()
        {
            return CurrentLocation;
        }
    }
}
