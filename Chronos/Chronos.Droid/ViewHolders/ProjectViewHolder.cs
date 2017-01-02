using Android.Widget;

namespace Chronos.Droid.ViewHolders
{
    public class ProjectViewHolder: Java.Lang.Object
    {
        public CheckBox ProjectNameTextView { get; set; }
        public ProjectViewHolder(CheckBox projectNameTextView)
        {
            ProjectNameTextView = projectNameTextView;
        }
    }
}