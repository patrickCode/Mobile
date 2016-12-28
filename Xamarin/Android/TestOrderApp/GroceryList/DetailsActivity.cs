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
using GroceryList.Repository;

namespace GroceryList
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : Activity
    {
        private ItemRepository _repository;
        TextView nameTextView;
        TextView countTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);
            _repository = new ItemRepository();
            SetContentView(Resource.Layout.DetailsLayout);

            nameTextView = FindViewById<TextView>(Resource.Id.nameTextView);
            countTextView = FindViewById<TextView>(Resource.Id.countTextView);

            int position = Intent.GetIntExtra("ItemPosition", -1);
            var item = _repository.Get()[position];

            nameTextView.Text = item.Name;
            countTextView.Text = item.Count.ToString();
        }
    }
}