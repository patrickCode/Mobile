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
using Order.Core.Service;
using Order.Core.Models;
using TestOrderApp.Utility;

namespace TestOrderApp
{
    [Activity(Label = "Product Detail", MainLauncher = false)]
    public class DetailActivity : Activity
    {
        private ImageView _productImageView;
        private TextView _productNameView;
        private TextView _productDescriptionView;
        private TextView _productPriceTextView;
        private EditText _productAmountEditView;
        private Button _cancelButton;
        private Button _orderButton;

        private ProductService _productService;
        private Book _product;

        public DetailActivity()
        {
            _productService = new ProductService();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ProductDetailView);


            var selectedProductId = Intent.Extras.GetInt("SelectedProductId");
            _product = _productService.GetById(selectedProductId);

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            _productImageView = FindViewById<ImageView>(Resource.Id.productImage);
            _productNameView = FindViewById<TextView>(Resource.Id.productNameTextView);
            _productDescriptionView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            _productPriceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            _cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            _productAmountEditView = FindViewById<EditText>(Resource.Id.amountEditText);
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {
            _productNameView.Text = _product.Name;
            _productDescriptionView.Text = _product.Description;
            _productPriceTextView.Text = _product.Price.ToString();

            var imageBitMap = ImageHelper.GetImageBitmapFromUrl(_product.ImagePath);
            _productImageView.SetImageBitmap(imageBitMap);
        }

        private void HandleEvents()
        {
            _orderButton.Click += _orderButton_Click;
            _cancelButton.Click += _cancelButton_Click;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void _orderButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(_productAmountEditView.Text);

            //Creating a new Prompt
            //var dialog = new AlertDialog.Builder(this);
            //dialog.SetTitle("Confirmation");
            //dialog.SetMessage("The product has been added to the cart");
            //dialog.Show();

            var intent = new Intent();
            intent.PutExtra("SelectedProductId", _product.Id);
            intent.PutExtra("SelectedProductAmount", amount);

            //Trigger the OnActivityResult() with the code and intent
            //The method will be triggered in the calling activity which in our case is the Menu Activity
            //The request code which was sent by the calling actvity (100 in our case) will also be passed to the calling activity (menu activity)
            SetResult(Result.Ok, intent);

            //This will detroy the activity and pop it from the Stack
            Finish();
        }
    }
}