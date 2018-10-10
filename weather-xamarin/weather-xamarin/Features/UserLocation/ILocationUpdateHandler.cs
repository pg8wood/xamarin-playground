using System;
using weatherxamarin.Model.UserLocation;

namespace weatherxamarin.Features.UserLocation
{
    public interface ILocationUpdateHandler
    {
        void OnLocationChanged(Location location);
    }
}
