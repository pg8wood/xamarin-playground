using System;
using weatherxamarin.Model.UserLocation;

namespace weatherxamarin.Features.UserLocation
{
    // NOTE: With an Android implementation, I'd assume this interface would live
    // somewhere outside of the iOS project. Some sort of shared place. That's 
    // to come later...
    public interface ILocationManager
    {
        void StartUpdatingLocation();
        void OnLocationChanged(Location location);
    }
}
