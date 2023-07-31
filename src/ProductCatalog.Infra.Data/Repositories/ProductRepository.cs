using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Infra.Data.Context;

namespace ProductCatalog.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
