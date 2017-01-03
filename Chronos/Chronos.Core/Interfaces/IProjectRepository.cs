using Chronos.Core.Model;
using System;
using System.Collections.Generic;

namespace Chronos.Core.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> Get();
        Project Get(string projectName);
        Project Get(int projectId);
    }
}