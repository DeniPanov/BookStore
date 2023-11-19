using BookStore.Server.Data;
using BookStore.Server.Data.Models;
using BookStore.Server.Infrastructure.Extensions;
using BookStore.Server.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    public class BooksController : ApiController
    {
        private readonly BookStoreDbContext db;

        public BooksController(BookStoreDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create(CreateBookRequestModel model)
        {
            var userId = this.User.GetId();

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

            this.db.Add(book);

            await this.db.SaveChangesAsync();

            return Created(nameof(this.Create), book.Id); 
        }
    }
}