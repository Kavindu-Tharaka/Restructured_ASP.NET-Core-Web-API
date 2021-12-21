using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Ancon.Persistance.Repositories.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ResturantStoreContext context;
        private readonly IMapper mapper;

        public ProductCategoryRepository(ResturantStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddProductCategory(ProductCategoryAddModel productCategoryModel)
        {
            var productCategory = mapper.Map<Domain.Entities.ProductCategory>(productCategoryModel);   //mehema harida?  //swagger walin test karaddi add nam una

            context.ProductCategories.Add(productCategory);
            await context.SaveChangesAsync();

            return productCategory.Id;
        }

        public async Task DeleteProductCategory(int productCategoryId)
        {
            var productCategory = new Domain.Entities.ProductCategory() { Id = productCategoryId };
            context.ProductCategories.Remove(productCategory);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProductCategory(int productCategoryId, JsonPatchDocument document)
        {
            var productCategory = await context.ProductCategories.FindAsync(productCategoryId);
            if (productCategory != null)
            {
                document.ApplyTo(productCategory);
                await context.SaveChangesAsync();
            }
        }
    }
}
