namespace LibraryAPI.Models
{
    public class BookDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int ManagerBookId { get; set; }
        public int UserBookId { get; set; }
    }
}
