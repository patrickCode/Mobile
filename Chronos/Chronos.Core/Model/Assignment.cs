using System;

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
        public TimeSpan EntryTime { get; set; }
        public string Notes { get; set; }
        public TimeZoneInfo Timezone { get; set; }
        public string Category { get; set; }
    }
}