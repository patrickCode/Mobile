using Android.App;
using Android.OS;
using ClockTab.Fragments;
using Android.Runtime;
using Android.Support.V4.View;

namespace ClockTab
{
    [Activity(Label = "ClockTab", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Android.Support.V4.App.FragmentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            var fragments = new Android.Support.V4.App.Fragment[]
            {
                new TimeFragment(),
                new StopwatchFragment(),
                new AboutFragment()
            };

            var titles = CharSequence.ArrayFromStringArray(new[]
            {
                "Time",
                "Stopwatch",
                "About"
            });

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

            var adapter = new ClockAdapter(base.SupportFragmentManager, fragments, titles);
            viewPager.Adapter = adapter;
        }
    }
}