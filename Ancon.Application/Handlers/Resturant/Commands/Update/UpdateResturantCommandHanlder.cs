using Ancon.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public UpdateResturantCommandHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateResturantCommand request, CancellationToken cancellationToken)
        {
            //await resturantRepository.UpdateResturant(request.Id, request.document);

            await _unitOfWork.resturantRepository.UpdateResturant(request.Id, request.document);

            return Unit.Value;
        }
    }
}
