using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Queries.Get
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductQueryModel>>
    {
        private readonly IProductQuery productQuery;

        public GetProductQueryHandler(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public async Task<List<ProductQueryModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await productQuery.GetAllProducts();
        }
    }
}
