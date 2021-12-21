using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Queries.Get
{
    public class GetProductQuery : IRequest<List<ProductQueryModel>> { }
}
