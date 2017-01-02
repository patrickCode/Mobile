using System;
using Chronos.Core.Model;
using System.Collections.Generic;

namespace Chronos.Core.Interfaces
{
    public interface IAssignmentRepository
    {
        List<Project> GetUserAssignments(string userUpn, DateTime date);
    }
}