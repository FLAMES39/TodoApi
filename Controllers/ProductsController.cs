using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.dto;

using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _ProductService;

        public ProductsController(ProductsService productService)
        {

            _ProductService = productService;

        }


        [HttpGet]
        public async Task<ActionResult<List<Products>>> getProducts()
        {
            var products = await _ProductService.GetProducts();
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<Products>> singleProduct(int Id)
        {
            var product = await _ProductService.singleProduct(Id);
            return Ok(product);
        }

        public async Task<ActionResult<List<Products>>> updateProduct(int id, Products products)
        {
            var product = await _ProductService.updateProducts(id, products);
            return Ok(product);
        }
    }
}