using System.Linq;
using Chronos.Core.Model;
using System.Collections.Generic;
using Chronos.Core.Interfaces;
using System;

namespace Chronos.Core.Repository
{
    public class InMemoryProjectRepository : IProjectRepository
    {
        private static List<Project> Projects = new List<Project>
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
                            Name = "New Hire Training",
                            ProjectName = "Tech Mahindra"
                        },
                        new Assignment()
                        {
                            Id = 2,
                            Name = "Meetings & Events",
                            ProjectName = "Tech Mahindra"
                        },
                        new Assignment()
                        {
                            Id = 3,
                            Name = "General Administration",
                            ProjectName = "Tech Mahindra"
                        }
                    }
                },
                new Project()
                {
                    Id = 2,
                    Name = "National Australia Group UK",
                    Assignments = new List<Assignment>
                    {
                        new Assignment()
                        {
                            Id = 4,
                            Name = "Custom",
                            ProjectName = "National Australia Group UK"
                        }
                    }
                },
                new Project()
                {
                    Id = 3,
                    Name = "Non-Project",
                    Assignments = new List<Assignment>
                    {
                        new Assignment()
                        {
                            Id = 5,
                            Name = "General Admininstration",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 6,
                            Name = "Meetings & Events",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 7,
                            Name = "New Hire Training",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 8,
                            Name = "Premier - Presales Activity",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 9,
                            Name = "Time Away",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 10,
                            Name = "Premier Proactive Offerings Accrediation",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 11,
                            Name = "Stand by/Bench Time",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 12,
                            Name = "Training Taken",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 13,
                            Name = "Travel - Non Util",
                            ProjectName = "Non-Project"
                        },
                        new Assignment()
                        {
                            Id = 14,
                            Name = "Travel - Non client related",
                            ProjectName = "Non-Project"
                        }
                    }
                },
                new Project()
                {
                    Id = 4,
                    Name = "Non-Customer",
                    Assignments = new List<Assignment>
                    {
                        new Assignment()
                        {
                            Id = 15,
                            Name = "General Admininstration",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 16,
                            Name = "Meetings & Events",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 17,
                            Name = "New Hire Training",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 18,
                            Name = "Premier - Presales Activity",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 19,
                            Name = "Time Away",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 20,
                            Name = "Premier Proactive Offerings Accrediation",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 21,
                            Name = "Stand by/Bench Time",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 22,
                            Name = "Training Taken",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 23,
                            Name = "Travel - Non Util",
                            ProjectName = "Non-Customer"
                        },
                        new Assignment()
                        {
                            Id = 24,
                            Name = "Travel - Non client related",
                            ProjectName = "Non-Customer"
                        }
                    }
                }
        };
        public List<Project> Get()
        {
            return Projects;
        }

        public Project Get(string projectName)
        {
            return Projects.FirstOrDefault(project => project.Name.Equals(projectName));
        }

        public Project Get(int projectId)
        {
            return Projects.FirstOrDefault(project => project.Id == projectId);
        }
    }
}