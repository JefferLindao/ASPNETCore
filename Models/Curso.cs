using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlatziASPNETCore.Models
{
  public class Curso : ObjetoEscuelaBase
  {
    [Required(ErrorMessage ="El nombre del curso es requerido")]
    [StringLength(5)]
    public override string Nombre { get; set; }
    public TiposJornada Jornada { get; set; }
    public List<Asignatura> Asignaturas { get; set; }
    public List<Alumno> Alumnos { get; set; }
    [Display(Prompt ="Direccion correspondencia", Name ="Address")]
    [Required(ErrorMessage ="Se requiere incluir una dirección")]
    [MinLength(10, ErrorMessage="La longitud minima de la dirección es 10")]
    public string Direccion { get; set; }
    public string EscuelaId { get; set; }
    public Escuela Escuela { get; set; }
  }
}
