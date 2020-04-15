using Microsoft.EntityFrameworkCore;
using Livraria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Livraria.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<StatusBook> StatusBooks { get; set; }
    }




}