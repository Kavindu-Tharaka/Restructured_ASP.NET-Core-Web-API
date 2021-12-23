using Ancon.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Ancon.API.Models.ProductCategory.Queries.GetById
{
    public class GetByIdProductCategoryQuery : IRequest<IEnumerable<ProductCategoryQueryModel>>
    {
        public int Id { get; set; }
    }
}
