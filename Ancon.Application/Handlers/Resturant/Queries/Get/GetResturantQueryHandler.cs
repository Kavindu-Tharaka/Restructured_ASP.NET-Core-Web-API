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

namespace Ancon.Application.Handlers.Resturant.Queries.Get
{
    public class GetResturantQueryHandler : IRequestHandler<GetResturantQuery, List<ResturantQueryModel>>
    {
        private readonly IResturantQuery resturantQuery;

        public GetResturantQueryHandler(IResturantQuery resturantQuery)
        {
            this.resturantQuery = resturantQuery;
        }

        public async Task<List<ResturantQueryModel>> Handle(GetResturantQuery request, CancellationToken cancellationToken)
        {
            return await resturantQuery.GetAllResturants();
        }
    }
}
