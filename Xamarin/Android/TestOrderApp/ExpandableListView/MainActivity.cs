using Android.App;
using Android.Widget;
using Android.OS;

namespace LevelListView
{
    [Activity(Label = "ExpandableListView", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var view = FindViewById<ExpandableListView>(123);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
        }
    }
}

