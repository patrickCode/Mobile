using Chronos.Core.Model;
using System.Collections.Generic;

namespace Chronos.Core.Interfaces
{
    public interface ILaborCategoryRepository
    {
        List<LaborCategory> Get();        
    }
}