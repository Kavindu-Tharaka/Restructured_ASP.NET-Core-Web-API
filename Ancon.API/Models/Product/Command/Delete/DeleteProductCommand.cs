using MediatR;

namespace Ancon.API.Models.Product.Command.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
