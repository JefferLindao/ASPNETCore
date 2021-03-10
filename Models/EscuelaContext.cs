using Microsoft.EntityFrameworkCore;

namespace PlatziASPNETCore.Models
{
  public class EscuelaContext: DbContext
  {
    public DbSet<Escuela> Escuelas { get; set; }
    public DbSet<Asignatura> Asignaturas { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Evaluacion> Evaluaciones { get; set; }
    public EscuelaContext(DbContextOptions<EscuelaContext> options): base(options)
    {
      
    }
  }
}
