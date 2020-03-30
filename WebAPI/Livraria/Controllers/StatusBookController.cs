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
    [Route("/statusbook")]
    public class StatusBookController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<StatusBook>>> GetStatusBook([FromServices] DataContext context)
        {
            var statusBook = await context.StatusBooks.Include(s => s.Status).Include(b => b.Book).ToListAsync();

            return statusBook;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<StatusBook>> PostCategories(
            [FromServices] DataContext context, [FromBody] StatusBook model)
        {
            if (ModelState.IsValid)
            {
                context.StatusBooks.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            else
                return BadRequest(ModelState);

        }

        [HttpPut]
        [Route("change/{id:int}")]
        public async Task<ActionResult<StatusBook>> UpdateStatusBook(
            [FromServices] DataContext context, [FromBody] StatusBook model, int id)
        {
            var UpdateStatusBook = context.StatusBooks.FirstOrDefault(s => s.StatusBookId == id);

            if (UpdateStatusBook != null){
                UpdateStatusBook.BookId = model.BookId;
                UpdateStatusBook.StatusId = model.StatusId;
                context.Update(UpdateStatusBook);
                await context.SaveChangesAsync();
            }

            return UpdateStatusBook;           

        }

        [HttpGet]
        [Route("st/{id:int}")]
        public async Task<ActionResult<List<StatusBook>>> GetStatusById([FromServices] DataContext context, int id)
        {
            var statusBook = await context.StatusBooks
            .Include(b => b.Book).ThenInclude(c => c.Category)
            .Include(s => s.Status)
            .AsNoTracking()
            .Where(s => s.StatusId == id)
            .ToListAsync();

            return statusBook;
        }
    }
}
