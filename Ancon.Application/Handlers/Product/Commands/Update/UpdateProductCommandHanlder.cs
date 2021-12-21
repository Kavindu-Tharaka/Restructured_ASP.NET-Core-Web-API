using Ancon.Domain.Interfaces.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Product.Commands.Update
{
    public class UpdateProductCommandHanlder : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository productRepository;

        public UpdateProductCommandHanlder(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await productRepository.UpdateProduct(request.Id, request.document);

            return Unit.Value;
        }
    }
}
