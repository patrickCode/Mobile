using Android.App;
using Android.OS;
using Android.Widget;
using Contacts.Repository;
using Contacts.Model;
using System.Collections.Generic;

namespace Contacts
{
    [Activity(Label = "Instructors (Array)", MainLauncher = false, Icon = "@drawable/icon")]
    public class ListViewActivity : Activity
    {
        private ContactRepository _repository;
        private List<Contact> _contacts;
             
        protected override void OnCreate(Bundle savedInstanceState)
        {
            _repository = new ContactRepository();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ArrayViewLayout);

            var listView = FindViewById<ListView>(Resource.Id.arrayListView);
            _contacts = _repository.Get();
            var arrayAdapter = new ArrayAdapter<Contact>(this, Android.Resource.Layout.SimpleListItem1, _contacts);

            listView.Adapter = arrayAdapter;

            listView.ItemClick += ListView_ItemClick;
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