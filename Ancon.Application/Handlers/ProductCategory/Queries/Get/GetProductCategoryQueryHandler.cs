using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Queries.Get
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, List<ProductCategoryQueryModel>>
    {
        private readonly IProductCategoryQuery productCategoryQuery;

        public GetProductCategoryQueryHandler(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }

        public async Task<List<ProductCategoryQueryModel>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await productCategoryQuery.GetAllProductCategories();
        }
    }
}
