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
            _repository = new ApiRepository();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _repository.GetAllBooks();
        }

        public IEnumerable<Book> GetFavoriteBooks()
        {
            return _repository.GetFavouriteProducts();
        }

        public Book GetById(int Id)
        {
            return _repository.GetById(Id);
        }
        public IEnumerable<Subject> GetSubjects()
        {
            return _repository.GetProductGroups();
        }
        public IEnumerable<Book> GetBySubject(string genreName)
        {
            return _repository.GetByGenre(genreName);
        }
    }
}