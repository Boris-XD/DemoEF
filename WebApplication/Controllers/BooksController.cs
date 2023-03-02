using DemoEF.DBContext;
using DemoEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public BooksController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Book book)
        {            
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
