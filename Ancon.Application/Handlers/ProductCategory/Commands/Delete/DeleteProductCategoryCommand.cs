using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Commands.Delete
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
