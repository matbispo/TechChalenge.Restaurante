using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TechChalenge.Restaurante.Controllers.v1
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult ListOrders()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            return Ok();
        }
    }
}
