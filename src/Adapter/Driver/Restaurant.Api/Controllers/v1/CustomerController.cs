using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChalenge.Restaurante.Controllers.v1
{
    [Route("v1/api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var id = _customerService.CreateCustomer(customer);

                return Ok(new { CustomerId = id});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("{customerCpf}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomerByCpf(string customerCpf)
        {
            try
            {
                var customer = _customerService.GetCustomerByCpf(customerCpf);

                if (customer is null)
                    return NoContent();

                return Ok(customer);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem();
            }
        }
    }
}
