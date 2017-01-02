using System;
using Chronos.Core.Model;
using Chronos.Core.Interfaces;
using System.Collections.Generic;

namespace Chronos.Core.Repository
{
    public class InMemoryLaborCategoryRepository : ILaborCategoryRepository
    {
        private static List<LaborCategory> categories = new List<LaborCategory>
        {
            new LaborCategory(1, "Meetings & Events"),
            new LaborCategory(2, "New Hire Training"),
            new LaborCategory(3, "General Administration"),
            new LaborCategory(4, "Time Away"),
            new LaborCategory(5, "Travel")
        };

        public List<LaborCategory> Get()
        {
            return categories;
        }
    }
}