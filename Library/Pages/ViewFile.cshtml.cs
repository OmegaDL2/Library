using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Books
{
    public class ViewFileModel : PageModel
    {

        [BindProperty]
        public string id { get; set; }


        public IActionResult OnGet(string? id) {
            if (id == null) {
                return NotFound();
            }

            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", id);
            //return File(System.IO.File.OpenRead(filePath), "application/pdf", id);

            string physicalPath = Path.Combine("/var/www", "Uploads", id);
            byte[] pdfBytes = System.IO.File.ReadAllBytes(physicalPath);
            MemoryStream ms = new MemoryStream(pdfBytes);
            return new FileStreamResult(ms, "application/pdf");
            


        }









    }
}
