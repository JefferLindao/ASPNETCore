using System;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class EscuelaController:Controller
  {
    public IActionResult Index()
    {
      var escuela = new Escuela();
      escuela.AñoDeCreacion = 2005;
      escuela.UniqueId = Guid.NewGuid().ToString();
      escuela.Nombre = "Platzi School";
      escuela.Ciudad = "Bogata";
      escuela.Pais = "Colombia";
      escuela.Direccion = "Av. Rosales";
      escuela.TipoEscuela = TiposEscuela.Segundaria;
      ViewBag.CosaDinamica = "La Monja";
      return View(escuela);
    }
  }
}
