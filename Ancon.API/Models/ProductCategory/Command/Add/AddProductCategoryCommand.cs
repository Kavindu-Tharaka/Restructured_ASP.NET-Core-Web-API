using MediatR;

namespace Ancon.API.Models.ProductCategory.Command.Add
{
    public class AddProductCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }
    }
}
