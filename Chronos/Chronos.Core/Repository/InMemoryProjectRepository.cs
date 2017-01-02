using System.Linq;
using Chronos.Core.Model;
using System.Collections.Generic;
using Chronos.Core.Interfaces;

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
                            Name = "New Hire Training"
                        },
                        new Assignment()
                        {
                            Id = 2,
                            Name = "Meetings & Events"
                        },
                        new Assignment()
                        {
                            Id = 3,
                            Name = "General Administration"
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
                            Name = "Custom"
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
                            Name = "General Admininstration"
                        },
                        new Assignment()
                        {
                            Id = 6,
                            Name = "Meetings & Events"
                        },
                        new Assignment()
                        {
                            Id = 7,
                            Name = "New Hire Training"
                        },
                        new Assignment()
                        {
                            Id = 8,
                            Name = "Premier - Presales Activity"
                        },
                        new Assignment()
                        {
                            Id = 9,
                            Name = "Time Away"
                        },
                        new Assignment()
                        {
                            Id = 10,
                            Name = "Premier Proactive Offerings Accrediation"
                        },
                        new Assignment()
                        {
                            Id = 11,
                            Name = "Stand by/Bench Time"
                        },
                        new Assignment()
                        {
                            Id = 12,
                            Name = "Training Taken"
                        },
                        new Assignment()
                        {
                            Id = 13,
                            Name = "Travel - Non Util"
                        },
                        new Assignment()
                        {
                            Id = 14,
                            Name = "Travel - Non client related"
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
                            Name = "General Admininstration"
                        },
                        new Assignment()
                        {
                            Id = 16,
                            Name = "Meetings & Events"
                        },
                        new Assignment()
                        {
                            Id = 17,
                            Name = "New Hire Training"
                        },
                        new Assignment()
                        {
                            Id = 18,
                            Name = "Premier - Presales Activity"
                        },
                        new Assignment()
                        {
                            Id = 19,
                            Name = "Time Away"
                        },
                        new Assignment()
                        {
                            Id = 20,
                            Name = "Premier Proactive Offerings Accrediation"
                        },
                        new Assignment()
                        {
                            Id = 21,
                            Name = "Stand by/Bench Time"
                        },
                        new Assignment()
                        {
                            Id = 22,
                            Name = "Training Taken"
                        },
                        new Assignment()
                        {
                            Id = 23,
                            Name = "Travel - Non Util"
                        },
                        new Assignment()
                        {
                            Id = 24,
                            Name = "Travel - Non client related"
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