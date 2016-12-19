using System.Collections.Generic;

namespace Order.API.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public List<Book> Products { get; set; }
    }
}