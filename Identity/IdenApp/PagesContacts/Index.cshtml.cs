using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdenApp.Data;
using IdenApp.Models;

namespace IdenApp.PagesContacts
{
    public class IndexModel : PageModel
    {
        private readonly IdenApp.Data.ApplicationDbContext _context;

        public IndexModel(IdenApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.Contacts.ToListAsync();
        }
    }
}
