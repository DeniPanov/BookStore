using System.ComponentModel.DataAnnotations;

namespace BookStore.Server.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

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

        public string BookImage { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Range(0, 2023)]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MinLength(1)]
        public int PageCount { get; set; }

        [Required]
        public int Quantity { get; set; }

        [MinLength(0)]
        public int PurchasesCount { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
