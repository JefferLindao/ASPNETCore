using System;
using System.Linq;
using System.Collections.Generic;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var escuela = new Escuela();
      escuela.AñoDeCreacion = 2005;
      escuela.Id = Guid.NewGuid().ToString();
      escuela.Nombre = "Platzi School";
      escuela.Ciudad = "Bogota";
      escuela.Pais = "Colombia";
      escuela.Direccion = "Av. las Americas";
      escuela.TipoEscuela = TiposEscuela.Segundaria;

      //modelBuilder.Entity<Escuela>().HasData(escuela);

      // Cargar Cursos de la Escuela
      var cursos = CargarCursos(escuela);

      // Cargar curso de la asignatura
      var asignaturas = CargarAsignaturas(cursos);

      // Cargar curso de la Asignatura
      var alumnos = CargarAlumnos(cursos);

      modelBuilder.Entity<Escuela>().HasData(escuela);
      modelBuilder.Entity<Curso>().HasData(cursos.ToArray());
      modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());
      modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());

    }

    private List<Alumno> CargarAlumnos(List<Curso> cursos)
    {
      var listaAlumno = new List<Alumno>();

      Random rnd = new Random();
      foreach (var curso in cursos)
      {
        int cantRandom = rnd.Next(5, 20);
        var tmplist = GenerarAlumnoAlAzar(curso, cantRandom);
        listaAlumno.AddRange(tmplist);
      }
      return listaAlumno;
    }

    private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
    {
      var listaCompleta = new List<Asignatura>();
      foreach (var curso in cursos)
      {
        var tmplist = new List<Asignatura>(){
          new Asignatura{
            Id = Guid.NewGuid().ToString(),
            CursoId = curso.Id,
            Nombre = "Matemeticas"
          },
          new Asignatura{
            Id = Guid.NewGuid().ToString(),
            CursoId = curso.Id,
            Nombre = "Educacion Física"
          },
          new Asignatura{
            Id = Guid.NewGuid().ToString(),
            CursoId = curso.Id,
            Nombre = "Castellano"
          },
          new Asignatura{
            Id = Guid.NewGuid().ToString(),
            CursoId = curso.Id,
            Nombre = "Ciencias Naturales"
          },
          new Asignatura{
            Id = Guid.NewGuid().ToString(),
            CursoId = curso.Id,
            Nombre = "Programacion"
          }
        };
        listaCompleta.AddRange(tmplist);
        //curso.Asignaturas = tmplist;
      }
      return listaCompleta;
    }

    private static List<Curso> CargarCursos(Escuela escuela)
    {
      return new List<Curso>(){
        new Curso() {
          Id = Guid.NewGuid().ToString(),
          EscuelaId = escuela.Id,
          Nombre = "101",
          Jornada = TiposJornada.Mañana
        },
        new Curso() {
          Id = Guid.NewGuid().ToString(),
          EscuelaId = escuela.Id,
          Nombre = "201",
          Jornada = TiposJornada.Mañana
        },
        new Curso() {
          Id = Guid.NewGuid().ToString(),
          EscuelaId = escuela.Id,
          Nombre = "301",
          Jornada = TiposJornada.Tarde
        },
        new Curso() {
          Id = Guid.NewGuid().ToString(),
          EscuelaId = escuela.Id,
          Nombre = "401",
          Jornada = TiposJornada.Tarde
        },
        new Curso() {
          Id = Guid.NewGuid().ToString(),
          EscuelaId = escuela.Id,
          Nombre = "201",
          Jornada = TiposJornada.Noche
        }
      };
    }

    private List<Alumno> GenerarAlumnoAlAzar(Curso curso, int cantidad)
    {
      string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
      string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
      string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
      var listaAlumno = from n1 in nombre1
                        from n2 in nombre2
                        from a1 in apellido1
                        select new Alumno 
                        { 
                          CursoId = curso.Id,
                          Nombre = $"{n1} {n2} {a1}",
                          Id = Guid.NewGuid().ToString()
                        };
      return listaAlumno.OrderBy((al)=>al.Id).Take(cantidad).ToList();
    }
  }
}
