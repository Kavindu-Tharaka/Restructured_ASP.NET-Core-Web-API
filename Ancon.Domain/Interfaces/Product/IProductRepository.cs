using Ancon.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces.Product
{
    public interface IProductRepository
    {
        Task<int> AddProduct(Entities.Product product);
        Task UpdateProduct(int productId, JsonPatchDocument document);
        Task DeleteProduct(int productId);
    }
}
