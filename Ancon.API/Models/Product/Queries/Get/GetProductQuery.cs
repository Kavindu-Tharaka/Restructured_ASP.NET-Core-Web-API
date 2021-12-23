using Ancon.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Ancon.API.Models.Product.Queries.Get
{
    public class GetProductQuery : IRequest<List<ProductQueryModel>> { }
}
