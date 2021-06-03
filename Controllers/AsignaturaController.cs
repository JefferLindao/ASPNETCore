using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class AsignaturaController:Controller
  {
    [Route("Asignatura/Index")]
    [Route("Asignatura/Index/{asignaturaId}")]
    public IActionResult Index(string asignaturaId)
    {
      if (!string.IsNullOrEmpty(asignaturaId))
      {
        var asignatura = from asig in _context.Asignaturas
                       where asig.Id == asignaturaId
                       select asig;
        return View(asignatura.SingleOrDefault()); 
      }
      else
      {
        return View("MultiplesAsignatura", _context.Asignaturas);
      }
      
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
