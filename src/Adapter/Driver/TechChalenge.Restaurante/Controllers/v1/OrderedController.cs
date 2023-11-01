using Application.Dtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TechChalenge.Restaurante.Controllers.v1
{
    [Route("v1/api/order")]
    [ApiController]
    public class OrderedController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderedController> _logger;

        public OrderedController(IOrderService orderService, ILogger<OrderedController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListOrders()
        {
            try
            {
                var orders = _orderService.GetAll();

                if (orders is null)
                {
                    return NoContent();
                }

                return Ok(orders);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateOrder(OrderDtoInput order)
        {
            try
            {
                var id = _orderService.CreateOrder(order);
                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
