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


        /* Variables de Ruta */
        [HttpGet("{id:int}")]  //       api/autores/valorId  https://localhost:7262/api/autores/1
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var result = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if(result == null) 
            {
                return NotFound("No encontrado");
            }
            return result;
        }

        /* Variables de Ruta */
        [HttpGet("{id:int}/{param=default}")]
        public async Task<ActionResult<Autor>> Get(int id, string param)
        {
            var result = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id && x.Name.Contains(param));
            if(result == null)
            {
                return NotFound();
            }
            return result;

        }

        /* Variables de Ruta */
        [HttpGet("{id:int}/nombre")]  //  Ruta api/autores/1/nombre?nums=myValue&vals=myValue
        public async Task<ActionResult<Autor>> Get(int id, string nums, string vals)
        {
            var result = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id && x.Name.Contains(nums));
            if (result == null)
            {
                return NotFound();
            }

            return result;

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
