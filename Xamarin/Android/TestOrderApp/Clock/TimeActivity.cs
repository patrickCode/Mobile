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
using System.Timers;

namespace Clock
{
    [Activity(Label = "TimeActivity", MainLauncher = false)]
    public class TimeActivity : Activity
    {
        private Timer timer;
        private TextView timeTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TimeLayout);
            timeTextView = FindViewById<TextView>(Resource.Id.timeTextView);

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() => timeTextView.Text = DateTime.Now.ToString("T"));
        }
    }
}