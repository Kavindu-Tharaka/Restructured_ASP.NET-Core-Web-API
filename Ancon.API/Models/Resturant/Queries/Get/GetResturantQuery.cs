using Ancon.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Ancon.API.Models.Resturant.Queries.Get
{
    public class GetResturantQuery : IRequest<List<ResturantQueryModel>> { }
}
