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
    public IActionResult Create()
    {
      ViewBag.Fecha = DateTime.Now;
      return View();
    }
    [HttpPost]
    public IActionResult Create(Curso curso)
    {
      ViewBag.Fecha = DateTime.Now;
      if(ModelState.IsValid){
        var escuela = _context.Escuelas.FirstOrDefault();
        curso.EscuelaId = escuela.Id;
        _context.Cursos.Add(curso);
        _context.SaveChanges();
        ViewBag.MensajeExtra = "Curso creado exitosamente.";
        return View("Index", curso);
      }
      else
      {
        return View(curso);
      }
      
    }
    private EscuelaContext _context;
    public CursoController(EscuelaContext context)
    {
      _context = context;
    }
  }
}
