using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductQueryModel>
    {
        private readonly IProductQuery productQuery;

        public GetByIdProductQueryHandler(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public async Task<ProductQueryModel> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            return await productQuery.GetProductById(request.Id);
        }
    }
}
