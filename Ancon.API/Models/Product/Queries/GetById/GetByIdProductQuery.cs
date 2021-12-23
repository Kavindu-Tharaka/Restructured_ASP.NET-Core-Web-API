using Ancon.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Ancon.API.Models.Product.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<IEnumerable<ProductQueryModel>>
    {
        public int Id { get; set; }
    }
}
