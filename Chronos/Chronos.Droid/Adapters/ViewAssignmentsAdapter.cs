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

namespace Chronos.Droid.Adapters
{
    public class ViewAssignmentsAdapter : BaseExpandableListAdapter
    {
        private Activity _currentContext;
        private IAssignmentRepository _assignmentRepository;
        private IProjectRepository _projectRepository;
        private DateTime _entryDate;
        private List<Project> _projects;
        public ViewAssignmentsAdapter(Activity currentContext, IAssignmentRepository assignmentRepository, IProjectRepository projectRepository, DateTime entryDate)
        {
            _currentContext = currentContext;
            _assignmentRepository = assignmentRepository;
            _projectRepository = projectRepository;
            _entryDate = entryDate;
            _projects = _assignmentRepository.GetUserAssignments("", _entryDate);
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
            throw new NotImplementedException();
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            if (_projects.Count <= groupPosition)
                return 0;
            var requiredProject = _projects[groupPosition];
            if (requiredProject.Assignments.Count <= childPosition)
                return 0;
            var requiredAssignment = requiredProject.Assignments[childPosition];
            return requiredAssignment.Id;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            if (_projects.Count <= groupPosition)
                return 0;
            var requiredProject = _projects[groupPosition];
            return requiredProject.Assignments.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            if (_projects.Count <= groupPosition)
                return null;
            var requiredProject = _projects[groupPosition];
            if (requiredProject.Assignments.Count <= childPosition)
                return null;
            var requiredAssignment = requiredProject.Assignments[childPosition];

            var assignmentRow = convertView;
            if (assignmentRow == null)
            {
                assignmentRow = _currentContext.LayoutInflater.Inflate(Resource.Layout.ViewAssignmentAssignmentRowLayout, parent, false);
                var nameTextView = assignmentRow.FindViewById<TextView>(Resource.Id.viewAssignmentRowAssignmentText);
                var totalHoursTextView = assignmentRow.FindViewById<TextView>(Resource.Id.viewAssignmentRowHoursText);
                var holder = new ViewAssignmentRowHolder(nameTextView, totalHoursTextView, requiredAssignment);
                assignmentRow.Tag = holder;
            }

            var viewHolder = assignmentRow.Tag as ViewAssignmentRowHolder;
            viewHolder.AssignmentNameTextView.Text = requiredAssignment.Name;
            viewHolder.TotalHoursTextView.Text = $"{requiredAssignment.EntryTime.Hours}:{requiredAssignment.EntryTime.Minutes}";

            return assignmentRow;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            if (_projects.Count <= groupPosition)
                return -1;
            var requiredProject = _projects[groupPosition];
            return requiredProject.Id;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            if (_projects.Count <= groupPosition)
                return null;
            var requiredProject = _projects[groupPosition];

            var headerRow = convertView;
            if (headerRow == null)
            {
                headerRow = _currentContext.LayoutInflater.Inflate(Resource.Layout.ViewAssignmentProjectHeaderRowLayout, parent, false);
                var nameTextView = headerRow.FindViewById<TextView>(Resource.Id.viewAssignmentHeaderProjectText);
                var entryHourTextView = headerRow.FindViewById<TextView>(Resource.Id.viewAssignmentHeaderTotalHourText);
                var holder = new ViewAssignmentHeaderRowHolder(nameTextView, entryHourTextView);
                headerRow.Tag = holder;
            }

            var viewHolder = headerRow.Tag as ViewAssignmentHeaderRowHolder;
            viewHolder.ProjectNameTextView.Text = requiredProject.Name;
            var totalEntryHour = _assignmentRepository.GetTotalHours("", requiredProject.Id, _entryDate);
            viewHolder.TotalEntryHour.Text = $"{totalEntryHour.Hours}:{totalEntryHour.Minutes}";

            return headerRow;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }
}