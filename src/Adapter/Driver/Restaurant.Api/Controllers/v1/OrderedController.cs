using Application.Presenters.Dtos;
using Application.UseCases.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IList<OrderedDtoOutput>))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
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

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(string))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
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
