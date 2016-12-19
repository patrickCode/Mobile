using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using Order.API.Service;

namespace Order.API.Controllers
{

    public class BooksController : Controller
    {
        private IBookService _bookService;
        public BooksController()
        {
            _bookService = new InMemoryBookService();
        }

        [HttpGet]
        [Route("api/books")]
        public IEnumerable<Book> Get([FromQuery]bool? favourite)
        {
            if (favourite == null)
                return _bookService.GetAllBooks();
            else if (favourite.Value)
                return _bookService.GetFavouriteBooks();
            return _bookService.GetAllBooks();
        }

        [Route("api/books/{id}")]
        public Book Get(int id)
        {
            return _bookService.GetById(id);
        }

        [HttpGet("api/genre/{genreName}/books")]
        public IEnumerable<Book> Get(string genreName)
        {
            return _bookService.GetByGenre(genreName);
        }
    }
}
