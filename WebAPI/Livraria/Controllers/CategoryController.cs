using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;
using Livraria.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> GetCategories ([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Category>> PostCategories(
            [FromServices] DataContext context, [FromBody] Category category)
        {
            if(ModelState.IsValid){
                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return category;
            }

            else
                return BadRequest(ModelState);
            
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Category>> UpdateCategories([FromServices] DataContext context,
        [FromBody] Category category, int id)
        {
            var updateCat = context.Categories.FirstOrDefault(item => item.CategoryId == id);

            if(updateCat != null){
                updateCat.Name = category.Name;
                context.Update(updateCat);
                await context.SaveChangesAsync();
            }

            return updateCat;     
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Category>> DeleteCategory ([FromServices] DataContext context, int id)
        {
            var category = context.Books.FirstOrDefault(c => c.CategoryId == id);

            if(category != null){
                return Content("Esta categoria contém livros cadastrados!");
            }

            var delCategory = await context.Categories.FindAsync(id);

            context.Categories.Remove(delCategory);
        
            await context.SaveChangesAsync();

            return delCategory;
        }
    }
}