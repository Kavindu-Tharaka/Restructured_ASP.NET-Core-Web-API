using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Ancon.API.Models.ProductCategory.Command.Update
{
    public class UpdateProductCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public JsonPatchDocument document { get; set; }
    }
}
