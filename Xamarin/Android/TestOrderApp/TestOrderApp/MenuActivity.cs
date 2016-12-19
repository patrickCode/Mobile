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
    [Activity(Label = "My Products", MainLauncher = true)]
    public class MenuActivity : Activity
    {   
        private Button _cartButton;
        private Button _storeButton;
        private Button _mapButton;
        private Button _aboutButton;
        private Button _picButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            FindViews();
            HandleEvents();
        }
        private void FindViews()
        {
            _cartButton = FindViewById<Button>(Resource.Id.viewCartMainMenuButton);
            _storeButton = FindViewById<Button>(Resource.Id.goToStoreMainMenuButton);
            _mapButton = FindViewById<Button>(Resource.Id.seeMapMainMenuButton);
            _aboutButton = FindViewById<Button>(Resource.Id.aboutMainMenuButton);
            _picButton = FindViewById<Button>(Resource.Id.takePicMainMenuButton);
        }

        private void HandleEvents()
        {
            _storeButton.Click += _storeButton_Click;
            _aboutButton.Click += _aboutButton_Click;
            _picButton.Click += _picButton_Click;
            _mapButton.Click += _mapButton_Click;
        }

        private void _mapButton_Click(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(OpenMapActivity));
            var intent = new Intent(this, typeof(MapViewActivity));
            StartActivity(intent);
        }

        private void _picButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePicActivity));
            StartActivity(intent);
        }

        private void _aboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutUsActivity));
            StartActivity(intent);
        }

        private void _storeButton_Click(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(ProductMenuActivity));
            var intent = new Intent(this, typeof(ProductTabActivity));
            StartActivity(intent);
        }
    }
}