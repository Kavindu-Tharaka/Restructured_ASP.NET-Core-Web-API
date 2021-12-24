using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Ancon.Persistance.Repositories.ProductCategory
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ResturantStoreContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryRepository(ResturantStoreContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddProductCategory(Domain.Entities.ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _unitOfWork.SaveAync();

            return productCategory.Id;
        }

        public async Task DeleteProductCategory(int productCategoryId)
        {
            var productCategory = new Domain.Entities.ProductCategory() { Id = productCategoryId };
            _context.ProductCategories.Remove(productCategory);
            await _unitOfWork.SaveAync();
        }

        public async Task UpdateProductCategory(int productCategoryId, JsonPatchDocument document)
        {
            var productCategory = await _context.ProductCategories.FindAsync(productCategoryId);
            if (productCategory != null)
            {
                document.ApplyTo(productCategory);
                await _unitOfWork.SaveAync();
            }
        }
    }
}
