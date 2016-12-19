using System.Linq;
using Order.API.Models;
using System.Collections.Generic;

namespace Order.API.Service
{
    public class InMemoryBookService: IBookService
    {
        private static List<Book> Books;
        private static List<Subject> Genres;
        public InMemoryBookService()
        {
            Books = new List<Book>();
            InitBooks();
            InitGenres();
        }

        private void InitBooks()
        {
            Books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Name = "A Brief history of time",
                    Abstract = "From the Big Bang to Black Holes is a 1988 popular-science book by British physicist Stephen Hawking.",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Science",
                    Author = "Stephen Hawking",
                    YearOfPUblish = "1988",
                    IsAvailable = true,
                    ImagePath = "https://pictures.abebooks.com/isbn/9780553053401-us.jpg",
                    IsFavorite = false,
                    Publisher = "Discovery"
                },
                new Book
                {
                    Id = 2,
                    Name = "Cosmos",
                    Abstract = "Cosmos is a 1980 popular science book by astronomer and Pulitzer Prize-winning author Carl Sagan",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Science",
                    Author = "Carl Sagan",
                    YearOfPUblish = "1974",
                    IsAvailable = true,
                    ImagePath = "http://store.discovery.com/imgcache/product/resized/000/542/303/catl/cosmos-paperback-book_1000.jpg?k=aea0cd6c&pid=542303&s=catl&sn=discovery",
                    IsFavorite = true,
                    Publisher = "Discovery"
                },
                new Book
                {
                    Id = 3,
                    Name = "Sherlock Holmes",
                    Abstract = "Complete Sherlock Holmes Set with all 4 Novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Mystery",
                    Author = "Sir Author Conan Doyle",
                    YearOfPUblish = "1974",
                    IsAvailable = true,
                    ImagePath = "http://store.discovery.com/imgcache/product/resized/000/542/303/catl/cosmos-paperback-book_1000.jpg?k=aea0cd6c&pid=542303&s=catl&sn=discovery",
                    IsFavorite = true,
                    Publisher = "Penguin"
                },
                new Book
                {
                    Id = 4,
                    Name = "Pale Blue Dot",
                    Abstract = "A Vision of human future in Space",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Science",
                    Author = "Carl Sagan",
                    YearOfPUblish = "1994",
                    IsAvailable = true,
                    ImagePath = "http://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1432031108i/61663._UY500_SS500_.jpg",
                    IsFavorite = false,
                    Publisher = "Discovery"
                },
                new Book
                {
                    Id = 5,
                    Name = "A Game of Thrones",
                    Abstract = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Fantasy",
                    Author = "George R. R. Martin",
                    YearOfPUblish = "1996",
                    IsAvailable = true,
                    ImagePath = "http://ecx.images-amazon.com/images/I/517gH%2BcV32L._SX292_BO1,204,203,200_.jpg",
                    IsFavorite = true,
                    Publisher = "HBO"
                },
                new Book
                {
                    Id = 6,
                    Name = "A Clash of Kings",
                    Abstract = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Fantasy",
                    Author = "George R. R. Martin",
                    YearOfPUblish = "1998",
                    IsAvailable = true,
                    ImagePath = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcTp87qYCsJxjzFbEY0xtziDVnMniZ31s88MrSt0RrIqZOxCgWEB",
                    IsFavorite = false,
                    Publisher = "HBO"
                },
                new Book
                {
                    Id = 7,
                    Name = "A Storm of Swords",
                    Abstract = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Fantasy",
                    Author = "George R. R. Martin",
                    YearOfPUblish = "2000",
                    IsAvailable = true,
                    ImagePath = "https://images-na.ssl-images-amazon.com/images/I/81oaaPQWaRL.jpg",
                    IsFavorite = false,
                    Publisher = "HBO"
                },
                new Book
                {
                    Id = 8,
                    Name = "A Feast for Crows",
                    Abstract = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Fantasy",
                    Author = "George R. R. Martin",
                    YearOfPUblish = "2005",
                    IsAvailable = true,
                    ImagePath = "http://thebookbundle.com/ekmps/shops/plodit/images/a-song-of-ice-and-fire-collection-2-books-set-by-george-r.-r.-martin-[3]-81409-p.jpg",
                    IsFavorite = false,
                    Publisher = "HBO"
                },
                new Book
                {
                    Id = 9,
                    Name = "A Dance with Dragons",
                    Abstract = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Fantasy",
                    Author = "George R. R. Martin",
                    YearOfPUblish = "2011",
                    IsAvailable = true,
                    ImagePath = "https://d3fa68hw0m2vcc.cloudfront.net/b0f/109713869.jpeg",
                    IsFavorite = false,
                    Publisher = "HBO"
                },
                new Book
                {
                    Id = 10,
                    Name = "The Winds of Winter",
                    Abstract = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Fantasy",
                    Author = "George R. R. Martin",
                    YearOfPUblish = "2017",
                    IsAvailable = false,
                    ImagePath = "http://www.georgerrmartin.com/wp-content/uploads/2013/03/5bookboxset.jpg",
                    IsFavorite = false,
                    Publisher = "HBO"
                },
                new Book
                {
                    Id = 11,
                    Name = "Knots and Crosses",
                    Abstract = "A Detective Rebus novel",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Mystery",
                    Author = "Ian Rankin",
                    YearOfPUblish = "1987",
                    IsAvailable = true,
                    ImagePath = "http://www.ianrankin.net/wp-content/uploads/cache/2015/05/Knots-and-Crosses/1043266416.jpg",
                    IsFavorite = false,
                    Publisher = "Penguin"
                },
                new Book
                {
                    Id = 12,
                    Name = "Hide and Seek",
                    Abstract = "A Detective Rebus novel",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Mystery",
                    Author = "Ian Rankin",
                    YearOfPUblish = "1991",
                    IsAvailable = true,
                    ImagePath = "http://www.ianrankin.net/wp-content/uploads/2015/05/Hide-and-Seek-196x300.jpg",
                    IsFavorite = false,
                    Publisher = "Penguin"
                },
                new Book
                {
                    Id = 13,
                    Name = "Tooth & Nail",
                    Abstract = "A Detective Rebus novel",
                    Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                    Price = 44.95M,
                    SubjectName = "Mystery",
                    Author = "Ian Rankin",
                    YearOfPUblish = "1992",
                    IsAvailable = true,
                    ImagePath = "http://www.ianrankin.net/wp-content/uploads/cache/2015/05/Tooth-and-Nail/2875923906.jpg",
                    IsFavorite = true,
                    Publisher = "Penguin"
                }
            };
        }

        private void InitGenres()
        {
            Genres = new List<Subject>
            {
                new Subject
                {
                    Id = 1,
                    ImagePath = "https://sloan.org/storage/app/media/programs/science/Science%20COIE.jpg",
                    Title = "Science"
                },
                new Subject
                {
                    Id = 2,
                    ImagePath = "http://www.crossfitductusexemplo.com/Websites/crossfitductusexemplo/images/Unraveling-the-Mystery-of-Content-Marketing.jpg",
                    Title = "Mystery"
                },
                new Subject
                {
                    Id = 3,
                    ImagePath = "http://flashfictionfriday.com/wp-content/uploads/2016/03/prompt-photo2.jpg",
                    Title = "Fantasy"
                }
            };
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }

        public Book GetById(int id)
        {
            return Books.FirstOrDefault(book => book.Id == id);
        }

        public List<Book> GetFavouriteBooks()
        {
            return Books.Where(book => book.IsFavorite).ToList();
        }

        public List<Book> GetByGenre(string genre)
        {
            return Books.Where(book => book.SubjectName.Equals(genre)).ToList();
        }

        public List<Subject> GetSubjects()
        {
            return Genres;
        }

    }
}
