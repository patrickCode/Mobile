using System.Collections.Generic;

namespace MultiLevelList.Repository
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProjectRepository
    {
        public List<Project> Get()
        {
            var projects = new List<Project>()
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
                    Name = "Non-Project/Non-Customer",
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
                        }
                    }
                }
            };
            return projects;
        }
    }

}