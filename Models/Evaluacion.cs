using System;

namespace PlatziASPNETCore.Models
{
  public class Evaluacion : ObjetoEsculaBase
  {
    public Alumno Alumno { get; set; }
    public Asignatura Asignatura { get; set; }
    public float Nota { get; set; }

    public override string ToString()
    {
      return $"{Nota},{Alumno.Nombre},{Asignatura.Nombre}";
    }
  }
}
