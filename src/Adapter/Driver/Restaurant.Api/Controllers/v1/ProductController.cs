using Application.UseCases.Product.CreateProduct;
using Application.UseCases.Product.DeleteProduct;
using Application.UseCases.Product.GetProductByCategory;
using Application.UseCases.Product.UpdateProduct;
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

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(long))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProduct([FromServices] ICreateProductUseCase createProductUseCase, [FromBody] Product product)
        {
            try
            {
                var id = createProductUseCase.CreateProduct(product);

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
        public IActionResult GetProductByCategory([FromServices] IGetProductByCategoryUseCase getProductByCategoryUseCase, ProductCategory productCategory)
        {
            try
            {
                var products = getProductByCategoryUseCase.GetProductByCategory(productCategory);

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
        public IActionResult UpdateProduct([FromServices] IUpdateProductUseCase updateProductUseCase, long productId, Product product)
        {
            try
            {
                updateProductUseCase.UpdateProduct(productId, product);

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
        public IActionResult DeleteProduct([FromServices] IDeleteProductUseCase deleteProductUseCase, long productId)
        {
            try
            {
                deleteProductUseCase.DeleteProduct(productId);

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
