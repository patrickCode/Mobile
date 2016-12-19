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
using Order.Core.Models;
using Order.Core.Service;
using TestOrderApp.Adapters;

namespace TestOrderApp
{
    [Activity(Label = "Menu", MainLauncher = false)]
    public class ProductMenuActivity : Activity
    {
        private ListView _productsListView;
        private List<Book> _products;
        private ProductService _productServices;
        public ProductMenuActivity()
        {
            _productServices = new ProductService();
            _products = new List<Book>();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Set the View to this activity
            SetContentView(Resource.Layout.ProductMenuView);

            _productsListView = FindViewById<ListView>(Resource.Id.productListView);
            _products = _productServices.GetAllBooks().ToList();

            _productsListView.Adapter = new ProductListAdapter(this, _products);
            _productsListView.FastScrollEnabled = true;

            _productsListView.ItemClick += _productsListView_ItemClick;
        }

        private void _productsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var product = _products[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(DetailActivity));
            intent.PutExtra("SelectedProductId", product.Id);

            //This allows the 2-way navigation
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            //Checking that the Request Code is 100 so that we can verify that the control has come from Detail activity
            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedProductId = data.GetIntExtra("SelectedProductId", 0);
                var amount = data.GetIntExtra("SelectedProductAmount", 0);
                var selectedProductAmount = _productServices.GetById(selectedProductId);


                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Summary");
                dialog.SetMessage($"You have added {selectedProductAmount.Name} for {amount} times");
                dialog.Show();
            }
        }
    }
}