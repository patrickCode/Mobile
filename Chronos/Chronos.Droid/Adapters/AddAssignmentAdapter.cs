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
using Java.Lang;
using Chronos.Core.Interfaces;
using Chronos.Core.Model;
using Chronos.Droid.ViewHolders;
using Chronos.Droid.JavaObjects;

namespace Chronos.Droid.Adapters
{
    public class AddAssignmentAdapter : BaseExpandableListAdapter
    {
        private IProjectRepository _projectRespository;
        private Activity _currentContext;
        private List<Project> _projects;
        private List<Assignment> _selectedAssignments;


        public AddAssignmentAdapter(Activity currentContext, IProjectRepository projectRespository, List<Assignment> selectedAssignments = null, int selectedProjectId = -1)
        {
            _currentContext = currentContext;
            _projectRespository = projectRespository;
            GetAllProjects(selectedProjectId);
            _selectedAssignments = selectedAssignments;
        }

        private void GetAllProjects(int selectedProjectId)
        {
            if (selectedProjectId >= 0)
                _projects = new List<Project> { _projectRespository.Get(selectedProjectId) };
            else
                _projects = _projectRespository.Get();
        }

        public override int GroupCount
        {
            get
            {
                return _projects.Count;
            }
        }

        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            var assignment = _projects[groupPosition].Assignments[childPosition];
            //return assignment as Java.Lang.Object;
            throw new NotImplementedException();
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            var requiredProject = _projects[groupPosition];
            var requiredAssignment = requiredProject.Assignments[childPosition];
            return requiredAssignment.Id;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            var requiredProject = _projects[groupPosition];
            return requiredProject.Assignments.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var requiredProject = _projects[groupPosition];
            var requiredAssignment = requiredProject.Assignments[childPosition];

            var assignmentRow = convertView;

            //Android initializing the view for the first time
            if (assignmentRow == null)
            {
                assignmentRow = _currentContext.LayoutInflater.Inflate(Resource.Layout.AddAssignmentRowLayout, parent, false);
                //Caching the view reference
                var holder = new AssignmentViewHolder(assignmentRow.FindViewById<CheckBox>(Resource.Id.assignmentRowNameCheckView));
                assignmentRow.Tag = holder;
            }

            var viewHolder = assignmentRow.Tag as AssignmentViewHolder;
            var assignmentNameCheckView = viewHolder.AssignmentNameCheckView;
            assignmentNameCheckView.Tag = new AssignmentCheckBox(requiredProject.Id, requiredAssignment.Id);
            assignmentNameCheckView.Text = requiredAssignment.Name;

            if (_selectedAssignments.Select(assignment => assignment.Id).Contains(requiredAssignment.Id))
                assignmentNameCheckView.Checked = true;

            assignmentNameCheckView.CheckedChange += AssignmentNameCheckView_CheckedChange;

            return assignmentRow;
        }

        private void AssignmentNameCheckView_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            var assignmentRow = sender as CheckBox;
            var assignementCheckBox = assignmentRow.Tag as AssignmentCheckBox;

            var requiredProject = _projects.First(project => project.Id == assignementCheckBox.ProjectId);
            var requiredAssignment = requiredProject.Assignments.First(assignment => assignment.Id == assignementCheckBox.AssignmentId);

            (_currentContext as AddAssignmentsActivity).AssignmentChanged(requiredAssignment, e.IsChecked);
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            var requiredProject = _projects[groupPosition];
            return requiredProject.Id;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var requiredProject = _projects[groupPosition];

            var projectHeaderRow = convertView;
            //Android initializing the view for the first time
            if (projectHeaderRow == null)
            {
                projectHeaderRow = _currentContext.LayoutInflater.Inflate(Resource.Layout.AddProjectRowLayout, parent, false);
                var holder = new ProjectViewHolder(projectHeaderRow.FindViewById<CheckBox>(Resource.Id.projectNameCheckBox));
                projectHeaderRow.Tag = holder;
            }

            var viewHolder = projectHeaderRow.Tag as ProjectViewHolder;
            var projectRowNameCheckView = viewHolder.ProjectNameTextView;
            projectRowNameCheckView.Text = requiredProject.Name;

            (parent as ExpandableListView).ExpandGroup(groupPosition);
            return projectHeaderRow;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            //All assignments can be selected.
            return true;
        }
    }
}