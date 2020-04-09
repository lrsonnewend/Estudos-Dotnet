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
    public  class BookService
    {
        private readonly DataContext context;

        public BookService(DataContext context){
            this.context = context;
        }

        public async Task<List<Book>> ListBooks(){
            return await context.Books.Include(c => c.Category).ToListAsync();
        }

        public async Task<Book> CreateBook(Book book){    
            context.Add(book);
                        
            await context.SaveChangesAsync();
            
            return book;
        }

        public async Task<Book> UpdateBook(Book book, int bookId){
            var update = context.Books.FirstOrDefault(b => b.BookId == bookId);

            if(update != null){
                update.Author = book.Author;
                update.Title = book.Title;
                update.Price = book.Price;
                update.CategoryId = book.CategoryId;
                context.Update(update);
                await context.SaveChangesAsync();
            }

            return update;
        }

        public async Task<Book> DeleteBook (int bookId){
            var delete = await context.Books.FindAsync(bookId);

            context.Books.Remove(delete);

            await context.SaveChangesAsync();

            return delete;
        }

        public async Task<List<Book>> GetByCategory(int idCategory){
            var booksByCat = await context.Books
                        .Include(c => c.Category)
                        .AsNoTracking()
                        .Where(c => c.CategoryId == idCategory)
                        .ToListAsync();
            
            return booksByCat;
        }
    }
}