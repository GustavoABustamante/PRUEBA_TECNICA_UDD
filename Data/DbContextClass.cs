using Microsoft.EntityFrameworkCore;
using PRUEBA_TECNICA_UDD.Models;

namespace PRUEBA_TECNICA_UDD.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        public DbSet<Persona>? Personas { get; set; }
    }
}
