using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.Resturant;
using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Resturant.Queries.GetById
{
    public class GetByIdResturantQueryHandler : IRequestHandler<GetByIdResturantQuery, IEnumerable<ResturantQueryModel>>
    {
        private readonly IResturantQuery resturantQuery;

        public GetByIdResturantQueryHandler(IResturantQuery resturantQuery)
        {
            this.resturantQuery = resturantQuery;
        }

        public async Task<IEnumerable<ResturantQueryModel>> Handle(GetByIdResturantQuery request, CancellationToken cancellationToken)
        {
            return await resturantQuery.GetResturantById(request.Id);
        }
    }
}
