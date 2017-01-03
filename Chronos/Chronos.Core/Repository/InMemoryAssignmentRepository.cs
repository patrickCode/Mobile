using System;
using Chronos.Core.Model;
using Chronos.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Chronos.Core.Repository
{
    public class InMemoryAssignmentRepository : IAssignmentRepository
    {
        private IProjectRepository _projectRepository;
        public InMemoryAssignmentRepository()
        {
            _projectRepository = new InMemoryProjectRepository();
        }
        private static List<Project> _userProjects = new List<Project>
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
                            EntryTime = TimeSpan.FromHours(2),
                            ProjectName = "Tech Mahindra"
                        }
                    }
                }
        };

        private static List<Project> _currentProjects = new List<Project>
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
                        }
                    }
                }
        };

        public List<Project> GetUserAssignments(string userUpn, DateTime date)
        {
            if (DateTime.Today == date.Date)
                return _currentProjects;
            else
                return _userProjects;
        }

        public Assignment GetAssignment(string userUpn, int assignmentId, DateTime date)
        {
            List<Project> projects;
            if (DateTime.Today == date.Date)
                projects = _currentProjects;
            else
                projects = _userProjects;

            var allAssignments = projects.SelectMany(project => project.Assignments);
            var requiredAssignment = allAssignments.FirstOrDefault(assignment => assignment.Id == assignmentId);
            return requiredAssignment;
        }

        public bool UpdateAssignment(string userUpn, Assignment updatedAssignment, DateTime date, out string failureReason)
        {
            List<Project> projects;
            if (DateTime.Today == date.Date)
                projects = _currentProjects;
            else
                projects = _userProjects;

            //var totalTimeSpan = GetTotalHours(userUpn, date);
            var updatedTimeSpan = GetTotalHours(userUpn, date);
            if (updatedTimeSpan > TimeSpan.FromHours(16))
            {
                failureReason = "TIME_EXCEEDED";
                return false;
            }

            UpdateAssignment(projects, updatedAssignment);
            failureReason = string.Empty;
            return true;
        }

        public void AddNewAssignments(List<Assignment> assignments, DateTime date)
        {
            foreach (var assignment in assignments)
                AddNewAssignment(assignment, date);
        }

        public void AddNewAssignment(Assignment assignment, DateTime date)
        {
            if (DateTime.Today == date.Date)
                _currentProjects = AddToUserProjects(_currentProjects, assignment);
            else
                _userProjects = AddToUserProjects(_userProjects, assignment);
        }

        public TimeSpan GetTotalHours(string userUpn, DateTime date)
        {
            var totalTimeSpan = TimeSpan.Zero;
            var projects = new List<Project>();

            if (DateTime.Today == date.Date)
                projects = _currentProjects;
            else
                projects = _userProjects;

            foreach (var project in projects)
            {
                totalTimeSpan = totalTimeSpan.Add(GetTotalHours(userUpn, project.Id, date));
            }

            return totalTimeSpan;
        }

        public TimeSpan GetTotalHours(string userUpn, int projectId, DateTime date)
        {
            if (DateTime.Today == date.Date)
                return ComputeTotalHours(projectId, _currentProjects);
            else
                return ComputeTotalHours(projectId, _userProjects);
        }

        public void RemoveExistingAssignments(List<Assignment> assignments, DateTime date)
        {
            foreach (var assignment in assignments)
                RemoveExistingAssignment(assignment, date);
        }

        public void RemoveExistingAssignment(Assignment assignment, DateTime date)
        {
            if (DateTime.Today == date.Date)
                _currentProjects = DeleteFromUserProjects(_currentProjects, assignment);
            else
                _userProjects = DeleteFromUserProjects(_userProjects, assignment);
        }

        private List<Project> AddToUserProjects(List<Project> projects, Assignment assignment)
        {
            var projectName = assignment.ProjectName;
            var requiredProject = projects.FirstOrDefault(project => project.Name.Equals(projectName));
            if (requiredProject != null)
            {
                var requiredAssignment = requiredProject.Assignments.FirstOrDefault(asgnmt => asgnmt.Id == assignment.Id);
                if (requiredAssignment == null)
                    requiredProject.Assignments.Add(assignment);
            }   
            else
            {
                requiredProject = _projectRepository.Get(projectName);
                projects.Add(new Project()
                {
                    Id = requiredProject.Id,
                    Name = requiredProject.Name,
                    Assignments = new List<Assignment>()
                    {
                        assignment
                    }
                });
            }
            return projects;
        }

        private List<Project> DeleteFromUserProjects(List<Project> projects, Assignment assignment)
        {
            var projectName = assignment.ProjectName;
            var requiredProject = projects.FirstOrDefault(project => project.Name.Equals(projectName));
            if (requiredProject != null)
            {
                requiredProject.Assignments.Remove(assignment);
                if (requiredProject.Assignments.Count == 0)
                    projects.Remove(requiredProject);
            }
            return projects;
        }    

        private TimeSpan ComputeTotalHours(int projectId, List<Project> projects)
        {
            var requiredProject = projects.FirstOrDefault(project => project.Id == projectId);
            if (requiredProject == null)
                return TimeSpan.Zero;
            var totalTimeSpan = TimeSpan.Zero;
            foreach (var assignment in requiredProject.Assignments)
            {
                totalTimeSpan = totalTimeSpan.Add(assignment.EntryTime);
            }
            return totalTimeSpan;
        }

        private void UpdateAssignment(List<Project> projects, Assignment updatedAssignment)
        {
            var allAssignments = projects.SelectMany(project => project.Assignments);
            var requiredAssignment = allAssignments.FirstOrDefault(assignment => assignment.Id == updatedAssignment.Id);
            requiredAssignment = updatedAssignment;
        }
    }
}