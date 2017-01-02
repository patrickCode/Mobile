using System;
using Chronos.Core.Model;
using Chronos.Core.Interfaces;
using System.Collections.Generic;

namespace Chronos.Core.Repository
{
    public class InMemoryAssignmentRepository : IAssignmentRepository
    {
        private List<Project> _userProjects = new List<Project>
        {
            new Project()
                {
                    Id = 1,
                    Name = "Tech Mahindra",
                    Assignments = new List<Assignment>
                    {
                        new Assignment()
                        {
                            Id = 1,
                            Name = "New Hire Training"
                        },
                        new Assignment()
                        {
                            Id = 2,
                            Name = "Meetings & Events"
                        }
                    }
                }
        };
        public List<Project> GetUserAssignments(string userUpn, DateTime date)
        {
            return _userProjects;
        }
    }
}
