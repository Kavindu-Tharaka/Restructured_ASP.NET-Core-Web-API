using MediatR;

namespace Ancon.Application.Handlers.Resturant.Commands.Add
{
    public class AddResturantCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
