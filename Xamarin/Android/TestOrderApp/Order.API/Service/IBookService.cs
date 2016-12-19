using Order.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Service
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetById(int id);
        List<Book> GetFavouriteBooks();
        List<Book> GetByGenre(string genre);
        List<Subject> GetSubjects();
    }
}
