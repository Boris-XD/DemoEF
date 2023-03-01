using DemoEF.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEF.DBContext
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        
        public DbSet<Autor> Autores { get; set; } 
    }
}
