using BookStore.Server.Data;
using BookStore.Server.Data.Models;
using BookStore.Server.Data.Repositories;
using BookStore.Server.Features.Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Features.Books
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepo;

        public BookService(IRepository<Book> bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public async Task<IEnumerable<BookLisitngModel>> GetAll()
        {
            var books = await this.bookRepo.All()
                .Select(b => new BookLisitngModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Summary = b.Summary,
                    BookImage = b.BookImage,
                    Author = b.Author,
                    Price = b.Price,
                    Quantity = b.Quantity,
                })
                .ToListAsync();

            return books;
        }

        public async Task<BookDetailsModel> Details(int id)
        {
            var book = await this.bookRepo.All()
                .Where(b => b.Id == id)
                .Select(b => new BookDetailsModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    BookImage = b.BookImage,
                    Summary = b.Summary,
                    ISBN = b.ISBN,
                    Author = b.Author,
                    Year = b.Year,
                    Price = b.Price,
                    Quantity = b.Quantity,
                    PageCount = b.PageCount,
                    PurchasesCount = b.PurchasesCount,
                })
                .FirstOrDefaultAsync();

            return book;
        }


        public async Task<ActionResult<int>> Create(CreateBookModel model, string userId)
        {
            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Summary = model.Summary,
                BookImage = model.BookImage,
                ISBN = model.ISBN,
                Author = model.Author,
                Year = model.Year,
                Price = model.Price,
                Quantity = model.Quantity,
                PageCount = model.PageCount,
                PurchasesCount= model.PurchasesCount,
                UserId = userId,
            };

            this.bookRepo.Add(book);

            await this.bookRepo.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> Update(UpdateBookModel model)
        {
            var book = await this.bookRepo.All()
                .Where(b => b.Id == model.Id)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return false;
            }

            book.Title = model.Title;
            book.Description = model.Description;
            book.Summary = model.Summary;
            book.BookImage = model.BookImage;
            book.ISBN = model.ISBN;
            book.Author = model.Author;
            book.Year = model.Year;
            book.Price = model.Price;
            book.Quantity = model.Quantity;
            book.PageCount = model.PageCount;
            book.PurchasesCount = model.PurchasesCount;

            await this.bookRepo.SaveChangesAsync();

            return true;
        }

        public async Task Delete(int id)
        {
            var book = await this.bookRepo.All()
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            this.bookRepo.Delete(book);

            await this.bookRepo.SaveChangesAsync();
        }
    }
}
