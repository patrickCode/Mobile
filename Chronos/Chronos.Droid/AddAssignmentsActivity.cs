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
using Chronos.Core.Model;

namespace Chronos.Droid
{
    [Activity(Label = "Chronos", MainLauncher = false)]
    public class AddAssignmentsActivity : Activity
    {
        private ExpandableListView assignmentsListView;
        private Button applyButton;
        private Button cancelButton;

        private IProjectRepository _projectRepository;
        private List<Assignment> _selectedAssignments;
        public AddAssignmentsActivity()
        {
            _projectRepository = new InMemoryProjectRepository();
            _selectedAssignments = new List<Assignment>();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddAssignmentsLayout);

            InitViews();
            SetHandlers();

            var adapter = new AddAssignmentAdapter(this, _projectRepository, -1);
            assignmentsListView.SetAdapter(adapter);
        }

        private void InitViews()
        {
            assignmentsListView = FindViewById<ExpandableListView>(Resource.Id.projectAssignmentExpandableList);
            applyButton = FindViewById<Button>(Resource.Id.applyButton);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
        }

        private void SetHandlers()
        {
            applyButton.Click += ApplyButtonClicked;
        }

        private void ApplyButtonClicked(object sender, EventArgs e)
        {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(string.Join(", ", _selectedAssignments.Select(assignment => assignment.Name)));
            dialog.Show();
        }

        public void AssignmentChanged(Assignment assignment)
        {
            var requiredAssignment = _selectedAssignments.FirstOrDefault(assign => assign.Id == assignment.Id);
            if (requiredAssignment != null)
                _selectedAssignments.Remove(requiredAssignment);
            else
                _selectedAssignments.Add(assignment);
        }
    }
}