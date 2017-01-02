using Android.App;
using Android.Widget;
using Android.OS;
using MultiLevelList.Repository;

namespace MultiLevelList
{
    [Activity(Label = "MultiLevelList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ProjectRepository _repository;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            _repository = new ProjectRepository();

            var listView = FindViewById<ExpandableListView>(Resource.Id.expandableListView1);
            var adapter = new MultiLevelAdapter(this, _repository.Get());
            listView.SetAdapter(adapter);
        }
    }
}

