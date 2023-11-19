using BookStore.Server.Features.Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Features.Books
{
    public interface IBookService
    {
        Task<ActionResult<int>> Create(CreateBookRequestModel model, string userId);
    }
}
