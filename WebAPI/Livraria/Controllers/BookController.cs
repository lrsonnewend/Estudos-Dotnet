using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;
using Livraria.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Livraria.ViewModels;
using Livraria.Services;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/book")]
    public class BookController : ControllerBase
    {
        private readonly IMapper mapper;
        private  readonly BookService bookService;
    
        public BookController(IMapper mapper, BookService bookService){
            this.mapper = mapper;
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<BookViewModel>>> GetBooks([FromServices] DataContext context){

            var books = await bookService.ListBooks();

            var bookViewModel = mapper.Map<List<BookViewModel>>(books);
            
            return Ok(bookViewModel);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Book>> PostBooks([FromServices] DataContext context,
        [FromBody] Book book)
        {
            if(ModelState.IsValid){
               return await bookService.CreateBook(book);
            }

            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Book>> DeleteBooks([FromServices] DataContext context, int id)
        {
            var book = await bookService.DeleteBook(id);

            return book;
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Book>> UpdateBooks([FromServices] DataContext context,
        [FromBody] Book book, int id)
        {
            var updateBook = await bookService.UpdateBook(book, id);

            return updateBook;
        }

        [HttpGet]
        [Route("cat/{id:int}")]
        public async Task<ActionResult<List<Book>>> GetBooksByCat([FromServices] DataContext context, int id)
        {
            var books = await bookService.GetByCategory(id);

            return books;
        }
    }
}
