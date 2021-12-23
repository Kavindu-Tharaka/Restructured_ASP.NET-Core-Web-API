using Ancon.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Ancon.API.Models.Resturant.Queries.GetById
{
    public class GetByIdResturantQuery : IRequest<IEnumerable<ResturantQueryModel>>
    {
        public int Id { get; set; }
    }
}
