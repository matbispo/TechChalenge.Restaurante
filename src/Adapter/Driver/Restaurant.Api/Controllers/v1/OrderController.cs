using Application.Presenters.Dtos;
using Application.UseCases.Order.CreateOrder;
using Application.UseCases.Order.GetAllOrders;
using Application.UseCases.Order.UpdatePaymentOrderStatus;
using Domain.Entities;
using Domain.ValueObjects;
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
            catch (Exception ex)
            {
                return Problem(detail: "Erro ao consultar os pedidos. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
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
            catch (Exception ex)
            {
                return Problem(detail: "Erro ao cadastrar novo pedido. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpPut("{orderId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Product))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateOrderStatus([FromServices] IUpdateOrderStatusUseCase updateOrderStatusUseCase, string orderId, OrderStatus orderStatus)
        {
            try
            {
                updateOrderStatusUseCase.Execute(orderId, orderStatus);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao atualizar o status do pedido: {orderId}");
                return Problem(detail: "Erro ao atualizar o status do pedido. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpGet]
        public IActionResult GetOrderPaymentStatus([FromServices] IGetOrderPaymentStatusUseCase getOrderPaymentStatusUseCase, string orderId)
        {
            try
            {
                var status = getOrderPaymentStatusUseCase.Select();

                if (status is not null)
                {
                    return Ok(status);
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
