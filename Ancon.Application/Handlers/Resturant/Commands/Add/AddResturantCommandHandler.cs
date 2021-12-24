using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.Resturant;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Resturant.Commands.Add
{
    public class AddResturantCommandHandler : IRequestHandler<AddResturantCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddResturantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddResturantCommand request, CancellationToken cancellationToken)
        {
            var resturant = new Domain.Entities.Resturant()
            {
                Name = request.Name,
                Address = request.Address,
            };

            return await _unitOfWork.resturantRepository.AddResturant(resturant);

        }
    }
}
