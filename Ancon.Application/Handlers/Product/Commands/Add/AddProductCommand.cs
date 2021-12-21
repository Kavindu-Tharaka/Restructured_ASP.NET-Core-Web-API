using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Commands.Add
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int UnitsInStock { get; set; }
        public int ResturantId { get; set; }    //1 to M relationship
        public int ProductCategoryId { get; set; }  //1 to M relationship
    }
}
