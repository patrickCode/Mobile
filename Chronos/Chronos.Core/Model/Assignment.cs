namespace Chronos.Core.Model
{
    public class Assignment
    {
        public Assignment() { }
        public Assignment(int id, string name, string projectName)
        {
            Id = id;
            Name = name;
            ProjectName = projectName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
    }
}