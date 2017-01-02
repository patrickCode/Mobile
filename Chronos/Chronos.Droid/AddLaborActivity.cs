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
using Chronos.Core.Interfaces;
using Chronos.Core.Repository;

namespace Chronos.Droid
{
    [Activity(Label = "Chronos", MainLauncher = true)]
    public class AddLaborActivity : Activity
    {
        private SeekBar HourSeekbar;
        private SeekBar MinuteSeekbar;
        private EditText EntryTime;
        private Spinner TimezoneSpinner;
        private Spinner LabourCategorySpinner;
        
        private EditText NotesEditText;
        private Button SubmitButton;
        private Button CancelButton;

        private ILaborCategoryRepository _labourCategoryRepository;
        private bool _timeTextChanged = false;

        public AddLaborActivity()
        {
            _labourCategoryRepository = new InMemoryLaborCategoryRepository();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddLabourLayout);

            FindViews();
            AddTimeZones();
            AddLabourCategories();
            SetupTimeEntryView();

            CancelButton.Click += LabourEntryCancelled;
        }

        private void LabourEntryCancelled(object sender, EventArgs e)
        {
            NotesEditText.Text = "";
        }

        private void FindViews()
        {
            HourSeekbar = FindViewById<SeekBar>(Resource.Id.laborEntryHourSeekBar);
            MinuteSeekbar = FindViewById<SeekBar>(Resource.Id.laborEntryMinuteSeekBar);
            EntryTime = FindViewById<EditText>(Resource.Id.labourEntryTimeEdit);
            TimezoneSpinner = FindViewById<Spinner>(Resource.Id.labourEntryTimezoneSpinner);
            LabourCategorySpinner = FindViewById<Spinner>(Resource.Id.labourEntryCategorySpinner);
            NotesEditText = FindViewById<EditText>(Resource.Id.labourEntryNotesEditText);
            SubmitButton = FindViewById<Button>(Resource.Id.laboutEntrySubmitButton);
            CancelButton = FindViewById<Button>(Resource.Id.laboutEntryCancelButton);
        }

        private void SetupTimeEntryView()
        {
            HourSeekbar.Max = 16;
            MinuteSeekbar.Max = 59;

            HourSeekbar.ProgressChanged += UpdateTimeFromSeekBar;
            MinuteSeekbar.ProgressChanged += UpdateTimeFromSeekBar;

            EntryTime.TextChanged += UpdateSeekBarFromText;
        }

        private void UpdateSeekBarFromText(object sender, Android.Text.TextChangedEventArgs e)
        {
            _timeTextChanged = true;
            var timeText = EntryTime.Text;
            int hourValue = 0;
            int minValue = 0;
            if (timeText.Contains(":"))
            {
                var hourTxt = timeText.Substring(0, timeText.IndexOf(":"));
                var minText = timeText.Substring(timeText.IndexOf(":") + 1);
                int.TryParse(hourTxt, out hourValue);
                int.TryParse(minText, out minValue);
            }
            else
            {
                var hourTxt = timeText;
                int.TryParse(hourTxt, out hourValue);
            }
            HourSeekbar.Progress = hourValue;
            MinuteSeekbar.Progress = minValue;
        }

        private void UpdateTimeFromSeekBar(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            var hour = HourSeekbar.Progress;
            var min = MinuteSeekbar.Progress;
            if (!_timeTextChanged)
            {
                var timeText = $"{hour}:{min}";
                EntryTime.Text = timeText;
            }
            _timeTextChanged = false;
        }

        private void AddTimeZones()
        {
            var timezones = TimeZoneInfo.GetSystemTimeZones();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, timezones.Select(tz => tz.DisplayName).ToArray());
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            TimezoneSpinner.Adapter = adapter;
        }

        private void AddLabourCategories()
        {
            var labourCategories = _labourCategoryRepository.Get();
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, labourCategories.Select(category => category.Name).ToArray());
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            LabourCategorySpinner.Adapter = adapter;
        }
    }
}