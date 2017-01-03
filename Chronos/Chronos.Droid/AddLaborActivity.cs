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
using Chronos.Core.Model;

namespace Chronos.Droid
{
    [Activity(Label = "Chronos", MainLauncher = false)]
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
        private List<LaborCategory> _categories;
        private bool _timeTextChanged = false;
        private IAssignmentRepository _assignmentRepository;
        private Assignment _selectedAssignment;
        private DateTime _entryDate;

        public AddLaborActivity()
        {
            _labourCategoryRepository = new InMemoryLaborCategoryRepository();
            _assignmentRepository = new InMemoryAssignmentRepository();
            _categories = _labourCategoryRepository.Get();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddLabourLayout);

            var selectedAssignentId = Intent.GetIntExtra("SelectedAssignmentId", -1);
            _entryDate = DateTime.Parse(Intent.GetStringExtra("EntryDate"));
            _selectedAssignment = _assignmentRepository.GetAssignment("", selectedAssignentId, _entryDate);

            FindViews();
            AddTimeZones();
            AddLabourCategories();
            SetupTimeEntryView();
            AddInitialValues();

            SubmitButton.Click += LaboutEntrySubmitted;
            CancelButton.Click += LabourEntryCancelled;
        }

        private void LaboutEntrySubmitted(object sender, EventArgs e)
        {
            var updatedTimeEntry = TimeSpan.FromHours(HourSeekbar.Progress);
            updatedTimeEntry = updatedTimeEntry.Add(TimeSpan.FromMinutes(MinuteSeekbar.Progress));

            _selectedAssignment.EntryTime = updatedTimeEntry;

            var selectedCategory = _categories[LabourCategorySpinner.SelectedItemPosition];
            _selectedAssignment.Category = selectedCategory.Name;

            var timezones = TimeZoneInfo.GetSystemTimeZones();
            var selectedTimezone = timezones[TimezoneSpinner.SelectedItemPosition];
            _selectedAssignment.Timezone = selectedTimezone;

            _selectedAssignment.Notes = NotesEditText.Text;

            string failureReason;
            var updated = _assignmentRepository.UpdateAssignment("", _selectedAssignment, _entryDate, out failureReason);

            if (updated)
            {
                var intent = new Intent();
                intent.PutExtra("EntryDate", _entryDate.ToString());
                SetResult(Result.Ok, intent);
                Finish();
            }
            else
            {
                string message;
                
                if (failureReason.Equals("TIME_EXCEEDED"))
                {
                    message = "You have exceeded 16 hours for the day.";
                }
                else
                {
                    message = $"Some error ocerred while submitting the labour request. Error Code - {failureReason}. Please try again later.";
                }
                var dialog = new AlertDialog.Builder(this);
                dialog.SetMessage(message);
                dialog.Show();
            }
        }

        private void LabourEntryCancelled(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.PutExtra("EntryDate", _entryDate.ToString());
            SetResult(Result.Canceled, intent);
            Finish();
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


        private void AddInitialValues()
        {
            HourSeekbar.Progress = _selectedAssignment.EntryTime.Hours;
            MinuteSeekbar.Progress = _selectedAssignment.EntryTime.Minutes;

            var selectedTimezonePosition = 0;
            if (_selectedAssignment.Timezone != null)
            {
                var timezones = TimeZoneInfo.GetSystemTimeZones();
                selectedTimezonePosition = timezones.IndexOf(_selectedAssignment.Timezone);
            }
            TimezoneSpinner.SetSelection(selectedTimezonePosition);

            var selectedCategoryPosition = 0;
            if (!string.IsNullOrEmpty(_selectedAssignment.Category))
            {
                var requiredCategory = _categories.FirstOrDefault(category => category.Name.Equals(_selectedAssignment.Category));
                selectedCategoryPosition = _categories.IndexOf(requiredCategory);
            }
            LabourCategorySpinner.SetSelection(selectedCategoryPosition);

            NotesEditText.Text = _selectedAssignment.Notes;
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
            var labourCategories = _categories;
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, labourCategories.Select(category => category.Name).ToArray());
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            LabourCategorySpinner.Adapter = adapter;
        }
    }
}