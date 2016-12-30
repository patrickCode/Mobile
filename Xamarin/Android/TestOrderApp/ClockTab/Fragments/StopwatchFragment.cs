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

namespace ClockTab.Fragments
{
    public class StopwatchFragment : Android.Support.V4.App.Fragment
    {
        private Timer timer;
        private Button startStopButton;
        private Button resetButton;
        private TextView timerText;
        private bool timerStarted = false;
        private TimeSpan ticks;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.StopwatchLayout, container, false);

            timerText = view.FindViewById<TextView>(Resource.Id.timerTextView);
            startStopButton = view.FindViewById<Button>(Resource.Id.startStopButton);
            resetButton = view.FindViewById<Button>(Resource.Id.resetButton);

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            startStopButton.Click += StartStopButton_Click;
            resetButton.Click += ResetButton_Click;

            return view;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ticks = ticks.Add(TimeSpan.FromSeconds(1));
            Activity.RunOnUiThread(() => timerText.Text = ticks.ToString("g"));
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timerText.Text = "0:00:00";
            startStopButton.Text = "Start";
            ticks = TimeSpan.Zero;
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!timerStarted)
            {
                timer.Start();
                startStopButton.Text = "Stop";
            }
            else
            {
                timer.Stop();
                startStopButton.Text = "Start";
            }
            timerStarted = !timerStarted;
        }
    }
}