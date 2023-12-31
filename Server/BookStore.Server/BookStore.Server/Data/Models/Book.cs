﻿using System.ComponentModel.DataAnnotations;

using static BookStore.Server.Data.Models.ValidationConstants.Book;

namespace BookStore.Server.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(SummaryMaxLength)]
        public string Summary { get; set; }

        [MaxLength(ISBNMaxLength)]
        public string ISBN { get; set; }

        public string? BookImage { get; set; }

        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; }

        [Range(MinYear, MaxYear)]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int PageCount { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int PurchasesCount { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
