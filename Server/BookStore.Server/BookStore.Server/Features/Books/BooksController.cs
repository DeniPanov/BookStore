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

        [HttpGet]
        public async Task<IEnumerable<BookLisitngModel>> GetAll()
        {
            var result = await this.bookService.GetAll();

            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BookDetailsModel>> Details(int id)
        {
            var result = await this.bookService.Details(id);

            return result;
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBookModel model)
        {
            var userId = this.User.GetId();

            var bookId = await this.bookService.Create(model, userId);

            return Created(nameof(this.Create), bookId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateBookModel model)
        {
            var result = await this.bookService.Update(model);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.bookService.Delete(id);

            return Ok();
        }
    }
}