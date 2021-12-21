using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.Resturant;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Resturant.Commands.Delete
{
    public class DeleteResturantCommandHandler : IRequestHandler<DeleteResturantCommand, Unit>
    {
        private readonly IResturantRepository resturantRepository;

        public DeleteResturantCommandHandler(IResturantRepository resturantRepository)
        {
            this.resturantRepository = resturantRepository;
        }

        public async Task<Unit> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            await resturantRepository.DeleteResturant(request.Id);
            return Unit.Value;
        }
    }
}
