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

namespace Ancon.Application.Handlers.Resturant.Commands.Add
{
    public class AddResturantCommandHandler : IRequestHandler<AddResturantCommand, int>
    {
        private readonly IResturantRepository resturantRepository;

        public AddResturantCommandHandler(IResturantRepository resturantRepository )
        {
            this.resturantRepository = resturantRepository;
        }

        public async Task<int> Handle(AddResturantCommand request, CancellationToken cancellationToken)
        {
            var resturant = new ResturantAddModel()
            {
                Name = request.Name,
                Address = request.Address,
            };

            return await resturantRepository.AddResturant(resturant);

        }
    }
}
