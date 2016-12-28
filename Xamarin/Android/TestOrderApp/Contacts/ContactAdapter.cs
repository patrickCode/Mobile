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
using Contacts.Model;
using Android.Graphics.Drawables;
using Java.Lang;

namespace Contacts
{
    public class ContactAdapter : BaseAdapter<Contact>, ISectionIndexer
    {
        Java.Lang.Object[] sectionHeaders;
        Dictionary<int, int> positionForSectionMap;
        Dictionary<int, int> sectionForPositionMap;

        private Activity _context;
        private List<Contact> _contacts;
        public ContactAdapter(Activity context, List<Contact> contacts)
        {
            _context = context;
            _contacts = contacts;
            sectionHeaders = SectionIndexBuilder.BuildSectionHeader(_contacts);
            positionForSectionMap = SectionIndexBuilder.BuildPositionForSectionMap(_contacts);
            sectionForPositionMap = SectionIndexBuilder.BuildSectionForPositionMap(_contacts);
        }
        public override Contact this[int position]
        {
            get
            {
                return _contacts[position];
            }
        }

        public override int Count
        {
            get
            {
                return _contacts.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView;
            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.ContactRowLayout, parent, false);

                var photoView = view.FindViewById<ImageView>(Resource.Id.contactImageView);
                var nameView = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var specialityView = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

                var vh = new ViewHolder()
                {
                    Image = photoView,
                    Name = nameView,
                    Speciality = specialityView
                };
                view.Tag = vh;
            }

            var holder = (ViewHolder)view.Tag;

            //Performance not optimized
            //var stream = _context.Assets.Open(_contacts[position].ImageUrl);
            //var drawable = Drawable.CreateFromStream(stream, null);
            //photoView.SetImageDrawable(drawable);
            //photoView.SetImageDrawable(ImageAssetManager.Get(_context, _contacts[position].ImageUrl));
            //nameView.Text = _contacts[position].Name;
            //specialityView.Text = _contacts[position].Specialty;

            holder.Image.SetImageDrawable(ImageAssetManager.Get(_context, _contacts[position].ImageUrl));
            holder.Name.Text = _contacts[position].Name;
            holder.Speciality.Text = _contacts[position].Specialty;


            return view;
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return positionForSectionMap[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }
    }
}