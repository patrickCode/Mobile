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
using MultiLevelList.Repository;

namespace MultiLevelList
{
    public class MultiLevelAdapter : BaseExpandableListAdapter
    {
        private List<Project> projects;
        private Activity context;
        public MultiLevelAdapter(Activity context, List<Project> projects)
        {
            this.context = context;
            this.projects = projects;
        }
        public override int GroupCount
        {
            get
            {
                return projects.Count;
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
            return projects[groupPosition].Assignments[childPosition].Id;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return projects[groupPosition].Assignments.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var assignment = projects[groupPosition].Assignments[childPosition];
            var view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ItemLayout, parent, false);
            }
            view.FindViewById<TextView>(Resource.Id.itemText).Text = assignment.Name;
            return view;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            return projects[groupPosition].Id;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var header = convertView;
            var group = projects[groupPosition];
            if (header == null)
            {
                header = context.LayoutInflater.Inflate(Resource.Layout.GroupHeaderLayout, parent, false);
            }
            header.FindViewById<TextView>(Resource.Id.groupHeaderText).Text = group.Name;
            return header;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }
}