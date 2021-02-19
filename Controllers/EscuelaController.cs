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
      escuela.AñoFundacion = 2005;
      escuela.EscuelaId = Guid.NewGuid().ToString();
      escuela.Nombre = "Platzi School";
      ViewBag.CosaDinamica = "La Monja";
      return View(escuela);
    }
  }
}
