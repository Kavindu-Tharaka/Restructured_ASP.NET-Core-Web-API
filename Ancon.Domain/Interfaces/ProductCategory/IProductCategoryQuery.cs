using Ancon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces.ProductCategory
{
    public interface IProductCategoryQuery
    {
        Task<List<ProductCategoryQueryModel>> GetAllProductCategories();
        Task<IEnumerable<ProductCategoryQueryModel>> GetProductCategoryById(int id);
    }
}
