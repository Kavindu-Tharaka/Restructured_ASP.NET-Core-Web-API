using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Ancon.API.Models.Product.Command.Update
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }

        public JsonPatchDocument document { get; set; }
    }
}
