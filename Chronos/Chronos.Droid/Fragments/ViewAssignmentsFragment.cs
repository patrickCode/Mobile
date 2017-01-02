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

namespace Chronos.Droid.Fragments
{
    [Activity(Label = "ViewAssignmentsFragment")]
    public class ViewAssignmentsFragment : Android.Support.V4.App.Fragment
    {
        private ExpandableListView AssignmentExpandableList;

        private Activity _currentContext;
        private DateTime _entryDate;
        
        public ViewAssignmentsFragment(Activity currentContext, DateTime entryDate)
        {
            _currentContext = currentContext;
            _entryDate = entryDate;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ViewAssignmentsLayout, container, false);
            AssignmentExpandableList = view.FindViewById<ExpandableListView>(Resource.Id.viewAssignmentsExpandableList);

            return view;
        }
    }
}