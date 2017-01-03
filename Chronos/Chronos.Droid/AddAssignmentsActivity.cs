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
using Chronos.Droid.NativeServices;

namespace Chronos.Droid
{
    [Activity(Label = "Chronos", MainLauncher = false)]
    public class AddAssignmentsActivity : Activity
    {
        private ExpandableListView assignmentsListView;
        private Button applyButton;
        private Button cancelButton;
        private DateTime _entryDate;

        private IProjectRepository _projectRepository;
        private IAssignmentRepository _assignmentRepository;
        private List<Assignment> _selectedAssignments;
        private List<Assignment> _unselectedAssignments;
        private List<Assignment> _preSelectedAssignments;

        public AddAssignmentsActivity()
        {
            _projectRepository = new InMemoryProjectRepository();
            _assignmentRepository = new InMemoryAssignmentRepository();
            _selectedAssignments = new List<Assignment>();
            _preSelectedAssignments = new List<Assignment>();
            _unselectedAssignments = new List<Assignment>();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddAssignmentsLayout);

            InitViews();
            SetHandlers();

            _entryDate = DateTime.Parse(Intent.GetStringExtra("EntryDate"));
            var selectedProjects = _assignmentRepository.GetUserAssignments("", _entryDate);
            _preSelectedAssignments = selectedProjects.SelectMany(project => project.Assignments).ToList();

            var adapter = new AddAssignmentAdapter(this, _projectRepository, _preSelectedAssignments, -1);
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
            _assignmentRepository.AddNewAssignments(_selectedAssignments, _entryDate);
            _assignmentRepository.RemoveExistingAssignments(_unselectedAssignments, _entryDate);

            var assignment = _selectedAssignments[0];

            var calendarService = new CalenderService(this);
            calendarService.AddCalendarEvent(assignment.ProjectName, assignment.Name, _entryDate, _entryDate, TimeZone.CurrentTimeZone);

            var intent = new Intent(this, typeof(AssignmentActivity));
            StartActivity(intent);
        }
        
        public void AssignmentChanged(Assignment assignment, bool selected)
        {
            var isAssignmentPreselected = _preSelectedAssignments.Any(preselectedAssignment => preselectedAssignment.Id == assignment.Id);
            if (selected)
            {
                if (isAssignmentPreselected) //No action needed since the assignment was already pre-selected
                    return;
                _selectedAssignments.Add(assignment);
            }
            else
            {
                var requiredAssignment = _selectedAssignments.FirstOrDefault(assign => assign.Id == assignment.Id);
                var preselectedAssignment = _preSelectedAssignments.FirstOrDefault(assign => assign.Id == assignment.Id);
                if (isAssignmentPreselected)
                    DeleteAssignment(preselectedAssignment);
                _selectedAssignments.Remove(requiredAssignment);
            }


            //var requiredAssignment = _selectedAssignments.FirstOrDefault(assign => assign.Id == assignment.Id);
            //if (requiredAssignment != null)
            //{
            //    _selectedAssignments.Remove(requiredAssignment);
            //    DeleteAssignment(assignment);
            //}   
            //else
            //{   
            //    _selectedAssignments.Add(assignment);
            //}   
        }

        private void DeleteAssignment(Assignment deletedAssignment)
        {
            if (_preSelectedAssignments.Any(assignment => assignment.Id == deletedAssignment.Id))
            {
                _unselectedAssignments.Add(deletedAssignment);
            }
        }
    }
}