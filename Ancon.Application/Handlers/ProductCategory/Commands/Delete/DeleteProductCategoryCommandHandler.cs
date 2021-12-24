using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.ProductCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Commands.Delete
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.productCategoryRepository.DeleteProductCategory(request.Id);
            return Unit.Value;
        }
    }
}
