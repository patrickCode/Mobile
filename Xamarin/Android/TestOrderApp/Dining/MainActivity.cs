using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Dining.Repository;
using System.Collections.Generic;
using Dining.Model;

namespace Dining
{
    [Activity(Label = "Dining", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        RecyclerView recyclerView;
        private RestaurantRepository _repository;
        private List<Restaurant> _restaurants;
        protected override void OnCreate(Bundle bundle)
        {
            _repository = new RestaurantRepository();
            _restaurants = _repository.GetRestaurants();
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));
            var adapter = new RestaurantAdapter(_restaurants);
            adapter.ItemClick += Adapter_ItemClick; //This is a custom event
            recyclerView.SetAdapter(adapter);
        }

        private void Adapter_ItemClick(object sender, int e)
        {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(_restaurants[e].Name);
            dialog.Show();
        }
    }
}

