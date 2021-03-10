using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class EscuelaController:Controller
  {
    private EscuelaContext _context;
    public IActionResult Index()
    {
      ViewBag.CosaDinamica = "La Monja";
      var escuela = _context.Escuelas.FirstOrDefault();
      return View(escuela);
    }

    public EscuelaController(EscuelaContext context)
    {
      _context = context;
    }
  }
}
