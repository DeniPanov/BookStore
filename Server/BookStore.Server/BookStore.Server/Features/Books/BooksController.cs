using BookStore.Server.Controllers;
using BookStore.Server.Features.Books.Models;
using BookStore.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Features.Books
{
    [Authorize]
    public class BooksController : ApiController
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create(CreateBookRequestModel model)
        {
            var userId = User.GetId();

            var bookId = await this.bookService.Create(model, userId);

            return Created(nameof(this.Create), bookId);
        }
    }
}