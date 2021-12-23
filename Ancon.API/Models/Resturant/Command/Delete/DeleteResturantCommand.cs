using MediatR;

namespace Ancon.API.Models.Resturant.Command.Delete
{
    public class DeleteResturantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
