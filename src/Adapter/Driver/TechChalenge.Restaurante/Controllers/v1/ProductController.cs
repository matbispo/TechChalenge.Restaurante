using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace TechChalenge.Restaurante.Controllers.v1
{

    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                _productService.CreateProduct(product);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return  Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }

        }

        [HttpGet]
        public IActionResult GetProductById([FromQuery] long productId)
        {
            try
            {
                var product = _productService.GetProductById(productId);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpGet]
        public IActionResult GetProductByCategory([FromQuery] ProductCategory ProductCategoty)
        {
            try
            {
                var product = _productService.GetProductByCategory(ProductCategoty);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                var productUpdated = _productService.UpdateProduct(product);

                return Ok(productUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] long productId)
        {
            try
            {
                _productService.DeleteProduct(productId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }
    }
}
