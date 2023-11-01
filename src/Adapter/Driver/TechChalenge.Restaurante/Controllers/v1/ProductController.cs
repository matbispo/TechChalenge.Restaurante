using Application.Services.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpGet("{productId}")]
        //public IActionResult GetProductById(long productId)
        //{
        //    try
        //    {
        //        var product = _productService.GetProductById(productId);

        //        return Ok(product);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "");
        //        return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
        //    }
        //}

        [HttpGet("{productCategory}")]
        public IActionResult GetProductByCategory(ProductCategory productCategory)
        {
            try
            {
                var product = _productService.GetProductByCategory(productCategory);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return Problem(detail: "Erro ao cadastrar o produto. Contate o susporte.", statusCode: 500, title: "Erro Desconhecido");
            }
        }

        [HttpPut("{productId}")]
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
