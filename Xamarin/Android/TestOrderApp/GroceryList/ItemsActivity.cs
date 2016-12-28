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
using GroceryList.Model;
using GroceryList.Repository;

namespace GroceryList
{
    [Activity(Label = "Items")]
    public class ItemsActivity : Activity
    {
        private ItemRepository _repository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            _repository = new ItemRepository();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemsLayout);

            var lv = FindViewById<ListView>(Resource.Id.listView);
            lv.Adapter = new ArrayAdapter<Item>(this, Android.Resource.Layout.SimpleListItem1, Android.Resource.Id.Text1, _repository.Get());
            lv.ItemClick += Lv_ItemClick;
        }

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var position = e.Position;
            var intent = new Intent(this, typeof(DetailsActivity));

            intent.PutExtra("ItemPosition", position);

            StartActivity(intent);
        }
    }
}