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

namespace GroceryList
{
    [Activity(Label = "About")]
    public class AboutActivity : Activity
    {
        Button learnMore;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutLayout);

            learnMore = FindViewById<Button>(Resource.Id.learnMoreButton);
            learnMore.Click += LearnMore_Click;
        }

        private void LearnMore_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("https://phoenixadmindev.cloudapp.net"));
            if (intent.ResolveActivity(PackageManager) != null)
            {
                StartActivity(intent);
            }
        }
    }
}