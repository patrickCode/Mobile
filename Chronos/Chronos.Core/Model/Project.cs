using System;
using System.Collections.Generic;

namespace Chronos.Core.Model
{
    public class Project
    {
        public Project() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; }
        public TimeSpan LabourTime { get; set; } 
    }
}
