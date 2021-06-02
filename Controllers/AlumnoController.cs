using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class AlumnoController:Controller
  {
    public IActionResult Index()
    {
      return View(_context.Alumnos.FirstOrDefault());
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
