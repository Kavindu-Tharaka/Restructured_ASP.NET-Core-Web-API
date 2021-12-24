using Ancon.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public ProductRepository(ResturantStoreContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddProduct(Domain.Entities.Product product)
        {
            _context.Products.Add(product);
            await _unitOfWork.SaveAync();

            return product.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = new Domain.Entities.Product() { Id = productId };
            _context.Products.Remove(product);
            await _unitOfWork.SaveAync();
        }

        public async Task UpdateProduct(int productId, JsonPatchDocument document)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                document.ApplyTo(product);
                await _unitOfWork.SaveAync();
            }
        }
    }
}
