using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public JsonPatchDocument document { get; set; }
    }
}
