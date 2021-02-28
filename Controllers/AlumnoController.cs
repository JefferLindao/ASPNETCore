using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class AlumnoController:Controller
  {
    public IActionResult Index(){
      return View(new Alumno{
        Nombre="Jefferson Lindao",
        UniqueId = Guid.NewGuid().ToString()
      });
    }
    public IActionResult MultiplesAlumno()
    {
      var listaAlumno = GenerarAlumnoAlAzar();

      ViewBag.CositaDinamica = "La Monja";
      ViewBag.Fecha = DateTime.Now;
      return View("MultiplesAlumno",listaAlumno);
    }
    private List<Alumno> GenerarAlumnoAlAzar()
    {
      string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
      string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
      string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };
      var listaAlumno = from n1 in nombre1
                        from n2 in nombre2
                        from a1 in apellido1
                        select new Alumno { Nombre = $"{n1} {n2} {a1}" };
      return listaAlumno.OrderBy((al)=>al.UniqueId).ToList();
    }
  }
}
