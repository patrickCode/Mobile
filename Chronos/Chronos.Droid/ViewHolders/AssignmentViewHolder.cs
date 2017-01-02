using Android.Widget;

namespace Chronos.Droid.ViewHolders
{
    public class AssignmentViewHolder: Java.Lang.Object
    {
        public CheckBox AssignmentNameCheckView { get; set; }
        public AssignmentViewHolder(CheckBox assignmentNameCheckView)
        {
            AssignmentNameCheckView = assignmentNameCheckView;
        }
    }
}