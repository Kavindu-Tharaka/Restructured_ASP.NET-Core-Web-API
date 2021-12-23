using MediatR;

namespace Ancon.API.Models.Resturant.Command.Add
{
    public class AddResturantCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
