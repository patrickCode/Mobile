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
    [Activity(Label = "AboutUsActivity")]
    public class AboutUsActivity : Activity
    {
        private TextView _supportPhoneView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutView);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            _supportPhoneView = FindViewById<TextView>(Resource.Id.supportPhoneTextView);
        }

        private void HandleEvents()
        {
            _supportPhoneView.Click += _supportPhoneView_Click;
        }

        private void _supportPhoneView_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:+919515122857"));
            StartActivity(intent);
        }
    }
}