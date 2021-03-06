using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class AlumnoController:Controller
  {
    public IActionResult Index(string id)
    {
      if (!string.IsNullOrEmpty(id))
      {
        var alumno = from alum in _context.Alumnos
                       where alum.Id == id
                       select alum;
        return View(alumno.SingleOrDefault()); 
      }
      else
      {
        return View("MultiplesAlumno", _context.Alumnos);
      }
    }
    public IActionResult MultiplesAlumno()
    {
      ViewBag.CositaDinamica = "La Monja";
      ViewBag.Fecha = DateTime.Now;
      return View("MultiplesAlumno", _context.Alumnos);
    }
    private EscuelaContext _context;
    public AlumnoController(EscuelaContext context)
    {
      _context = context;
    }
  }
}
