using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
