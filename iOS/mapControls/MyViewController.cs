using System;
using CoreGraphics;
using CoreLocation;
using Foundation;
using MapKit;
using MyLittleTest;
using MyLittleTest.iOS.mapControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(MyLittleTestPage), typeof(MyViewController))]
namespace MyLittleTest.iOS.mapControls
{
    public partial class MyViewController : PageRenderer
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        Position position { get; set; }



        CLLocationManager locMan = new CLLocationManager();

        CLLocationCoordinate2D UserLocation = new CLLocationCoordinate2D(48.857, 2.351);

       
        public void GetCurrentLocation()
        {
            
            latitude = locMan.Location.Coordinate.Latitude.ToString();
            longitude = locMan.Location.Coordinate.Longitude.ToString();
        }

        partial void BtnRemovePoints_Activated(UIBarButtonItem sender)
        {
            map.RemoveAnnotations(map.Annotations);

            //btnAddPoints.Enabled = true;
            btnRemovePoints.Enabled = false;
        }




        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            locMan.RequestWhenInUseAuthorization();
            map.ShowsUserLocation = true;
            map.UserTrackingMode = MKUserTrackingMode.Follow;
            map.Camera.CenterCoordinate = UserLocation;
            map.Camera.Pitch = 45;

            Title = "User Location";

            AddAnnotation(UserLocation,"this is a hardcore location","add addresses in here");

            map.GetViewForAnnotation = (mapView, annotation) => {
                var pinView = new MKMarkerAnnotationView(annotation, "pin");
                pinView.MarkerTintColor = UIColor.Purple;
                pinView.Draggable = true;
                return pinView;
            };


        }

        void AddAnnotation(CLLocationCoordinate2D userLocation ,string title, string subtitle)
        {
            var pinAnnotation = new MKPointAnnotation
            {
                Title = "title",
                Subtitle = "subtitle",
                Coordinate = userLocation
            };
            map.AddAnnotation(pinAnnotation);
        }

        //public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        //{
        //    var pinView = new MKAnnotationView(annotation, "pin");

        //    pinView.Image = UIImage.FromBundle("banana_pin.png");

        //    return pinView;
        //}
  

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }



        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);


            var alertController = UIAlertController.Create(
          "Title Goes Here",
          "Message Goes Here",
          UIAlertControllerStyle.Alert);

            // Add YES and NO buttons
            alertController.AddAction(UIAlertAction.Create(
                "Yes", UIAlertActionStyle.Default,
                alert => {
        /* Code to execute when YES is clicked */
                }));

            alertController.AddAction(UIAlertAction.Create(
                "No", UIAlertActionStyle.Cancel, null));

            // Show the alert    
            this.PresentViewController(alertController, true, null);

            if (CLLocationManager.Status == CLAuthorizationStatus.Denied)
            {
                var yesNoAlertController = UIAlertController.Create(
                    "Unable to determine location",
                    "This application works best when it can determine your current " +
                    "position.  Would you like to go to Settings to enable location data?",
                    UIAlertControllerStyle.Alert);

                yesNoAlertController.AddAction(UIAlertAction.Create(
                    "Yes", UIAlertActionStyle.Default,
                    alert => {
                        var settingsString = UIApplication.OpenSettingsUrlString;
                        var url = new NSUrl(settingsString);
                        UIApplication.SharedApplication.OpenUrl(url);
                    }));

                yesNoAlertController.AddAction(UIAlertAction.Create(
                    "No", UIAlertActionStyle.Cancel, null));
                this.PresentViewController(yesNoAlertController, true, null);

            }
        }
        //botones
        partial void SatelliteButton_Activated(UIBarButtonItem sender)
        {
            map.MapType = MapKit.MKMapType.Satellite;
        }

        partial void StandardButton_Activated(UIBarButtonItem sender)
        {
            map.MapType = MapKit.MKMapType.Standard;
        }

    }
}

