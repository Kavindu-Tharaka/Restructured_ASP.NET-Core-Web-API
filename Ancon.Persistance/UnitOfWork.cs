using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Interfaces.Resturant;
using Ancon.Persistance.Repositories.Product;
using Ancon.Persistance.Repositories.ProductCategory;
using Ancon.Persistance.Repositories.Resturant;
using System.Threading.Tasks;

namespace Ancon.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ResturantStoreContext _resturantStoreContext;

        public UnitOfWork(ResturantStoreContext resturantStoreContext)
        {
            _resturantStoreContext = resturantStoreContext;
        }

        public IProductRepository productRepository => new ProductRepository(_resturantStoreContext, this);

        public IProductCategoryRepository productCategoryRepository => new ProductCategoryRepository(_resturantStoreContext, this);

        public IResturantRepository resturantRepository => new ResturantRepository(_resturantStoreContext, this);

        public async Task<bool> SaveAync()
        {
            return await _resturantStoreContext.SaveChangesAsync() > 0;
        }
    }
}
