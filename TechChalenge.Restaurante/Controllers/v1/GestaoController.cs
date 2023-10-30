using Microsoft.AspNetCore.Mvc;

namespace TechChalenge.Restaurante.Controllers.v1
{
    public class GestaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
