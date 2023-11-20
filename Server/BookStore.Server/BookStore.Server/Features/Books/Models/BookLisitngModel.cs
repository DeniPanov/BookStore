namespace BookStore.Server.Features.Books.Models
{
    public class BookLisitngModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Summary { get; set; }

        public string BookImage { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
