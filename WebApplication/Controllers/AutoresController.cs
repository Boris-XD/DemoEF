using Microsoft.AspNetCore.Mvc;
using DemoEF.Models;
using DemoEF.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await _context.Autores.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Autor>> Post([FromBody] Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return Ok(autor);
        }

    }
}
