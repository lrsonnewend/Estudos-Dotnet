using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Livraria.Models;
using Livraria.Data;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Livraria.ViewModels;

namespace Livraria.Services
{
    public class CategoryService
    {
        private readonly DataContext context;

        public CategoryService(DataContext context){
            this.context = context;
        }

        public async Task<List<Category>> ListCategory(){
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> CreateCategory(Category category){
            context.Add(category);

            await context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateCategory(Category category, int idCategory){
            var update = context.Categories.FirstOrDefault(c => c.CategoryId == idCategory);

            if(update != null){
                update.Name = category.Name;
                context.Update(update);
                await context.SaveChangesAsync();
            }

            return update;
        }

        public async Task<Category> DeleteCategory(int idCategory){
            var verifica = context.Books.FirstOrDefault(c => c.CategoryId == idCategory);

            if(verifica != null){
                throw new ArgumentException("Esta categoria contém livros cadastrados.");
            }

            var searchCat = await context.Categories.FindAsync(idCategory);
            
            context.Categories.Remove(searchCat);

            await context.SaveChangesAsync();

            return searchCat;
        }
    }
}