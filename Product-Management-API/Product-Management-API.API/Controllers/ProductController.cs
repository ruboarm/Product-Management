using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Management_API.Infrastructure.Models;
using Product_Management_API.Services;

namespace Product_Management_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ApplicationDbContext context, ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<ProductModel>> Get()
        {
            List<ProductModel> Products = null;
            try
            {
                Products = await _productService.GetProductsAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

            return Products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product?> Get(int id)
        {
            var Product = await _productService.GetProductByIdAsync(id);

            return Product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize]
        public async Task<Product?> Post([FromBody] Product Product)
        {
            Product? updatedProduct = null;
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.CreateProductAsync(Product);
                }
                catch (Exception ex)
                {
                    throw;
                }

                updatedProduct = await _productService.GetProductByIdAsync(Product.Id);
            }

            return updatedProduct;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        //public async void Put(int id, [FromBody] Product Product)
        [Authorize]
        public async Task<Product> Put(int id, [FromBody] Product Product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateProductAsync(Product);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return Product;
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _productService.DeleteProductByIdAsync(id);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
