using System.ComponentModel.DataAnnotations;

namespace BookStore.Server.Models.Books
{
    public class CreateBookRequestModel
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Summary { get; set; }

        [MaxLength(13)]
        public string ISBN { get; set; }

        public string? BookImage { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Range(0, 2023)]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int PageCount { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int PurchasesCount { get; set; }
    }
}
