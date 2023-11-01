using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TechChalenge.Restaurante.Controllers.v1
{
    [Route("v1/api/order")]
    [ApiController]
    public class OrderedController : Controller
    {
        [HttpGet]
        public IActionResult ListOrders()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateOrder(Ordered order)
        {
            return Ok();
        }
    }
}
