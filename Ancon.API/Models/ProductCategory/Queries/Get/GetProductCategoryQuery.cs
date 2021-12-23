using Ancon.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Ancon.API.Models.ProductCategory.Queries.Get
{
    public class GetProductCategoryQuery : IRequest<List<ProductCategoryQueryModel>> { }
}
