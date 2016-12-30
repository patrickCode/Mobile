using Android.App;
using Android.Widget;
using Android.OS;
using ClockDrawer.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;

namespace ClockDrawer
{
    [Activity(Label = "ClockDrawer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        DrawerLayout drawerLayout;
        ActionBarDrawerToggle drawerToggle;
        ListView drawerListView;

        Fragment[] fragments;
        string[] titles;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            fragments = new Fragment[] { new TimeFragment(), new StopwatchFragment(), new AlarmFragment(), new AboutFragment() };
            titles = new string[] { "Time", "Stopwatch", "Alarm", "About" };

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);

            drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, Resource.String.DrawerOpenDescription, Resource.String.DrawerCloseDescription);
            drawerLayout.SetDrawerListener(drawerToggle);

            ActionBar.SetDisplayHomeAsUpEnabled(true);  //To show the navigation bar in menu

            drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ListViewMenuRow, Resource.Id.menuRowTextView, titles);
            drawerListView.ItemClick += DrawerListView_ItemClick;
            drawerListView.SetItemChecked(0, true); //Highlight the first item as startup
        }

        private void DrawerListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var position = e.Position;

            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.frameLayout, fragments[position])
                .Commit();

            Title = titles[position];
            drawerLayout.CloseDrawer(drawerListView);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (drawerToggle.OnOptionsItemSelected(item)) //If the navigation button has been touched.
                return true;

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            drawerToggle.SyncState();
            base.OnPostCreate(savedInstanceState);
        }
    }
}

