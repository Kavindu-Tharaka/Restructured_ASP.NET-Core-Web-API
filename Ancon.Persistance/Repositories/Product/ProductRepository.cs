using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Ancon.Persistance.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ResturantStoreContext _context;

        public ProductRepository(ResturantStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddProduct(Domain.Entities.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = new Domain.Entities.Product() { Id = productId };
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(int productId, JsonPatchDocument document)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                document.ApplyTo(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
