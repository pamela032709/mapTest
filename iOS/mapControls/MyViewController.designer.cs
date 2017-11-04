// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyLittleTest.iOS.mapControls
{
    [Register ("MyViewController")]
    partial class MyViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnRemovePoints { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem hybridButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar mysearchBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem satelliteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem standardButton { get; set; }

        [Action ("BtnRemovePoints_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnRemovePoints_Activated (UIKit.UIBarButtonItem sender);

        [Action ("SatelliteButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SatelliteButton_Activated (UIKit.UIBarButtonItem sender);

        [Action ("StandardButton_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StandardButton_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnRemovePoints != null) {
                btnRemovePoints.Dispose ();
                btnRemovePoints = null;
            }

            if (hybridButton != null) {
                hybridButton.Dispose ();
                hybridButton = null;
            }

            if (map != null) {
                map.Dispose ();
                map = null;
            }

            if (mysearchBar != null) {
                mysearchBar.Dispose ();
                mysearchBar = null;
            }

            if (satelliteButton != null) {
                satelliteButton.Dispose ();
                satelliteButton = null;
            }

            if (standardButton != null) {
                standardButton.Dispose ();
                standardButton = null;
            }
        }
    }
}