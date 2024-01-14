using Application.Presenters.Dtos;
using Application.UseCases.Order.CreateOrder;
using Application.UseCases.Order.GetAllOrders;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChalenge.Restaurante.Controllers.v1
{
    [Route("v1/api/order")]
    [ApiController]
    public class OrderController : Controller
    {
    //    private readonly IGetAllOrdersUseCase _getAllOrdersUseCase;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IGetAllOrdersUseCase getAllOrdersUseCase, ILogger<OrderController> logger)
        {
        //    _getAllOrdersUseCase = getAllOrdersUseCase;
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
        public IActionResult ListOrders([FromServices] IGetAllOrdersUseCase _getAllOrdersUseCase)
        {
            try
            {
                var orders = _getAllOrdersUseCase.GetAll();

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
        public IActionResult CreateOrder([FromServices] ICreateOrderUseCase _createOrderUseCase, OrderDtoInput order)
        {
            try
            {
                var id = _createOrderUseCase.CreateOrder(order);
                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
