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
using Chronos.Core.Interfaces;
using Chronos.Core.Repository;
using Chronos.Droid.Adapters;

namespace Chronos.Droid.Fragments
{
    [Activity(Label = "ViewAssignmentsFragment")]
    public class ViewAssignmentsFragment : Android.Support.V4.App.Fragment
    {
        private Button AddAssignmentsButton;
        private ExpandableListView AssignmentExpandableList;
        private TextView TotalHoursTextView;

        private Activity _currentContext;
        private DateTime _entryDate;
        private IProjectRepository _projectRepository;
        private IAssignmentRepository _assignmentRepository;
        
        
        public ViewAssignmentsFragment(Activity currentContext, DateTime entryDate)
        {
            _currentContext = currentContext;
            _entryDate = entryDate;
            _projectRepository = new InMemoryProjectRepository();
            _assignmentRepository = new InMemoryAssignmentRepository();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.ViewAssignmentsLayout, container, false);

            TotalHoursTextView = view.FindViewById<TextView>(Resource.Id.viewAssignmentDayTotalTextView);

            AddAssignmentsButton = view.FindViewById<Button>(Resource.Id.viewAssignmentAddButton);
            AddAssignmentsButton.Click += AddAssignments;

            AssignmentExpandableList = view.FindViewById<ExpandableListView>(Resource.Id.viewAssignmentsExpandableList);
            var adapter = new ViewAssignmentsAdapter(_currentContext, _assignmentRepository, _projectRepository, _entryDate);
            AssignmentExpandableList.SetAdapter(adapter);
            AssignmentExpandableList.ChildClick += AssignmentSelected;
            AssignmentExpandableList.ExpandGroup(0);

            CalculateTotalHour();
            return view;
        }

        public void CalculateTotalHour()
        {
            var totalHours = _assignmentRepository.GetTotalHours("", _entryDate);
            TotalHoursTextView.Text = $"{totalHours.Hours}:{totalHours.Minutes}";
        }

        private void AssignmentSelected(object sender, ExpandableListView.ChildClickEventArgs e)
        {   
            var assignmentId = (int)e.Id;

            var intent = new Intent(_currentContext, typeof(AddLaborActivity));
            intent.PutExtra("SelectedAssignmentId", assignmentId);
            intent.PutExtra("EntryDate", _entryDate.ToString());
            _currentContext.StartActivityForResult(intent, 100);
        }

        private void AddAssignments(object sender, EventArgs e)
        {
            var intent = new Intent(_currentContext, typeof(AddAssignmentsActivity));
            intent.PutExtra("EntryDate", _entryDate.ToString());
            _currentContext.StartActivity(intent);
        }
    }
}