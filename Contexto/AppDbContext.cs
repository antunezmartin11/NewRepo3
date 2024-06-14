using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Persona> personas { get; set; }
    }
}
