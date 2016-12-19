using Order.Core.Models;
using System.Collections.Generic;

namespace Order.Core.Repository
{
    public interface IRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetById(int Id);
        IEnumerable<Subject> GetProductGroups();
        Subject GetProductGroup(int id);
        IEnumerable<Book> GetFavouriteProducts();
        IEnumerable<Book> GetByGenre(string genreName);
    }
}
