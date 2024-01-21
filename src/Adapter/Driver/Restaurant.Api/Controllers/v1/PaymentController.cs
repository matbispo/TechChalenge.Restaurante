using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Api.Controllers.v1
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
