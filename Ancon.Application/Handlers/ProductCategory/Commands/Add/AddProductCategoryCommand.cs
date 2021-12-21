using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Commands.Add
{
    public class AddProductCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }
    }
}
