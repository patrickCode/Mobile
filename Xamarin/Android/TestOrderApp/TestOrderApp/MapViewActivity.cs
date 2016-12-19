using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps.Model;
using Android.Gms.Maps;

namespace TestOrderApp
{
    [Activity(Label = "MapViewActivity")]
    public class MapViewActivity : Activity
    {
        private FrameLayout _mapFrame;
        private MapFragment _mapFragment;
        private GoogleMap _googleMap;
        private LatLng _location;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _location = new LatLng(17.465572599999998, 78.35026359999999);
            SetContentView(Resource.Layout.MapViewLayout);

            FindViews();
            CreateMapFragement();
            UpdateMapView();
        }

        private void FindViews()
        {
            _mapFrame = FindViewById<FrameLayout>(Resource.Id.googleMapFrameLayout);
        }

        private void CreateMapFragement()
        {
            //Checking if the map already exists (by tag, we will set it later)
            _mapFragment = this.FragmentManager.FindFragmentByTag("map") as MapFragment;

            //Create a new Map Fragment
            if (_mapFragment == null)
            {
                var googleMapOptions = new GoogleMapOptions()   //Google Map Options
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                //All fragment operations happen as a transaction
                var fragmentTransaction = this.FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(googleMapOptions);
                fragmentTransaction.Add(Resource.Id.googleMapFrameLayout, _mapFragment, "map"); //Load the fragment in the frame layout and a tag "map" is getting tagged to it.
                fragmentTransaction.Commit(); //At this point the map won't be visible. It needs to be loaded in the map fragment. UpdateMapView() will load the map.
            }
        }

        private void UpdateMapView()
        {
            var mapReadyCallback = new LocalMapReady();

            //When the callback fires the map ready event we need to set the marker and zoom on the location
            mapReadyCallback.MapReady += (sender, args) =>
            {
                _googleMap = (sender as LocalMapReady).Map;

                if (_googleMap != null)
                {
                    var markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(_location);
                    markerOptions.SetTitle("Comapny Location");
                    _googleMap.AddMarker(markerOptions);

                    var cameraUpdate = CameraUpdateFactory.NewLatLngZoom(_location, 15);
                    _googleMap.MoveCamera(cameraUpdate);
                }
            };

            //Attaching the callback with the map fragment
            _mapFragment.GetMapAsync(mapReadyCallback);
        }

        private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; private set; }
            public event EventHandler MapReady;

            //This method will be fired when the actual google map is ready in the Map fragment and we can get access to the actual google map.
            public void OnMapReady(GoogleMap googleMap)
            {
                //When this method is fired we raise an event and  the actual google map instance is stored in a global object of this class
                Map = googleMap;
                MapReady?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}