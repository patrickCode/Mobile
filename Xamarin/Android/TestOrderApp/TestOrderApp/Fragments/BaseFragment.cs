using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Order.Core.Service;
using Order.Core.Models;

namespace TestOrderApp.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected ProductService _productsService;
        protected List<Product> _products;

        public BaseFragment()
        {
            _productsService = new ProductService();
            _products = new List<Product>();
        }

        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.productListView);
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var product = _products[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(DetailActivity));
            intent.PutExtra("SelectedProductId", product.Id);

            //This allows the 2-way navigation
            StartActivityForResult(intent, 100);
        }


        //Will be called when a called activity finishes and control comes back
        public override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            //Checking that the Request Code is 100 so that we can verify that the control has come from Detail activity
            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedProductId = data.GetIntExtra("SelectedProductId", 0);
                var amount = data.GetIntExtra("SelectedProductAmount", 0);
                var selectedProductAmount = _productsService.GetById(selectedProductId);


                var dialog = new AlertDialog.Builder(this.Activity);
                dialog.SetTitle("Summary");
                dialog.SetMessage($"You have added {selectedProductAmount.Name} for {amount} times");
                dialog.Show();
            }
        }
    }
}