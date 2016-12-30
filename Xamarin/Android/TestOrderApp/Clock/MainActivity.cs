using Android.OS;
using Android.App;
using Android.Widget;
using Android.Content;

namespace Clock
{
    [Activity(Label = "Clock", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var menuList = FindViewById<ListView>(Resource.Id.listView);
            string[] arr = new string[] { };
            menuList.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, new string[] { "Time", "Stopwatch", "About" });

            menuList.ItemClick += MenuList_ItemClick;
        }

        private void MenuList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent;
            switch (e.Position)
            {   
                case 0:
                    intent = new Intent(this, typeof(TimeActivity));
                    StartActivity(intent);
                    break;
                case 1:
                    intent = new Intent(this, typeof(StopwatchActivity));
                    StartActivity(intent);
                    break;
                case 2:
                    intent = new Intent(this, typeof(AboutActivity));
                    StartActivity(intent);
                    break;
            }
        }
    }
}