using Ancon.Domain.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product()
            {
                Name = request.Name,
                Price = request.Price,
                UnitsInStock = request.UnitsInStock,
                ResturantId = request.ResturantId,
                ProductCategoryId = request.ProductCategoryId,
            };

            return await _unitOfWork.productRepository.AddProduct(product);

        }
    }
}
