using Order.Core.Models;
using Order.Core.Repository;
using System.Collections.Generic;

namespace Order.Core.Service
{
    public class ProductService
    {
        private readonly IRepository _repository;
        public ProductService()
        {
            _repository = new InMemoryRepository();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public IEnumerable<Product> GetFavoriteProducts()
        {
            return _repository.GetFavouriteProducts();
        }

        public Product GetById(int Id)
        {
            return _repository.GetById(Id);
        }
        public IEnumerable<ProductGroup> GetProductGroups()
        {
            return _repository.GetProductGroups();
        }
        public ProductGroup GetProductGroup(int id)
        {
            return _repository.GetProductGroup(id);
        }
    }
}