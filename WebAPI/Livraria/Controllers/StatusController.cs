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
    [Route("/status")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Status>>> GetStatus ([FromServices] DataContext context)
        {
            var staus = await context.Status.ToListAsync();

            return staus;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Status>> PostCategories(
            [FromServices] DataContext context, [FromBody] Status status)
        {
            if(ModelState.IsValid){
                context.Status.Add(status);
                await context.SaveChangesAsync();
                return status;
            }

            else
                return BadRequest(ModelState);
            
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<ActionResult<Status>> UpdateStatus([FromServices] DataContext context,
        [FromBody] Status status, int id)
        {
            var updateStatus = context.Status.FirstOrDefault(item => item.StatusId == id);

            if(updateStatus != null){
                updateStatus.Name = status.Name;
                
                context.Update(updateStatus);
                
                await context.SaveChangesAsync();
            }

            return updateStatus;
        }

    }
}