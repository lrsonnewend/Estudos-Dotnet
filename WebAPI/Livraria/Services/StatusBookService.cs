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
    public class StatusBookService
    {
        private readonly DataContext context;

        public StatusBookService (DataContext context){
            this.context = context;
        }

        public async Task<List<StatusBook>> ListStatusBook(){
            return await context.StatusBooks
                        .Include(s => s.Status)
                        .Include(b => b.Book)
                        .ThenInclude(c => c.Category)
                        .ToListAsync();
        }

        public async Task<StatusBook> CreateStatusBook(StatusBook statusBook){
            context.StatusBooks.Add(statusBook);
            
            await context.SaveChangesAsync();

            return statusBook;
        }

        public async Task<StatusBook> UpdateStatusBook(StatusBook statusBook, int id){
            var update = context.StatusBooks.FirstOrDefault(s => s.StatusBookId == id);

            if(update != null){
                update.BookId = statusBook.BookId;
                update.StatusId = statusBook.StatusId;
                context.Update(update);
                await context.SaveChangesAsync();
            }

            return update;
        }

        public async Task<List<StatusBook>> GetStatusBoodById(int id){
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