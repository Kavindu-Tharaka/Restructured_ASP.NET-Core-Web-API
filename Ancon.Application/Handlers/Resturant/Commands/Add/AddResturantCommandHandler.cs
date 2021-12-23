using Ancon.Domain.Interfaces.Resturant;
using MediatR;
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
            var resturant = new Domain.Entities.Resturant()
            {
                Name = request.Name,
                Address = request.Address,
            };

            return await resturantRepository.AddResturant(resturant);

        }
    }
}
