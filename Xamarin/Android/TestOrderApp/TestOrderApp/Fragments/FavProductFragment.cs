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
using TestOrderApp.Adapters;

namespace TestOrderApp.Fragments
{
    public class FavProductFragment : BaseFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        //This method will be called when the host activity which calls this fragment is ready
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();
            HandleEvents();

            _products = _productsService.GetFavoriteProducts().ToList();
            listView.Adapter = new ProductListAdapter(this.Activity, _products);
            listView.FastScrollEnabled = true;
        }

        //Creates the View from the fragment
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.FavProductsFragment, container, false);
        }
    }
}