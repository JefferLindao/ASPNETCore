using Microsoft.AspNetCore.Mvc;

namespace PlatziASPNETCore.Controllers
{
  public class EscuelaController:Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
