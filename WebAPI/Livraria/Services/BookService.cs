using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Livraria.Models;
using Livraria.Data;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Services
{
    public  class BookService
    {
        private readonly DataContext context;

        public BookService(DataContext context){
            this.context = context;
        }

        public IEnumerable<Book> GetBooks(){
            return context.Books.ToList<Book>();
        }
    }
}