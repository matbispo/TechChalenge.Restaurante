using Domain.Aplication;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TechChalenge.Restaurante.Controllers.v1
{
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
            return View();
        }

        [HttpGet]
        public Customer GetCustomerByCpf([FromQuery] string customerCpf)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }
}
