using Microsoft.EntityFrameworkCore;
using ExamenFinalProgra3.Models;

namespace ExamenFinalProgra3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<AsignacionDeProyecto> Asignaciones { get; set; }
    }
}
