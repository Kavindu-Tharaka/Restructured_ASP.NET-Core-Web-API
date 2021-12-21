using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Commands.Add
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductAddModel()
            {
                Name = request.Name,
                Price = request.Price,
                UnitsInStock = request.UnitsInStock,
                ResturantId = request.ResturantId,
                ProductCategoryId = request.ProductCategoryId,
            };

            return await productRepository.AddProduct(product);

        }
    }
}
