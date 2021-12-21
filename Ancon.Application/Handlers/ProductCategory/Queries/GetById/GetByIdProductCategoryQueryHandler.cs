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

namespace Ancon.Application.Handlers.ProductCategory.Queries.GetById
{
    public class GetByIdProductCategoryQueryHandler : IRequestHandler<GetByIdProductCategoryQuery, IEnumerable<ProductCategoryQueryModel>>
    {
        private readonly IProductCategoryQuery productCategoryQuery;

        public GetByIdProductCategoryQueryHandler(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }

        public async Task<IEnumerable<ProductCategoryQueryModel>> Handle(GetByIdProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await productCategoryQuery.GetProductCategoryById(request.Id);
        }
    }
}
