using BookStore.Server.Features.Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Features.Books
{
    public interface IBookService
    {
        Task<IEnumerable<BookLisitngModel>> GetAll();

        Task<BookDetailsModel> Details(int id);

        Task<ActionResult<int>> Create(CreateBookModel model, string userId);

        Task<bool> Update(UpdateBookModel model);

        Task Delete(int id);
    }
}
