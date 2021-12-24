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

namespace Ancon.Application.Handlers.Resturant.Commands.Delete
{
    public class DeleteResturantCommandHandler : IRequestHandler<DeleteResturantCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteResturantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteResturantCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.resturantRepository.DeleteResturant(request.Id);
            return Unit.Value;
        }
    }
}
