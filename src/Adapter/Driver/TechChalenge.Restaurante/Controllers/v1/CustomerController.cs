using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
                return Problem();
            }
        }

        [HttpGet("{customerCpf}")]
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
