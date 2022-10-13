using Microsoft.EntityFrameworkCore;
using Product_Management_API.Infrastructure.Models;

namespace Product_Management_API.Services
{
    public class ProductService
    {
        public readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            List<ProductModel> list = await _context.Products
                .Select(p => new ProductModel() { Id = p.Id, Name = p.Name, Available =  p.Available, Price = p.Price })
                .ToListAsync();
            return list;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }


        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}