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
using Clock;

namespace ClockDrawer.Fragments
{
    public class AlarmFragment : Fragment
    {
        TextView timeTextView;
        AlarmTimePicker alarmTimePicker;
        Button startResetButton;

        TimeSpan ticks;
        Timer timer;
        bool alarmStarted = false;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.AlarmLayout, container, false);

            timeTextView = view.FindViewById<TextView>(Resource.Id.timeTextView);
            alarmTimePicker = view.FindViewById<AlarmTimePicker>(Resource.Id.alarmTimePicker);
            startResetButton = view.FindViewById<Button>(Resource.Id.startResetButton);

            startResetButton.Click += StartResetButton_Click;

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;

            return view;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ticks = ticks.Subtract(TimeSpan.FromSeconds(1));
            UpdateUITicks();

            if (ticks <= TimeSpan.Zero)
            {
                ShowAlert();
                Reset();
            }
        }

        private void ShowAlert()
        {
            Activity.RunOnUiThread(() =>
            {
                var dialog = new AlertDialog.Builder(Activity);
                dialog.SetMessage("Time Elapsed");
                dialog.SetNeutralButton("OK", delegate { });
                dialog.Show();
            });
        }

        private void StartResetButton_Click(object sender, EventArgs e)
        {
            if (!alarmStarted)
            {
                startResetButton.Text = "Reset";
                ticks = alarmTimePicker.Value;
                alarmTimePicker.Enabled = false;
                timer.Start();
            }
            else
            {
                Reset();
            }
            alarmStarted = !alarmStarted;
        }

        private void UpdateUITicks()
        {
            Activity.RunOnUiThread(() =>
            {
                timeTextView.Text = ticks.ToString("g");
            });
        }

        private void Reset()
        {
            timer.Stop();
            ticks = TimeSpan.Zero;

            Activity.RunOnUiThread(() =>
            {
                alarmTimePicker.SetToZero();
                alarmTimePicker.Enabled = true;
                UpdateUITicks();
                startResetButton.Text = "Start";
            });
        }
    }
}