using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Models;
using Livraria.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Livraria.ViewModels;
using Livraria.Services;

namespace Livraria.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly CategoryService categoryService;

        public CategoryController(IMapper mapper, CategoryService categoryService){
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<CategoryViewModel>>> GetCategories ([FromServices] DataContext context)
        {
            var categories = await categoryService.ListCategory();

            var categoryViewModel = mapper.Map<List<CategoryViewModel>>(categories);
            
            return Ok(categoryViewModel);
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Category>> PostCategories(
            [FromServices] DataContext context, [FromBody] Category category)
        {
            if(ModelState.IsValid){
                return await categoryService.CreateCategory(category);
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
            return await categoryService.UpdateCategory(category, id);     
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        [Authorize(Roles = "root")]
        public async Task<ActionResult<Category>> DeleteCategory ([FromServices] DataContext context, int id)
        {
            return await categoryService.DeleteCategory(id);
        }
    }
}