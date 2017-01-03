using Android.Widget;
using Chronos.Core.Model;

namespace Chronos.Droid.ViewHolders
{
    public class ViewAssignmentRowHolder : Java.Lang.Object
    {
        public TextView AssignmentNameTextView { get; set; }
        public TextView TotalHoursTextView { get; set; }
        public Assignment Assignment { get; set; }
        public ViewAssignmentRowHolder(TextView assignmentNameTextView, TextView totalHoursTextView, Assignment assignment)
        {
            AssignmentNameTextView = assignmentNameTextView;
            TotalHoursTextView = totalHoursTextView;
            Assignment = assignment;
        }
    }
}