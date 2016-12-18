using Order.Core.Models;
using System.Collections.Generic;

namespace Order.Core.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetById(int Id);
        IEnumerable<ProductGroup> GetProductGroups();
        ProductGroup GetProductGroup(int id);
        IEnumerable<Product> GetFavouriteProducts();
    }
}
