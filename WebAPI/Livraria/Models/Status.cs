using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string Name { get; set; }
        
    }
}