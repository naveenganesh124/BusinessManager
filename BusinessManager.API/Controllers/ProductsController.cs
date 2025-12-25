using BusinessManager.Application.DTOs;
using BusinessManager.Application.Interfaces;
using BusinessManager.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManager.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(ApiResponse<object>.Ok(products, "Products fetched successfully"));
        }

        // ADD
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto dto)
        {
            await _productService.AddProductAsync(dto);
            return Ok(ApiResponse<object>.Ok("Product added successfully"));
        }

        // UPDATE
        [HttpPost("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto dto)
        {
            var updated = await _productService.UpdateProductAsync(dto);
            if (!updated)
            {
                return NotFound(
                    ApiResponse<object>.Fail("Product not found")
                );
            }

            return Ok(ApiResponse<object>.Ok("Product updated successfully"));
        }

        // DELETE
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductDto dto)
        {
            var deleted = await _productService.DeleteProductAsync(dto);
            if (!deleted)
            {
                return NotFound(
                    ApiResponse<object>.Fail("Product not found")
                );
            }

            return Ok(ApiResponse<object>.Ok("Product deleted successfully"));
        }
    }
}
