namespace Chronos.Droid.JavaObjects
{
    public class AssignmentCheckBox: Java.Lang.Object
    {
        public int ProjectId { get; set; }
        public int AssignmentId { get; set; }
        public AssignmentCheckBox(int projectId, int assignmentId)
        {
            ProjectId = projectId;
            AssignmentId = assignmentId;
        }
    }
}