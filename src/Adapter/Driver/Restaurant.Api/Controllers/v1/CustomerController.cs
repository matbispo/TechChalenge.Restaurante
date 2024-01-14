using Application.UseCases.Customer.CreateCustomer;
using Application.UseCases.Customer.GetCustome;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChalenge.Restaurante.Controllers.v1
{
    [Route("v1/api/customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IGetCustomerUseCase _getCustomerUseCase;
        private readonly ICreateCustomerUseCase _createCustomerUseCase;

        public CustomerController(ILogger<CustomerController> logger, IGetCustomerUseCase getCustomerUseCase, ICreateCustomerUseCase createCustomerUseCase)
        {
            _logger = logger;
            _getCustomerUseCase = getCustomerUseCase;
            _createCustomerUseCase = createCustomerUseCase;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var id = _createCustomerUseCase.CreateCustomer(customer);

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
                var customer = _getCustomerUseCase.GetCustomerByCpf(customerCpf);

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
