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

namespace Chronos.Droid.Adapters
{
    public class ShowAssignmentsAdapter : BaseExpandableListAdapter
    {
        private Activity _currentContext;
        private IAssignmentRepository _assignmentRepository;
        private DateTime _entryDate;
        private List<Project> _projects; 
        public ShowAssignmentsAdapter(Activity currentContext, IAssignmentRepository assignmentRepository, DateTime entryDate)
        {
            _currentContext = currentContext;
            _assignmentRepository = assignmentRepository;
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
            var requiredProject = _projects[groupPosition];
            var requiredAssignment = requiredProject.Assignments[childPosition];
            return requiredAssignment.Id;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }
    }
}