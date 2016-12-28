using Android.App;
using Android.Widget;
using Android.OS;
using Contacts.Repository;
using System.Collections.Generic;
using Contacts.Model;

namespace Contacts
{
    [Activity(Label = "Contacts", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ContactRepository _repository;
        private List<Contact> _contacts;
        protected override void OnCreate(Bundle bundle)
        {
            _repository = new ContactRepository();
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            _contacts = _repository.Get();
            var adapter = new ContactAdapter(this, _contacts);

            var listView = FindViewById<ListView>(Resource.Id.contactListView);
            listView.Adapter = adapter;
            listView.ItemClick += ListView_ItemClick;
            listView.FastScrollEnabled = true;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var position = e.Position;
            var contact = _contacts[position];

            var alert = new AlertDialog.Builder(this);
            alert.SetMessage(contact.Name + "\n" + contact.Biography);
            alert.Show();
        }
    }
}

