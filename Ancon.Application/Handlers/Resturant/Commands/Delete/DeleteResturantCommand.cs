using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Resturant.Commands.Delete
{
    public class DeleteResturantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
