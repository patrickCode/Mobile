using Android.Widget;

namespace Chronos.Droid.ViewHolders
{
    public class ViewAssignmentHeaderRowHolder: Java.Lang.Object
    {
        public TextView ProjectNameTextView { get; set; }
        public TextView TotalEntryHour { get; set; }
        public ViewAssignmentHeaderRowHolder(TextView projectNameTextView, TextView totalEntryHour)
        {
            ProjectNameTextView = projectNameTextView;
            TotalEntryHour = totalEntryHour;
        }
    }
}