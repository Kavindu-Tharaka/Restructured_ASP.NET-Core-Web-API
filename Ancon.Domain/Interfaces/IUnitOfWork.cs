using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Interfaces.Resturant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository productRepository { get; }
     
        IProductCategoryRepository productCategoryRepository { get; }

        IResturantRepository resturantRepository { get; }

        Task<bool> SaveAync();
    }
}
