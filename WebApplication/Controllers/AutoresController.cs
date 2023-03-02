using Microsoft.AspNetCore.Mvc;
using DemoEF.Models;
using DemoEF.DBContext;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.Controllers
{
    [ApiController]
    [Route("api/autores")] //   podria llamarse al controlador => [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            this._context = context;
        }


        [HttpGet]                   //  api/autores/
        [HttpGet("listado")]        //  api/autores/listado
        [HttpGet("/listado")]       //  /listado
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await _context.Autores.ToListAsync();
        }
        
        [HttpGet("primer")] //    api/autores/primer
        public async Task<ActionResult<Autor>> GetFirstAutor()
        {
            return await _context.Autores.FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Autor>> Post([FromBody] Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return Ok(autor);
        }

        [HttpPut("{id:int}")] //api/autores/1
        public async Task<ActionResult> Put(int id, [FromBody] Autor autor)
        {
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            _context.Update(autor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Autores.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            _context.Remove(new Autor() { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
