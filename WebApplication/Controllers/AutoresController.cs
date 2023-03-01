using Microsoft.AspNetCore.Mvc;
using DemoEF.Models;

namespace DemoEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            return new List<Autor>()
            {
                new Autor()
                {
                    Id = 1,
                    Name = "Test",
                },
                new Autor()
                {
                    Id = 2,
                    Name = "Test 2",
                }
            };
        }
    }
}
