using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;
using Livraria.Data;
using System.Linq;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Book>>> GetBooks([FromServices] DataContext context){
            var books = await context.Books
            .Include(c => c.Category)
            .ToListAsync();
            return books;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Book>> PostBooks([FromServices] DataContext context,
        [FromBody] Book book)
        {
            if(ModelState.IsValid){
                context.Books.Add(book);
                await context.SaveChangesAsync();
                return book;
            }

            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<Book>> DeleteBooks([FromServices] DataContext context, int id)
        {
            var book = await context.Books.FindAsync(id);

            context.Books.Remove(book);
            
            await context.SaveChangesAsync();

            return book;
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<ActionResult<Book>> UpdateBooks([FromServices] DataContext context,
        [FromBody] Book book, int id)
        {
            var updateBook = context.Books.FirstOrDefault(item => item.BookId == id);

            if(updateBook != null){
                updateBook.Author = book.Author;
                updateBook.CategoryId = book.CategoryId;
                updateBook.Title = book.Title;
                updateBook.Price = book.Price;
                context.Update(updateBook);
                await context.SaveChangesAsync();
            }

            return updateBook;
            
        }

        [HttpGet]
        [Route("cat/{id:int}")]
        public async Task<ActionResult<List<Book>>> GetBooksByCat([FromServices] DataContext context, int id)
        {
            var books = await context.Books
            .Include(c => c.Category)
            .AsNoTracking()
            .Where(c => c.CategoryId == id)
            .ToListAsync();

            return books;
        }
    }
}
