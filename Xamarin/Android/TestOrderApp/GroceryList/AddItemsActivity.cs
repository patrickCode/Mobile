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

namespace GroceryList
{
    [Activity(Label = "Add Items")]
    public class AddItemsActivity : Activity
    {
        Button saveButton;
        Button cancelButton;

        EditText itemNameEditView;
        EditText countEditView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddItemLayout);

            itemNameEditView = FindViewById<EditText>(Resource.Id.nameInput);
            countEditView = FindViewById<EditText>(Resource.Id.countInput);

            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            saveButton.Click += SaveButton_Click;

            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            cancelButton.Click += CancelButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var itemName = itemNameEditView.Text;
            var count = countEditView.Text;

            var intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("ItemName", itemName);
            intent.PutExtra("Count", long.Parse(count));

            SetResult(Result.Ok, intent);
            Finish();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}