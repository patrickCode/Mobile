using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Chronos.Droid.Adapters
{
    public class ViewAssignmentTabAdapter : FragmentPagerAdapter
    {
        private Android.Support.V4.App.Fragment[] _fragments;
        private ICharSequence[] _titles;

        public ViewAssignmentTabAdapter(Android.Support.V4.App.FragmentManager fragmentManager,
            Android.Support.V4.App.Fragment[] fragments, ICharSequence[] titles)
            :base(fragmentManager)
        {   
            _fragments = fragments;
            _titles = titles;
        }

        public override int Count
        {
            get
            {
                return _fragments.Length;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {   
            return _fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return _titles[position];
        }
    }
}