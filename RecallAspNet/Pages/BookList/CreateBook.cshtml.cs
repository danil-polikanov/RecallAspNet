using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecallAspNet.Models;

namespace RecallAspNet.Pages.BookList
{
    public class CreateBookModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateBookModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Book Book { get; set; }
        public void OnGet()
        {    
        }
    }
}
