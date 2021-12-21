using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Ancon.Persistance.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ResturantStoreContext context;
        private readonly IMapper mapper;

        public ProductRepository(ResturantStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddProduct(ProductAddModel productModel)
        {
            var product = mapper.Map<Domain.Entities.Product>(productModel);   

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return product.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = new Domain.Entities.Product() { Id = productId };
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProduct(int productId, JsonPatchDocument document)
        {
            var product = await context.Products.FindAsync(productId);
            if (product != null)
            {
                document.ApplyTo(product);
                await context.SaveChangesAsync();
            }
        }
    }
}
