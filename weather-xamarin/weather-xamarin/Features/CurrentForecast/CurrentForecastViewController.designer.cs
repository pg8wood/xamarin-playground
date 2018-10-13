// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace weatherxamarin
{
    [Register ("CurrentForecastViewController")]
    partial class CurrentForecastViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ScrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SummaryLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TemperatureLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView WeatherIcon { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CityLabel != null) {
                CityLabel.Dispose ();
                CityLabel = null;
            }

            if (ScrollView != null) {
                ScrollView.Dispose ();
                ScrollView = null;
            }

            if (SummaryLabel != null) {
                SummaryLabel.Dispose ();
                SummaryLabel = null;
            }

            if (TemperatureLabel != null) {
                TemperatureLabel.Dispose ();
                TemperatureLabel = null;
            }

            if (WeatherIcon != null) {
                WeatherIcon.Dispose ();
                WeatherIcon = null;
            }
        }
    }
}