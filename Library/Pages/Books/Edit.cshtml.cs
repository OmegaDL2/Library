using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly Library.Data.ApplicationDbContext _context;

        public EditModel(Library.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IFormFile? Upload { get; set; }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book =  await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                Upload.CopyTo(stream);  // Execute the file copy


                Book.file = fileName; // write the file name to the DataBase
            }


            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
