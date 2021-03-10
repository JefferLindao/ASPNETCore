using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class AsignaturaController:Controller
  {
    public IActionResult Index()
    {
      var listaAsignatura = new List<Asignatura>()
      {
        new Asignatura{Nombre = "Matemeticas",
          Id = Guid.NewGuid().ToString()},
        new Asignatura{Nombre = "Edicacion Fisica",
          Id = Guid.NewGuid().ToString()},
        new Asignatura{Nombre = "Castellano",
          Id = Guid.NewGuid().ToString()},
        new Asignatura{Nombre = "Programacion",
          Id = Guid.NewGuid().ToString()}
      };

      ViewBag.CositaDinamica = "La Monja";
      ViewBag.Fecha = DateTime.Now;
      return View("MultiplesAsignatura",listaAsignatura);
    }
  }
}
