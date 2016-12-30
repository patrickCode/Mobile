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
    [Activity(Label = "StopwatchActivity")]
    public class StopwatchActivity : Activity
    {
        private Timer timer;
        private Button startStopButton;
        private Button resetButton;
        private TextView timerText;
        private bool timerStarted = false;
        private TimeSpan ticks;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StopwatchLayout);

            timerText = FindViewById<TextView>(Resource.Id.timerTextView);
            startStopButton = FindViewById<Button>(Resource.Id.startStopButton);
            resetButton = FindViewById<Button>(Resource.Id.resetButton);

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            startStopButton.Click += StartStopButton_Click;
            resetButton.Click += ResetButton_Click;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ticks = ticks.Add(TimeSpan.FromSeconds(1));
            RunOnUiThread(() => timerText.Text = ticks.ToString("g"));
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
            if(!timerStarted)
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