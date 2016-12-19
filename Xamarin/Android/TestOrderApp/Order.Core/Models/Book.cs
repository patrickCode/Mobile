namespace Order.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public bool IsFavorite { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string YearOfPUblish { get; set; }
        public string SubjectName { get; set; }
    }
}