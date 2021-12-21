using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.Resturant;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Resturant.Commands.Update
{
    public class UpdateResturantCommandHanlder : IRequestHandler<UpdateResturantCommand, Unit>
    {
        private readonly IResturantRepository resturantRepository;

        public UpdateResturantCommandHanlder(IResturantRepository resturantRepository)
        {
            this.resturantRepository = resturantRepository;
        }

        public async Task<Unit> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            await resturantRepository.UpdateResturant(request.Id, request.document);

            return Unit.Value;
        }
    }
}
