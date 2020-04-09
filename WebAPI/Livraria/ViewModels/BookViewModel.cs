using System.ComponentModel.DataAnnotations;
using Livraria.Models;

namespace Livraria.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}