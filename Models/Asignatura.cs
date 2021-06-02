using System;
using System.Collections.Generic;

namespace PlatziASPNETCore.Models
{
  public class Asignatura : ObjetoEscuelaBase
  {
    public string CursoId { get; set; }
    public Curso Curso { get; set; }
    public List<Evaluacion> Evaluaciones { get; set; }
  }
}
