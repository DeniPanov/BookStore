namespace BookStore.Server.Features.Books.Models
{
    public class BookDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        public string ISBN { get; set; }

        public string? BookImage { get; set; }
        
        public string Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int PageCount { get; set; }

        public int Quantity { get; set; }

        public int PurchasesCount { get; set; }
    }
}
