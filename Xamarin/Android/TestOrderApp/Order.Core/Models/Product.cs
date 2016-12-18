namespace Order.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        public bool IsFavorite { get; set; }
        public string GroupName { get; set; }
    }
}