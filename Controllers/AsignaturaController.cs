using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class AsignaturaController:Controller
  {
    public IActionResult Index()
    {
      return View(_context.Asignaturas.FirstOrDefault());
    }
    public IActionResult MultiplesAsignatura()
    {
      ViewBag.CosaDinamica = "La Monja";
      ViewBag.Fecha = DateTime.Now;
      return View("MultiplesAsignatura", _context.Asignaturas);
    }
    private EscuelaContext _context;
    public AsignaturaController(EscuelaContext context)
    {
      _context = context;
    }
  }
}
