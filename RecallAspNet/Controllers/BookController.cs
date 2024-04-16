using Microsoft.AspNetCore.Mvc;
using RecallAspNet.Models;

namespace RecallAspNet.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]    
        
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }
    }
}
