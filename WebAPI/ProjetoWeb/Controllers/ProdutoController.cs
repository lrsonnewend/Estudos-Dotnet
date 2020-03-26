using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using ProjetoWeb.Data;
using System.Linq;

namespace ProjetoWeb.Controllers
{
    [ApiController]
    [Route("/produtos")]
    public class ProdutoController : ControllerBase
    {
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context){
            
            var produtos = await context.Produtos.Include(c => c.Categoria).ToListAsync();

            return produtos;

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Produto>> GetById([FromServices] DataContext context, int id)
        {
            var produtos = await context.Produtos
            .Include(c => c.Categoria)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CategoriaId == id);
            return produtos;
        }

        [HttpGet]
        [Route("cat/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetByCat ([FromServices]DataContext context, int id){
            var produtos = await context.Produtos
            .Include(c => c.Categoria)
            .AsNoTracking()
            .Where(c => c.CategoriaId == id)
            .ToListAsync();

            return produtos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context, [FromBody] Produto model){
                
            if(ModelState.IsValid){
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }

            else{
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<ActionResult<Produto>> Delete ([FromServices] DataContext context, int id){
            var produto = await context.Produtos.FindAsync(id);
            
            context.Produtos.Remove(produto);
            
            await context.SaveChangesAsync();
            
            return produto;
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<ActionResult<Produto>> Update(
            [FromServices] DataContext context, int id, 
            [FromBody] Produto model)
        {
            if(model.ProdutoId != id ){
                return NotFound();
            }

            if(ModelState.IsValid){
                context.Update(model);
                await context.SaveChangesAsync();
            }

            return model;
        }
            
    }
}