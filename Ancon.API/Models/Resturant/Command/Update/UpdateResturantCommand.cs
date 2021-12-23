using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Ancon.API.Models.Resturant.Command.Update
{
    public class UpdateResturantCommand : IRequest
    {
        public int Id { get; set; }

        public JsonPatchDocument document { get; set; }
    }
}
