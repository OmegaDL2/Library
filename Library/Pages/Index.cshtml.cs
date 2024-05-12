using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Library.Data.ApplicationDbContext _context;

        public IndexModel(Library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet = true)] // Enllaça el camp de cerca amb les cadenes de consulta
        public string SearchString { get; set; } //Conté el text per fer la cerca


        public async Task OnGetAsync()
        {
            var books = from m in _context.Book select m;

            if (!string.IsNullOrEmpty(SearchString)) {
                books = books.Where(s => s.Title.Contains(SearchString));
            }


            Book = await books.ToListAsync();
        }
    }
}
