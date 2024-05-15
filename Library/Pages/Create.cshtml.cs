using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Data;
using Library.Models;
using Microsoft.Extensions.Hosting;

namespace Library.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Library.Data.ApplicationDbContext _context;

        public CreateModel(Library.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IFormFile? Upload { get; set; }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {             
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!(Upload == null)) {               
                // File Upload
                string extention = Path.GetExtension(Upload.FileName);
                string fileName = Guid.NewGuid().ToString() + extention;  // Chnage name of file to a Guid
                string path = Path.Combine("/var/www", "Uploads");
                using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                Upload.CopyTo(stream);  // Execute the file copy


                Book.file = fileName; // write the file name to the DataBase
            }
            



            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index"); 
        }
    }
}
