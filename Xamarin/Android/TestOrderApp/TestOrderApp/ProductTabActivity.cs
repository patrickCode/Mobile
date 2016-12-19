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
using TestOrderApp.Fragments;
using Order.Core.Service;

namespace TestOrderApp
{
    //Replacement of Product menu activity
    [Activity(Label = "Products", MainLauncher = false)]
    public class ProductTabActivity : Activity
    {
        private ProductService _productServices;
        public ProductTabActivity()
        {
            _productServices = new ProductService();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ProductTabbedView);

            //Set the action type to be tabbed
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Favorites", Resource.Drawable.fav, new FavBookFragment());
            AddTab("Science", Resource.Drawable.science, new ScienceFragment());
            AddTab("Mystery", Resource.Drawable.mystery, new MysteryFragment());
            AddTab("Fantasy", Resource.Drawable.fantasy, new FantasyFragment());
        }
         
        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            //Add the fragment when the tab is selected
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                //Gets the container of the fragment (i.e. it checks the Frame layout if there is a fragment inside)
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentLayout);
                //If a fragment exists then remove that add the passed in fragment
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);
                e.FragmentTransaction.Add(Resource.Id.fragmentLayout, view);
            };

            //Remove the fragment when the tab is unselected
            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
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