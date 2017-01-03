using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Runtime;
using Chronos.Droid.Fragments;
using Chronos.Droid.Adapters;

namespace Chronos.Droid
{
    [Activity(Label = "Chronos", MainLauncher = true)]
    public class AssignmentActivity : Android.Support.V4.App.FragmentActivity
    {
        private ViewPager DaysViewPager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AssignmentsLayout);

            DaysViewPager = FindViewById<ViewPager>(Resource.Id.daysViewPager);
            CreatePager(DateTime.Now);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 100)
            {
                if (resultCode == Result.Ok)
                {
                    var dialog = new AlertDialog.Builder(this);
                    dialog.SetMessage("Labour Entry Updated");
                    var entryDate = DateTime.Parse(data.GetStringExtra("EntryDate"));
                    CreatePager(entryDate);
                }
            }
        }

        private void CreatePager(DateTime activeDate)
        {
            var fragments = CreateDayFragments();
            var titles = GetDayTitles();

            var weekAdapter = new ViewAssignmentTabAdapter(base.SupportFragmentManager, fragments, titles);
            DaysViewPager.Adapter = weekAdapter;
            DaysViewPager.SetCurrentItem((int)activeDate.DayOfWeek, true);
        }

        private List<DateTime> GetWeek()
        {
            var today = DateTime.Today;
            var currentDayWeek = (int)today.DayOfWeek;
            var sunday = today.AddDays(-currentDayWeek);
            var saturday = sunday.AddDays(6);

            var week = Enumerable.Range(0, 7)
                .Select(day => sunday.AddDays(day))
                .ToList();
            return week;
        }

        private Java.Lang.ICharSequence[] GetDayTitles()
        {
            var weekDateTime = GetWeek();
            var titles = weekDateTime.Select(date => date.ToString("D")).ToList();
            titles[(int)DateTime.Today.DayOfWeek] = "Today";
            return CharSequence.ArrayFromStringArray(titles.ToArray());
        }

        private ViewAssignmentsFragment[] CreateDayFragments()
        {
            var week = GetWeek();
            var fragments = new List<ViewAssignmentsFragment>();
            foreach(var day in week)
            {
                var fragment = new ViewAssignmentsFragment(this, day);
                fragments.Add(fragment);
            }
            return fragments.ToArray();
        }
    }
}