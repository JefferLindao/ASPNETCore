using System;
using System.Collections.Generic;

namespace PlatziASPNETCore.Models
{
  public class Alumno : ObjetoEsculaBase
  {
    public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
  }
}
