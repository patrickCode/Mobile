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

namespace TestOrderApp
{
    [Activity(Label = "OpenMapActivity")]
    public class OpenMapActivity : Activity
    {
        private Button OpenMap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ShowMapView);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            OpenMap = FindViewById<Button>(Resource.Id.openMapButtonView);
        }

        private void HandleEvents()
        {
            OpenMap.Click += OpenMap_Click;
        }

        private void OpenMap_Click(object sender, EventArgs e)
        {
            var locationUri = Android.Net.Uri.Parse("geo:17.465572599999998,78.35026359999999");
            var intent = new Intent(Intent.ActionView, locationUri);
            StartActivity(intent);
        }
    }
}   