using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using GroceryList.Repository;

namespace GroceryList
{
    [Activity(Label = "Grocery List", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button itemsButton;
        Button addItemButton;
        Button aboutButton;

        private ItemRepository _repository;
        protected override void OnCreate(Bundle bundle)
        {
            _repository = new ItemRepository();
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            itemsButton = FindViewById<Button>(Resource.Id.itemsButton);
            addItemButton = FindViewById<Button>(Resource.Id.addItemButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);

            itemsButton.Click += ItemsButton_Click;
            addItemButton.Click += AddItemButton_Click;
            aboutButton.Click += AboutButton_Click;
        }
        private void ItemsButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(ItemsActivity));
            StartActivity(intent);
        }

        private void AddItemButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(AddItemsActivity));
            StartActivityForResult(intent, 100);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 100 && resultCode == Result.Ok)
            {
                var itemName = data.Extras.GetString("ItemName");
                var count = data.Extras.GetLong("Count");

                _repository.Add(itemName, count);
            }
        }

        private void AboutButton_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(AboutActivity));
        }
    }
}