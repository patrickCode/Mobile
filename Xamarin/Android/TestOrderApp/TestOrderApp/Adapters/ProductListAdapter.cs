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
using TestOrderApp.Utility;

namespace TestOrderApp.Adapters
{
    public class ProductListAdapter : BaseAdapter<Book>
    {
        private Activity _context;
        private List<Book> _products;
        public ProductListAdapter(Activity context, List<Book> products): base()
        {
            _context = context;
            _products = products;
        }
        public override Book this[int position]
        {
            get
            {
                return _products[position];
            }
        }

        public override int Count
        {
            get
            {
                return _products.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        //This method is called per row that needs to appear on the screen
        //convertView is the new view that is passed from the graveyard (it will be null if no view exists in the graveyard)
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var product = _products[position];

            //Using the SimpleListView style
            /*
            //If no row is found in the graveyard then a new row needs to be instantiated using Inflater
            //Inflate - Generate objects based on XML
            //Inflate a built-in resource in Android
            if (convertView == null)
                convertView = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            //Setting the value of the Convert view to the Product Name (Text1 is a built-in resource that is available in the ListView)
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = product.Name;
            */

            //Using the ActivityListView style
            /*
            //Activity List View comes with a text and icon. The Icon can be pulled from the image path of the product
            if (convertView == null)
                convertView = _context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);

            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = product.Name;
            convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(ImageHelper.GetImageBitmapFromUrl(product.ImagePath));
            */

            //Using Custom Row View
            if (convertView == null)
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.ProductRowView, null);

            convertView.FindViewById<TextView>(Resource.Id.productNameListTextView).Text = product.Name;
            convertView.FindViewById<TextView>(Resource.Id.productPriceListTextView).Text = product.Price.ToString();
            convertView.FindViewById<TextView>(Resource.Id.productAbstractListTextView).Text = product.Abstract;
            convertView.FindViewById<ImageView>(Resource.Id.productIconImageView).SetImageBitmap(ImageHelper.GetImageBitmapFromUrl(product.ImagePath));

            return convertView;
        }
    }
}