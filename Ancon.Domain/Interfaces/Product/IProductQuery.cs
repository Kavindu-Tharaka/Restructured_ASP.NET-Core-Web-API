using Ancon.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces.Product
{
    public interface IProductQuery
    {
        Task<List<ProductQueryModel>> GetAllProducts();
        Task<IEnumerable<ProductQueryModel>> GetProductById(int id);
    }
}
