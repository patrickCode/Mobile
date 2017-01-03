using System;
using Chronos.Core.Model;
using System.Collections.Generic;

namespace Chronos.Core.Interfaces
{
    public interface IAssignmentRepository
    {
        Assignment GetAssignment(string userUpn, int assignmentId, DateTime date);
        List<Project> GetUserAssignments(string userUpn, DateTime date);
        bool UpdateAssignment(string userUpn, Assignment updatedAssignment, DateTime date, out string failureReason);
        void AddNewAssignments(List<Assignment> assignments, DateTime date);
        void AddNewAssignment(Assignment assignment, DateTime date);
        void RemoveExistingAssignments(List<Assignment> assignments, DateTime date);
        void RemoveExistingAssignment(Assignment assignment, DateTime date);
        TimeSpan GetTotalHours(string userUpn, int projectId, DateTime date);
        TimeSpan GetTotalHours(string userUpn, DateTime date);
    }
}