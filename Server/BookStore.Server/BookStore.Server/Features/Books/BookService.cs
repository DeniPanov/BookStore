using BookStore.Server.Data;
using BookStore.Server.Data.Models;
using BookStore.Server.Data.Repositories;
using BookStore.Server.Features.Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Features.Books
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepo;

        public BookService(IRepository<Book> bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public async Task<ActionResult<int>> Create(CreateBookRequestModel model, string userId)
        {
            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Summary = model.Summary,
                ISBN = model.ISBN,
                Author = model.Author,
                Year = model.Year,
                Price = model.Price,
                Quantity = model.Quantity,
                UserId = userId,
            };

            this.bookRepo.Add(book);

            await this.bookRepo.SaveAsync();

            return book.Id;
        }
    }
}
