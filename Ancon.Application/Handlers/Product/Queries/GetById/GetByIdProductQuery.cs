using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<IEnumerable<ProductQueryModel>>
    {
        public int Id { get; set; }
    }
}
