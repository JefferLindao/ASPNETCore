using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlatziASPNETCore.Models;

namespace PlatziASPNETCore.Controllers
{
  public class CursoController:Controller
  {
    public IActionResult Index(string id)
    {
      if (!string.IsNullOrEmpty(id))
      {
        var curso = from curs in _context.Cursos
                       where curs.Id == id
                       select curs;
        return View(curso.SingleOrDefault()); 
      }
      else
      {
        return View("MultiplesCursos", _context.Cursos);
      }
    }
    public IActionResult MultiplesCursos()
    {
      ViewBag.CositaDinamica = "La Monja";
      ViewBag.Fecha = DateTime.Now;
      return View("MultiplesCursos", _context.Cursos);
    }
    private EscuelaContext _context;
    public CursoController(EscuelaContext context)
    {
      _context = context;
    }
  }
}
