using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using ProjetoWeb.Data;

namespace ProjetoWeb.Controllers
{
    [ApiController]
    [Route("/categorias")]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context, [FromBody] Categoria model){
                
            if(ModelState.IsValid){
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            else{
                return BadRequest(ModelState);
            }
        }
    }
}