using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Timers;

namespace ClockDrawer.Fragments
{
    public class TimeFragment: Fragment
    {
        private Timer timer;
        private TextView timeTextView;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.TimeLayout, container, false);
            timeTextView = view.FindViewById<TextView>(Resource.Id.timeTextView);

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            return view;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            base.Activity.RunOnUiThread(() => timeTextView.Text = DateTime.Now.ToString("T"));
        }
    }
}