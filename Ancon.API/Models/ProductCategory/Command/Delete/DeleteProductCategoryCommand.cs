using MediatR;

namespace Ancon.API.Models.ProductCategory.Command.Delete
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
