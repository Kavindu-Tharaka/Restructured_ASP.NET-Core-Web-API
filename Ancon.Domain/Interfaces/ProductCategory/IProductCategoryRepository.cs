using Ancon.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces.ProductCategory
{
    public interface IProductCategoryRepository
    {
        Task<int> AddProductCategory(ProductCategoryAddModel productCategoryModel);
        Task UpdateProductCategory(int productCategoryId, JsonPatchDocument document);
        Task DeleteProductCategory(int productCategoryId);
    }
}
