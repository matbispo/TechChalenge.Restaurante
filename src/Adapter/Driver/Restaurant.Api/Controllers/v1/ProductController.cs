using Application.UseCases.Services.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TechChalenge.Restaurante.Controllers.v1
{
    [Route("v1/api/product")]
    [ApiController]
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
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                var id = _productService.CreateProduct(product);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return  Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }

        }

        [HttpGet("{productCategory}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IList<Product>))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductByCategory(ProductCategory productCategory)
        {
            try
            {
                var products = _productService.GetProductByCategory(productCategory);

                if (products is null || !products.Any())
                {
                    return NoContent();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpPut("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(Product))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct(long productId, Product product)
        {
            try
            {
                _productService.UpdateProduct(productId, product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpDelete("{productId}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct(long productId)
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
