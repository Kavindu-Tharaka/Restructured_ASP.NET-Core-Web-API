using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Queries.Get
{
    public class GetProductCategoryQuery : IRequest<List<ProductCategoryQueryModel>> { }
}
